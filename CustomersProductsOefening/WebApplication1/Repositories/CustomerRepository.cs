using System;
using WebApplication1.Contracts;
using WebApplication1.Repositories;

namespace WebApplication1.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<int, CustomerResponseContract> _customers
        = new();

    public List<CustomerResponseContract> GetAll()
    {
        return _customers.Values.ToList();
    }

    public CustomerResponseContract Get(int id)
    {
        return _customers[id];
    }

    public void Delete(int id)
    {
        _customers.Remove(id);
    }

    public CustomerResponseContract Create(CustomerRequestContract customer)
    {
        var customerToStore = customer.Map();

        var id = _customers.Keys.Any() ? _customers.Keys.Max() + 1 : 1;
        customerToStore.Id = id;

        _customers.Add(id, customerToStore);

        return _customers[id];
    }

    public void Update(CustomerRequestContract customer, int id)
    {
        var customerToStore = customer.Map();
        customerToStore.Id = id;

        _customers[id] = customerToStore;
    }
}