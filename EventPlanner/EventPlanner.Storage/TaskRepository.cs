using System;
using EventPlanner.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Storage;

public class TaskRepository(EventPlannerDbContext dbContext) : ITaskRepository
{
    public async Task<IEnumerable<Models.Task>> GetAllAsync()
    {
        return await dbContext.Tasks.Include(t => t.Event).ToListAsync();
    }

    public async Task<Models.Task?> GetByIdAsync(int id)
    {
        return await dbContext.Tasks.Include(t => t.Event).SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Models.Task> AddAsync(Models.Task task)
    {
        await dbContext.Tasks.AddAsync(task);
        await dbContext.SaveChangesAsync();
        return task;
    }

    public async Task DeleteAsync(int id)
    {
        var taskToDelete = dbContext.Tasks.Find(id);
        if (taskToDelete is not null)
        {
            dbContext.Tasks.Remove(taskToDelete);
            await dbContext.SaveChangesAsync();
        }
    }


    public async Task UpdateAsync(Models.Task taskToUpdate)
    {
        dbContext.Tasks.Update(taskToUpdate);
        await dbContext.SaveChangesAsync();
    }
}
