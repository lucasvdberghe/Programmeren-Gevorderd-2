using System;
using EventPlanner.Storage.Interfaces;
using EventPlanner.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace EventPlanner.Storage;

public class LocationRepository(EventPlannerDbContext dbContext) : ILocationRepository
{
    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await dbContext.Locations.ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await dbContext.Locations.FindAsync(id);
    }

    public async Task<Location> AddAsync(Location location)
    {
        await dbContext.Locations.AddAsync(location);
        await dbContext.SaveChangesAsync();
        return location;
    }

    public async Task UpdateAsync(Location location)
    {
        dbContext.Locations.Update(location);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var locationToDelete = await dbContext.Locations.FindAsync(id);
        if (locationToDelete is not null)
        {
            dbContext.Locations.Remove(locationToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
