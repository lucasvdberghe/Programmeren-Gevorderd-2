using System;
using EventPlanner.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Task = EventPlanner.Storage.Models.Task;

namespace EventPlanner.Storage;

public class EventPlannerDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }

    public EventPlannerDbContext(DbContextOptions<EventPlannerDbContext> options) : base(options)
    {
    }
}
