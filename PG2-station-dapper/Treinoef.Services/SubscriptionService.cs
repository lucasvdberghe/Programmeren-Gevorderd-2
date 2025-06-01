using System;
using Microsoft.EntityFrameworkCore;
using Treinoef.Api.Contracts.Subscriptions;
using Treinoef.Services.Exceptions;
using Treinoef.Services.Interfaces;
using Treinoef.Services.Mapping;
using Treinoef.Storage;

namespace Treinoef.Services;

public class SubscriptionService(TreinoefContext dbContext) : ISubscriptionService
{
    public IEnumerable<SubscriptionResponseContract> GetAll()
    {
        return dbContext.Subscriptions
            .Include(se => se.Customer)
            .Include(se => se.Station1)
            .Include(se => se.Station2)
            .Select(se => se.AsContract())
            .ToList();
    }

    public SubscriptionResponseContract? Get(int id)
    {
        var subscriptionEntity = dbContext.Subscriptions
            .Include(se => se.Customer)
            .Include(se => se.Station1)
            .Include(se => se.Station2)
            .SingleOrDefault(se => se.Id == id);

        return subscriptionEntity?.AsContract();
    }

    public SubscriptionResponseContract Create(SubscriptionRequestContract subscriptionRequestContract)
    {
        var customerHasOverlappingSubscriptions = dbContext.Subscriptions
            .Any(se => se.CustomerId == subscriptionRequestContract.CustomerId
            && se.Station1Id == subscriptionRequestContract.Station1Id
            && se.Station2Id == subscriptionRequestContract.Station2Id
            && subscriptionRequestContract.ValidFrom <= se.ValidUntil
             && subscriptionRequestContract.ValidUntil >= se.ValidFrom);

        if (customerHasOverlappingSubscriptions) throw new DomainException("Customer has overlapping subscriptions for the route between those two stations");

        var createdSubscription = subscriptionRequestContract.AsEntity();

        dbContext.Subscriptions.Add(createdSubscription);
        dbContext.SaveChanges();

        return createdSubscription.AsContract();
    }
}