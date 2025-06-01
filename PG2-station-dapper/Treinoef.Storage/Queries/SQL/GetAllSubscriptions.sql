select s.SubscriptionId, s.ValidFrom, s.ValidUntil, s.ComfortLevel, 
c.CustomerId, c.FirstName, c.LastName, c.Email, 
s1.StationId, s1.Name, s1.HeatedWaitingArea, 
s2.StationId, s2.Name, s2.HeatedWaitingArea
from Subscriptions s
inner join Customers c on s.CustomerId = c.CustomerId
inner join 