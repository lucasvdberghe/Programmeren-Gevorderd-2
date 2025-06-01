using System;
using System.Collections.Generic;

namespace Treinoef.Services.Models;

public class Subscription
{
    public int SubscriptionId { get; set; }
    public Customer Customer { get; set; }
    public int? CustomerId => Customer?.CustomerId;
    public Station Station1 { get; set; }
    public int? Station1Id => Station1?.StationId;
    public Station Station2 { get; set; }
    public int? Station2Id => Station2?.StationId;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public int ComfortLevel { get; set; }
}
