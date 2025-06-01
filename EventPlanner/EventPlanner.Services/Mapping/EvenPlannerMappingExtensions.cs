using System;
using EventPlanner.Api.Contracts.Event;
using EventPlanner.Api.Contracts.Location;
using EventPlanner.Api.Contracts.Task;
using EventPlanner.Storage.Models;

namespace EventPlanner.Services.Mapping;

public static class EvenPlannerMappingExtensions
{
    public static Location AsModel(this LocationRequestContract locationRequestContract)
    {
        return new Location
        {
            Name = locationRequestContract.Name,
            Description = locationRequestContract.Description,
            GpsLat = locationRequestContract.GpsLat,
            GpsLon = locationRequestContract.GpsLon
        };
    }

    public static LocationResponseContract AsContract(this Location location)
    {
        return new LocationResponseContract
        {
            Id = location.Id,
            Name = location.Name,
            Description = location.Description,
            GpsLat = location.GpsLat,
            GpsLon = location.GpsLon
        };
    }

    public static Event AsModel(this EventRequestContract eventRequestContract, Location location)
    {
        return new Event
        {
            Name = eventRequestContract.Name,
            StartDateTime = eventRequestContract.StartDateTime,
            EndDateTime = eventRequestContract.EndDateTime,
            Location = location
        };
    }

    public static EventResponseContract AsContract(this Event eventModel)
    {
        return new EventResponseContract
        {
            Id = eventModel.Id,
            Name = eventModel.Name,
            StartDateTime = eventModel.StartDateTime,
            EndDateTime = eventModel.EndDateTime,
            LocationId = eventModel.Location.Id,
            LocationName = eventModel.Location.Name
        };
    }

    public static Storage.Models.Task AsModel(this TaskRequestContract taskRequestContract, Event eventModel)
    {
        return new Storage.Models.Task
        {
            Name = taskRequestContract.Name,
            Event = eventModel,
            Description = taskRequestContract.Description,
            Importance = taskRequestContract.Importance,
            Status = taskRequestContract.Status,
            DeadlineDateTime = taskRequestContract.DeadlineDateTime
        };
    }

    public static TaskResponseContract AsContract(this Storage.Models.Task task)
    {
        return new TaskResponseContract
        {
            Id = task.Id,
            Name = task.Name,
            EventId = task.Event.Id,
            EventName = task.Event.Name,
            Description = task.Description,
            Importance = task.Importance,
            Status = task.Status,
            DeadlineDateTime = task.DeadlineDateTime
        };
    }
}
