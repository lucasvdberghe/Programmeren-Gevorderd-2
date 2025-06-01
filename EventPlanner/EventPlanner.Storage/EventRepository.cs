using System;
using Dapper;
using EventPlanner.Shared;
using EventPlanner.Storage.Interfaces;
using EventPlanner.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace EventPlanner.Storage;

public class EventRepository(EventPlannerDbContext dbContext) : IEventRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await dbContext.Events.Include(e => e.Location).ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(int id)
    {
        return await dbContext.Events.Include(e => e.Location).SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event> AddAsync(Event eventModel)
    {
        await dbContext.Events.AddAsync(eventModel);
        await dbContext.SaveChangesAsync();
        return eventModel;
    }

    public async Task UpdateAsync(Event eventModel)
    {
        dbContext.Events.Update(eventModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var eventToDelete = await dbContext.Events.FindAsync(id);
        if (eventToDelete is not null)
        {
            dbContext.Events.Remove(eventToDelete);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<SummaryReportDto> GetSummaryReportAsync(int id)
    {
        var query = "SELECT e.Id EventId, e.Name EventName, l.Id LocationId, l.Name LocationName, " +
            "((SELECT COUNT(*) FROM Tasks WHERE EventId = @EventId AND Status = @StatusCompleted) / " +
            "(SELECT COUNT(*) FROM Tasks WHERE EventId = @EventId) * 100) TasksCompletedPercentage, " +
            "(SELECT COUNT(*) FROM Tasks WHERE EventId = @EventId AND Importance = @MustImportance AND Status = @TodoStatus) TodoMustTasks, " +
            "GREATEST(e.LastUpdate, (SELECT MAX(LastUpdated) FROM Tasks WHERE EventId = @EventId) LastTaskUpdate) LastUpdate " +
            "FROM Events e INNER JOIN Locations l ON e.LocationId = l.Id";

        var summary = await dbContext.Database.GetDbConnection().QuerySingleAsync<SummaryReportDto>(query, new
        {
            EventId = id,
            StatusCompleted = StatusEnum.Done,
            MustImportance = ImportanceEnum.Must,
            TodoStatus = StatusEnum.Todo
        });

        return summary;
    }
}
