using System;
using System.Text.Json;
using EventPlanner.Services.Interfaces;
using EventPlanner.Shared;
using EventPlanner.Storage.Interfaces;

namespace EventPlanner.Services;

public class AuditService(IAuditRepository auditRepository) : IAuditService
{
    public async Task AddEntryAsync(string subject, string action, object? oldValue, object? newValue)
    {
        if (subject is null)
        {
            throw new ArgumentNullException("Subject is empty");
        }
        if (action is null)
        {
            throw new ArgumentNullException("Action is empty");
        }
        await auditRepository.AddEntryAsync(subject, action, JsonSerializer.Serialize(oldValue), JsonSerializer.Serialize(newValue));
    }

    public async Task<IEnumerable<AuditEntry>> GetAuditTrailAsync(string? subject, string? action)
    {
        return await auditRepository.GetAuditTrailAsync(subject, action);
    }
}
