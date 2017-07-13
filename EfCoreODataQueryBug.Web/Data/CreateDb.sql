create table Customers(
	CustomerId int not null primary key,
	Name nvarchar(255) not null,
	CustomerSince DateTimeOffset not null,
	IsActive bit not null default(1)
)