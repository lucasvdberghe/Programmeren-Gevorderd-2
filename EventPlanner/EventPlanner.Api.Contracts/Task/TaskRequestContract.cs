using System;
using System.ComponentModel.DataAnnotations;
using EventPlanner.Shared;

namespace EventPlanner.Api.Contracts.Task;

public class TaskRequestContract
{
    public required string Name { get; set; }
    public int EventId { get; set; }
    public string? Description { get; set; }
    public ImportanceEnum Importance { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime? DeadlineDateTime { get; set; }
}
