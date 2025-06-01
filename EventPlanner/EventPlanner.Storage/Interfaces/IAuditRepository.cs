using System;
using EventPlanner.Shared;

namespace EventPlanner.Storage.Interfaces;

public interface IAuditRepository
{
    Task AddEntryAsync(string subject, string action, string oldValue, string newValue);
    Task<IEnumerable<AuditEntry>> GetAuditTrailAsync(string? subject, string? action);
}
