using System;
using EventPlanner.Api.Contracts.Event;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using EventPlanner.Services.Mapping;
using EventPlanner.Shared;
using EventPlanner.Storage.Interfaces;

namespace EventPlanner.Services;

public class EventService(IEventRepository eventRepository, ILocationRepository locationRepository, IAuditService auditService) : IEventService
{
    public async Task<IEnumerable<EventResponseContract>> GetAllAsync()
    {
        var eventContracts = (await eventRepository.GetAllAsync()).Select(e => e.AsContract());

        await auditService.AddEntryAsync("Event", "R", null, eventContracts);

        return eventContracts;
    }

    public async Task<EventResponseContract?> GetByIdAsync(int id)
    {
        var foundEvent = await eventRepository.GetByIdAsync(id);

        await auditService.AddEntryAsync("Event", "R", null, foundEvent?.AsContract());

        return foundEvent?.AsContract();
    }

    public async Task<EventResponseContract> CreateAsync(EventRequestContract eventRequestContract)
    {
        var location = await locationRepository.GetByIdAsync(eventRequestContract.LocationId);
        if (location is null) throw new NotFoundException("Location not found");

        var eventModel = eventRequestContract.AsModel(location);
        var addedEventContract = (await eventRepository.AddAsync(eventModel)).AsContract();

        await auditService.AddEntryAsync("Event", "C", null, addedEventContract);
        return addedEventContract;
    }

    public async Task UpdateAsync(int id, EventRequestContract eventRequestContract)
    {
        var foundEvent = await eventRepository.GetByIdAsync(id);
        if (foundEvent is null) throw new NotFoundException();

        var location = await locationRepository.GetByIdAsync(eventRequestContract.LocationId);
        if (location is null) throw new DomainException("Location not found");

        var foundEventContract = foundEvent.AsContract();

        foundEvent.Name = eventRequestContract.Name;
        foundEvent.StartDateTime = eventRequestContract.StartDateTime;
        foundEvent.EndDateTime = eventRequestContract.EndDateTime;
        foundEvent.Location = location;
        foundEvent.LastUpdated = DateTime.UtcNow;

        await eventRepository.UpdateAsync(foundEvent);
        await auditService.AddEntryAsync("Event", "U", foundEventContract, foundEvent.AsContract());
    }

    public async Task DeleteAsync(int id)
    {
        var foundEvent = await eventRepository.GetByIdAsync(id);
        if (foundEvent is null) throw new NotFoundException();

        var foundEventContract = foundEvent.AsContract();

        await auditService.AddEntryAsync("Event", "D", foundEventContract, null);
        await eventRepository.DeleteAsync(id);
    }

    public async Task<SummaryReportDto> GetSummaryReportAsync(int id)
    {
        return await eventRepository.GetSummaryReportAsync(id);
    }
}
