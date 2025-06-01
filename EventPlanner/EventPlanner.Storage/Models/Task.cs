using System;
using System.ComponentModel.DataAnnotations;
using EventPlanner.Shared;

namespace EventPlanner.Storage.Models;

public class Task
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public required Event Event { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }
    public ImportanceEnum Importance { get; set; } = ImportanceEnum.Must;
    public StatusEnum Status { get; set; } = StatusEnum.Todo;
    public DateTime? DeadlineDateTime { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}
