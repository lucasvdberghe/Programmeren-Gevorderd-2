create table Customers (
Id int not null auto_increment primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
DateOfBirth date not null,
Email varchar(200) not null,
TaxIdentificationNumber varchar(20) null,
AddressLine1 varchar(50) not null,
AddressLine2 varchar(50) not null,
AddressLine3 varchar(50) null,
Country varchar(20) not null);

create table Products (
Id int not null auto_increment primary key,
Name varchar(30) not null,
Description varchar(300) not null,
Price float not null,
AgeRating int not null,
StockCount int not null
);

alter table Products
add constraint CK_Products_Price_Min0_Max10000
check (Price >= 0 && Price <= 10000);

alter table Products
add constraint CK_Products_AgeRating_Min0_Max21
check (AgeRating >= 0 && AgeRating <= 21);

alter table Products
add constraint CK_Products_StockCount_Min0_Max100000
check (StockCount >= 0 && StockCount <= 100000);

create table Orders (
Id int not null auto_increment primary key,
CustomerId int not null,
FirstNameAtOrder varchar(30) not null,
EmailAtOrder varchar(200) not null,
CountryAtOrder varchar(20) not null);

alter table Orders
add constraint FK_Orders_Customers_CustomerId
foreign key (CustomerId)
references Customers(Id);

create table OrderProducts (
OrderId int not null,
ProductId int not null,
ProductNameAtOrder varchar(30) not null,
ProductPriceAtOrder float not null,
Quantity int not null
);

alter table OrderProducts
add constraint PK_OrderProducts_OrderIdProductId
primary key (OrderId, ProductId);

alter table OrderProducts
add constraint FK_OrderProducts_Orders_OrderId
foreign key (OrderId)
references Orders(Id);

alter table OrderProducts
add constraint FK_OrderProducts_Products_ProductId
foreign key (ProductId)
references Products(Id);

alter table OrderProducts
add constraint CK_OrderProducts_ProductPriceAtOrder_Min0_Max10000
check (ProductPriceAtOrder >= 0 and ProductPriceAtOrder <= 10000);

alter table OrderProducts
add constraint CK_OrderProducts_Quantity_Min1_Max100000
check (Quantity > 0 and Quantity <= 100000);