using System;

namespace Treinoef.Api.Contracts.Customers;

public class CustomerResponseContract
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}