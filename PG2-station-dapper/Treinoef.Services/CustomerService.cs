using System;
using Treinoef.Api.Contracts.Customers;
using Treinoef.Services.Interfaces;
using Treinoef.Services.Mapping;
using Treinoef.Storage;
using Treinoef.Storage.Interfaces;

namespace Treinoef.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public IEnumerable<CustomerResponseContract> GetAll()
    {
        return customerRepository.GetAll().Select(c => c.AsContract()).ToList();
    }

    public CustomerResponseContract? Get(int id)
    {
        var customer = customerRepository.GetById(id);

        return customer?.AsContract();
    }

    public CustomerResponseContract Create(CustomerRequestContract customerRequestContract)
    {
        var createdCustomer = customerRequestContract.AsModel();

        var createdCustomerId = customerRepository.Create(createdCustomer); // Of is het de verantwoordelijkheid van de repository om de aangemaakte Customer terug te geven?

        return Get(createdCustomerId);
    }
}
