using System;
using Dapper;
using MySqlConnector;
using Treinoef.Services.Models;
using Treinoef.Storage.Interfaces;
using Treinoef.Storage.Queries;

namespace Treinoef.Storage;

public class CustomerRepository : ICustomerRepository
{

    private const string _connectionString = "server=127.0.0.1;port=3307;database=treinoef;user=root;password=WachtW00rd";
    private QueryRepository _queryRepository = new QueryRepository();

    public IEnumerable<Customer> GetAll()
    {
        using var connection = new MySqlConnection(_connectionString);
        var results = connection.Query<Customer>(_queryRepository.GetAllCustomers);
        return results;
    }

    public Customer? GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<Customer>(_queryRepository.GetCustomerById, new { Id = id });
        return result;
    }

    public Customer Create(Customer customer)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<int>(_queryRepository.CreateCustomer, customer);
        return GetById(result);
    }
}