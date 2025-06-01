using System;
using Treinoef.Services.Models;

namespace Treinoef.Storage.Interfaces;

public interface ISubscriptionRepository
{
    IEnumerable<Subscription> GetAll();
    Subscription? GetById(int id);
    Subscription Create(Subscription subscription);
}
