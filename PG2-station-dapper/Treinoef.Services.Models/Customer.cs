using System;
using System.Collections.Generic;

namespace Treinoef.Services.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
