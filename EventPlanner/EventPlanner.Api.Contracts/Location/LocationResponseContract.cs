using System;

namespace EventPlanner.Api.Contracts.Location;

public class LocationResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public double GpsLat { get; set; }
    public double GpsLon { get; set; }
}
