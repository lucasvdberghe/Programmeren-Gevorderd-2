using System;

namespace Treinoef.Api.Contracts.Subscriptions;

public class SubscriptionRequestContract
{
    public int CustomerId { get; set; }
    public int Station1Id { get; set; }
    public int Station2Id { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public int ComfortLevel { get; set; }
}
