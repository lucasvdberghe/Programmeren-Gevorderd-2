using System;
using Treinoef.Api.Contracts.Subscriptions;

namespace Treinoef.Services.Interfaces;

public interface ISubscriptionService
{
    IEnumerable<SubscriptionResponseContract> GetAll();
    SubscriptionResponseContract? Get(int id);
    SubscriptionResponseContract Create(SubscriptionRequestContract subscriptionRequestContract);
}
