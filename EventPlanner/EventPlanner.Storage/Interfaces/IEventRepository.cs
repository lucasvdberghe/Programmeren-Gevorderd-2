using System;
using EventPlanner.Shared;
using EventPlanner.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace EventPlanner.Storage.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task<Event> AddAsync(Event eventModel);
    Task UpdateAsync(Event eventModel);
    Task DeleteAsync(int id);
    Task<SummaryReportDto> GetSummaryReportAsync(int id);
}
