using System;
using WebApplication1.Contracts;

namespace WebApplication1.Repositories;

public static class MappingExtensions
{
    public static CustomerResponseContract Map(this CustomerRequestContract customer)
    {
        return new CustomerResponseContract()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
            TaxIdentificationNumber = customer.TaxIdentificationNumber,
            Addressline1 = customer.Addressline1,
            Addressline2 = customer.Addressline2,
            Addressline3 = customer.Addressline3,
            Country = customer.Country
        };
    }
}
