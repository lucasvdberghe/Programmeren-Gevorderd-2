using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Api.Contracts.Event;

public class EventRequestContract
{
    [MaxLength(100)]
    public required string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int LocationId { get; set; }
}
