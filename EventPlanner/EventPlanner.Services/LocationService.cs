using System;
using EventPlanner.Api.Contracts.Location;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using EventPlanner.Services.Mapping;
using EventPlanner.Storage.Interfaces;

namespace EventPlanner.Services;

public class LocationService(ILocationRepository locationRepository, IAuditService auditService) : ILocationService
{
    public async Task<IEnumerable<LocationResponseContract>> GetAllAsync()
    {
        var locationContracts = (await locationRepository.GetAllAsync()).Select(l => l.AsContract()).ToList();

        await auditService.AddEntryAsync("Location", "R", null, locationContracts);

        return locationContracts;
    }

    public async Task<LocationResponseContract?> GetByIdAsync(int id)
    {
        var locationContract = (await locationRepository.GetByIdAsync(id)).AsContract();

        await auditService.AddEntryAsync("Location", "R", null, locationContract);

        return locationContract;
    }

    public async Task<LocationResponseContract> CreateAsync(LocationRequestContract locationRequestContract)
    {
        var newLocation = locationRequestContract.AsModel();
        var createdLocationContract = (await locationRepository.AddAsync(newLocation)).AsContract();

        await auditService.AddEntryAsync("Location", "C", null, createdLocationContract);

        return createdLocationContract;
    }

    public async Task UpdateAsync(int id, LocationRequestContract locationRequestContract)
    {
        var location = await locationRepository.GetByIdAsync(id);
        if (location is null) throw new NotFoundException();

        var oldLocationContract = location.AsContract();

        location.Name = locationRequestContract.Name;
        location.Description = locationRequestContract.Description;
        location.GpsLat = locationRequestContract.GpsLat;
        location.GpsLon = locationRequestContract.GpsLon;

        await locationRepository.UpdateAsync(location);
        await auditService.AddEntryAsync("Location", "U", oldLocationContract, location.AsContract());
    }

    public async Task DeleteAsync(int id)
    {
        var location = await locationRepository.GetByIdAsync(id);
        if (location is null) throw new NotFoundException();

        await auditService.AddEntryAsync("Location", "D", location.AsContract(), null);
        await locationRepository.DeleteAsync(id);
    }
}
