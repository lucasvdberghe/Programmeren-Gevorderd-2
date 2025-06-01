using System;
using EventPlanner.Api.Contracts.Event;
using EventPlanner.Shared;

namespace EventPlanner.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventResponseContract>> GetAllAsync();
    Task<EventResponseContract?> GetByIdAsync(int id);
    Task<EventResponseContract> CreateAsync(EventRequestContract eventRequestContract);
    Task UpdateAsync(int id, EventRequestContract eventRequestContract);
    Task DeleteAsync(int id);
    Task<SummaryReportDto> GetSummaryReportAsync(int id);
}
