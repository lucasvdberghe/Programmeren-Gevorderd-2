using System;
using EventPlanner.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace EventPlanner.Storage.Interfaces;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(int id);
    Task<Location> AddAsync(Location location);
    Task UpdateAsync(Location location);
    Task DeleteAsync(int id);
}
