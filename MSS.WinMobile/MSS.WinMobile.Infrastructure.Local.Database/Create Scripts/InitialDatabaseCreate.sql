Create Table Customers(
	Id int primary key,
	Name nvarchar(255)
)

Create Table Managers(
	Id int primary key,
	Name nvarchar(255)
)

Create Table Products(
	Id int primary key,
	Name nvarchar(255),
	Price decimal(18,2)
)

Create Table Routes(
	Id int primary key,
	Date datetime,
	Manager_Id int references Managers
)

Create Table Statuses(
	Id int primary key,
	Name nvarchar(255)
)

Create Table ShippingAddresses(
	Id int primary key,
	Address nvarchar(255),
	Name nvarchar(255),
	Customer_Id int references Customers
)

Create Table RoutePoints(
	Id int primary key,
	Route_Id int references Routes,
	ShippingAddress_Id int references ShippingAddresses,
	Status_Id int references Statuses
)

Create Table Orders(
	Id int primary key,
	Date datetime,
	ShippingAddress_Id int references ShippingAddresses,
	Manager_Id int references Managers
)

Create Table OrderItems(
	Id int primary key,
	Order_Id int references Orders,
	Product_Id int references Products,
	Quantity decimal(18,2)
)
 