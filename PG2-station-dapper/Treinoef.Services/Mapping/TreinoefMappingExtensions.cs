using System;
using Treinoef.Api.Contracts.Customers;
using Treinoef.Api.Contracts.Stations;
using Treinoef.Api.Contracts.Subscriptions;
using Treinoef.Services.Models;
using Treinoef.Storage;

namespace Treinoef.Services.Mapping;

public static class TreinoefMappingExtensions
{
    public static CustomerResponseContract AsContract(this Customer customer)
    {
        return new CustomerResponseContract
        {
            Id = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email
        };
    }

    public static Customer AsModel(this CustomerRequestContract customerRequestContract)
    {
        return new Customer
        {
            FirstName = customerRequestContract.FirstName,
            LastName = customerRequestContract.LastName,
            Email = customerRequestContract.Email
        };
    }

    public static StationResponseContract AsContract(this Station station)
    {
        return new StationResponseContract
        {
            Id = station.StationId,
            Name = station.Name,
            HeatedWaitingArea = station.HeatedWaitingArea
        };
    }

    public static Station AsModel(this StationRequestContract stationRequestContract)
    {
        return new Station
        {
            Name = stationRequestContract.Name,
            HeatedWaitingArea = stationRequestContract.HeatedWaitingArea
        };
    }

    // public static SubscriptionResponseContract AsContract(this Subscription subscriptionEntity)
    // {
    //     return new SubscriptionResponseContract
    //     {
    //         Id = subscriptionEntity.Id,
    //         Customer = subscriptionEntity.Customer.AsSubscriptionCustomerResponseContract(),
    //         Station1 = subscriptionEntity.Station1.AsSubscriptionStationResponseContract(),
    //         Station2 = subscriptionEntity.Station2.AsSubscriptionStationResponseContract(),
    //         ValidFrom = subscriptionEntity.ValidFrom,
    //         ValidUntil = subscriptionEntity.ValidUntil,
    //         ComfortLevel = subscriptionEntity.ComfortLevel
    //     };
    // }

    // private static SubscriptionCustomerResponseContract AsSubscriptionCustomerResponseContract(this Customer customerEntity)
    // {
    //     return new SubscriptionCustomerResponseContract
    //     {
    //         Id = customerEntity.Id,
    //         Name = $"{customerEntity.FirstName} {customerEntity.LastName}"
    //     };
    // }

    // private static SubscriptionStationResponseContract AsSubscriptionStationResponseContract(this Station stationEntity)
    // {
    //     return new SubscriptionStationResponseContract
    //     {
    //         Id = stationEntity.Id,
    //         Name = stationEntity.Name
    //     };
    // }

    // public static Subscription AsEntity(this SubscriptionRequestContract subscriptionRequestContract)
    // {
    //     return new Subscription
    //     {
    //         CustomerId = subscriptionRequestContract.CustomerId,
    //         Station1Id = subscriptionRequestContract.Station1Id,
    //         Station2Id = subscriptionRequestContract.Station2Id,
    //         ValidFrom = subscriptionRequestContract.ValidFrom,
    //         ValidUntil = subscriptionRequestContract.ValidUntil,
    //         ComfortLevel = subscriptionRequestContract.ComfortLevel
    //     };
    // }
}
