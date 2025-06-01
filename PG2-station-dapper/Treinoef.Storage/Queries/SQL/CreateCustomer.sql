insert into Customers (FirstName, LastName, Email)
output inserted.CustomerId
values (@FirstName, @LastName, @Email)