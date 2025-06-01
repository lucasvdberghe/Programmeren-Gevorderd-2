using System;
using EventPlanner.Api.Contracts.Location;

namespace EventPlanner.Services.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<LocationResponseContract>> GetAllAsync();
    Task<LocationResponseContract?> GetByIdAsync(int id);
    Task<LocationResponseContract> CreateAsync(LocationRequestContract locationRequestContract);
    Task UpdateAsync(int id, LocationRequestContract locationRequestContract);
    Task DeleteAsync(int id);
}
