using System;
using System.ComponentModel.DataAnnotations;

namespace Treinoef.Api.Contracts.Customers;

public class CustomerRequestContract
{
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
}
