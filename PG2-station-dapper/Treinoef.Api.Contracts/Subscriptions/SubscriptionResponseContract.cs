using System;

namespace Treinoef.Api.Contracts.Subscriptions;

public class SubscriptionResponseContract
{
    public int Id { get; set; }
    public required SubscriptionCustomerResponseContract Customer { get; set; }
    public required SubscriptionStationResponseContract Station1 { get; set; }
    public required SubscriptionStationResponseContract Station2 { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public int ComfortLevel { get; set; }
}

public class SubscriptionCustomerResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class SubscriptionStationResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
}