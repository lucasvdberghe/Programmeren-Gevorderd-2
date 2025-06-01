using System;
using Dapper;
using MySqlConnector;
using Treinoef.Services.Models;
using Treinoef.Storage.Interfaces;
using Treinoef.Storage.Queries;

namespace Treinoef.Storage;

public class SubscriptionRepository : ISubscriptionRepository
{

    private const string _connectionString = "server=127.0.0.1;port=3307;database=treinoef;user=root;password=WachtW00rd";
    private QueryRepository _queryRepository = new QueryRepository();

    public IEnumerable<Subscription> GetAll()
    {
        using var connection = new MySqlConnection(_connectionString);
        var results = connection.Query<Subscription>(_queryRepository.GetAllSubscriptions);
        return results;
    }

    public Subscription? GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<Subscription>(_queryRepository.GetSubscriptionById, new { Id = id });
        return result;
    }

    public Subscription Create(Subscription subscription)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<int>(_queryRepository.CreateSubscription, subscription);
        return GetById(result);
    }
}
