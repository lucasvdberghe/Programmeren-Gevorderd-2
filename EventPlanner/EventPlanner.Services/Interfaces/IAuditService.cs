using System;
using EventPlanner.Api.Contracts.Location;
using EventPlanner.Shared;

namespace EventPlanner.Services.Interfaces;

public interface IAuditService
{
    Task AddEntryAsync(string subject, string action, object? oldValue, object? newValue);
    Task<IEnumerable<AuditEntry>> GetAuditTrailAsync(string? subject, string? action);
}
