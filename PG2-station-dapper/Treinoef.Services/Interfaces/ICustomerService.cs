using System;
using Treinoef.Api.Contracts.Customers;

namespace Treinoef.Services.Interfaces;

public interface ICustomerService
{
    IEnumerable<CustomerResponseContract> GetAll();
    CustomerResponseContract? Get(int id);
    CustomerResponseContract Create(CustomerRequestContract customerRequestContract);
}
