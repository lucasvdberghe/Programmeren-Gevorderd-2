using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Api.Contracts.Location;

public class LocationRequestContract
{
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }
    [Range(-90, 90)]
    public double GpsLat { get; set; }
    [Range(-180, 180)]
    public double GpsLon { get; set; }
}
