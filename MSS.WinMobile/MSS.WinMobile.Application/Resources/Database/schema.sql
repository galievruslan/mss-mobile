CREATE TABLE [Categories] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
, [Parent_Id] INTEGER  NULL
, FOREIGN KEY(Parent_Id) REFERENCES Categories(Id)
);
CREATE TABLE [Customers] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
);
CREATE TABLE [ShippingAddresses] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Address] VARCHAR(255) NULL COLLATE NOCASE
, [Name] VARCHAR(255) NULL COLLATE NOCASE
, [Customer_Id] INTEGER  NULL
, FOREIGN KEY(Customer_Id) REFERENCES Customers(Id)
);
CREATE TABLE [Products] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
, [Category_Id] INTEGER  NULL
);
CREATE TABLE [UnitsOfMeasure] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
);
CREATE TABLE [PriceLists] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
);
CREATE TABLE [Warehouses] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
, [Address] VARCHAR(255) NULL COLLATE NOCASE
, [Default] BIT NULL
);
CREATE TABLE [Statuses] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Name] VARCHAR(255) NULL COLLATE NOCASE
);
CREATE TABLE [Orders] ([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
, [RoutePoint_Id] INTEGER NULL
, [OrderDate] DATETIME  NULL
, [ShippingDate] DATETIME  NULL
, [ShippingAddress_Id] INTEGER  NULL
, [PriceList_Id] INTEGER  NULL
, [Warehouse_Id] INTEGER  NULL
, [Amount] numeric(8,2) NULL
, [OrderStatus] INTEGER  NULL
, [Note] VARCHAR(1024) NULL COLLATE NOCASE
, [Synchronized] BIT  NULL
, FOREIGN KEY(RoutePoint_Id) REFERENCES RoutePoints(Id)
, FOREIGN KEY(ShippingAddress_Id) REFERENCES ShippingAddresses(Id)
, FOREIGN KEY(PriceList_Id) REFERENCES PriceLists(Id)
, FOREIGN KEY(Warehouse_Id) REFERENCES Warehouses(Id)
);
CREATE TABLE [OrderItems] ([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
, [Quantity] INTEGER  NULL
, [Price] numeric(8,2) NULL
, [Amount] numeric(8,2) NULL
, [Order_Id] INTEGER NULL
, [Product_Id] INTEGER  NULL
, [UnitOfMeasure_Id] INTEGER  NULL
, FOREIGN KEY(Order_Id) REFERENCES Orders(Id)
, FOREIGN KEY(Product_Id) REFERENCES Products(Id)
);
CREATE TABLE [ProductsPrices] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Price] numeric(8,2) NULL
, [Product_Id] INTEGER  NULL
, [PriceList_Id] INTEGER  NULL
, FOREIGN KEY(Product_Id) REFERENCES Products(Id)
, FOREIGN KEY(PriceList_Id) REFERENCES PriceLists(Id)
);
CREATE INDEX 'fk_ProductsPrices_Product_Id' ON 'ProductsPrices' ('Product_Id' ASC);
CREATE TABLE [ProductsUnitOfMeasures] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [Base] BIT  NULL
, [Product_Id] INTEGER  NULL
, [UnitOfMeasure_Id] INTEGER  NULL
, [Count_In_Base_Unit] FLOAT  NULL
, FOREIGN KEY(Product_Id) REFERENCES Products(Id)
, FOREIGN KEY(UnitOfMeasure_Id) REFERENCES UnitsOfMeasure(Id)
);
CREATE INDEX 'fk_ProductsUnitOfMeasures_UnitOfMeasure_Id' ON 'ProductsUnitOfMeasures' ('UnitOfMeasure_Id' ASC);
CREATE TABLE [Routes] ([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
, [Date] DATETIME  NULL
);
CREATE TABLE [RoutePoints] ([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
, [Route_Id] INTEGER NULL
, [ShippingAddress_Id] INTEGER NULL
, [ShippingAddress_Name] VARCHAR(255) NULL COLLATE NOCASE
, [ShippingAddress_Address] VARCHAR(255) NULL COLLATE NOCASE
, [Status_Id] INTEGER  NULL
, [Status_Name] VARCHAR(255) NULL COLLATE NOCASE
, [Synchronized] BIT  NULL
, FOREIGN KEY(Route_Id) REFERENCES Routes(Id)
, FOREIGN KEY(ShippingAddress_Id) REFERENCES ShippingAddresses(Id)
, FOREIGN KEY(Status_Id) REFERENCES Statuses(Id)
);
CREATE TABLE [RouteTemplates] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [DayOfWeek] INTEGER  NULL
);
CREATE TABLE [RoutePointTemplates] ([Id] INTEGER  NOT NULL PRIMARY KEY
, [RouteTemplate_Id] INTEGER  NULL
, [ShippingAddress_Id] INTEGER  NULL
, FOREIGN KEY(RouteTemplate_Id) REFERENCES RouteTemplates(Id)
, FOREIGN KEY(ShippingAddress_Id) REFERENCES ShippingAddresses(Id)
);