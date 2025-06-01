using System;
using MongoDB.Bson;

namespace EventPlanner.Shared;

public class AuditEntry
{
    public ObjectId Id { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public required string Subject { get; set; }
    public required string Action { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}
