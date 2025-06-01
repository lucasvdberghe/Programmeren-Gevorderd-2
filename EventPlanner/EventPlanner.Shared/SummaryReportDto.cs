using System;

namespace EventPlanner.Shared;

public class SummaryReportDto
{
    public int EventId { get; set; }
    public required string EventName { get; set; }
    public int LocationId { get; set; }
    public required string LocationName { get; set; }
    public double TasksCompletedPercentage { get; set; }
    public int TodoMustTasks { get; set; }
    public DateTime LastUpdate { get; set; }
}
