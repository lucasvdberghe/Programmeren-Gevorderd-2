using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Storage.Models;

public class Event
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public required Location Location { get; set; }
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}
