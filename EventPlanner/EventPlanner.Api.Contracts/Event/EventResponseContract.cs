using System;

namespace EventPlanner.Api.Contracts.Event;

public class EventResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int LocationId { get; set; }
    public required string LocationName { get; set; }
}
