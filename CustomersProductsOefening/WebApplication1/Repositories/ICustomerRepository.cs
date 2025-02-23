using System;
using WebApplication1.Contracts;

namespace WebApplication1.Repositories;

public interface ICustomerRepository
{
    List<CustomerResponseContract> GetAll();
    CustomerResponseContract Get(int id);
    void Delete(int id);
    CustomerResponseContract Create(CustomerRequestContract customer);
    void Update(CustomerRequestContract customer, int id);
}
