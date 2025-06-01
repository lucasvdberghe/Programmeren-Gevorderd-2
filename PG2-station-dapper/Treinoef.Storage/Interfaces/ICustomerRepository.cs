using System;
using Treinoef.Services.Models;

namespace Treinoef.Storage.Interfaces;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer? GetById(int id);
    Customer Create(Customer customer);
}
