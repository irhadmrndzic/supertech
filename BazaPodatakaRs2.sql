CREATE TABLE Cities(
	CityId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	ZipCode nvarchar (50) NOT NULL,

	PRIMARY KEY (CityId)
);

CREATE TABLE Users(
	UserId INT IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	DateOfBirth datetime NOT NULL,
	DateOfEmployment date,
	RegistrationDate date NOT NULL,
	UserName nvarchar(50) NOT NULL UNIQUE,
	Email nvarchar(100) NOT NULL UNIQUE,
	PasswordHash nvarchar(max) NOT NULL,
	PasswordSalt nvarchar(max) NOT NULL,
	PhoneNumber nvarchar(50) NOT NULL,
	Gender nvarchar(20) NOT NULL,
	Address nvarchar(150) NOT NULL,
	Active bit NOT NULL,
	PRIMARY KEY(UserId),

	FK_CityId INT FOREIGN KEY REFERENCES Cities(CityId)
);


CREATE TABLE Roles(
	RoleId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(80),
	PRIMARY KEY (RoleId)
);


CREATE TABLE UsersRoles(
	UserRoleId INT IDENTITY(1,1) NOT NULL,
	DateOfModification datetime NOT NULL,
	PRIMARY KEY (UserRoleId),
	
	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),
	FK_RoleId INT FOREIGN KEY REFERENCES Roles(RoleId)
);


CREATE TABLE News(
	NewsId INT IDENTITY(1,1) NOT NULL,
	Title nvarchar(100),
	Content nvarchar(1000) NOT NULL,
	DateOfCreation date NOT NULL,
	Active bit NOT NULL,
	PRIMARY KEY (NewsId),

	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),

);

CREATE TABLE UnitsOfMeasure(
	UnitOfMeasureId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(100),
	PRIMARY KEY(UnitOfMeasureId)
);


CREATE TABLE Categories(
	CategoryId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(100),
	PRIMARY KEY(CategoryId)
);

CREATE TABLE Products(
	ProductId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(100),
	Code nvarchar(30) NOT NULL,
	Price decimal(18,2) NOT NULL,
	Active bit NOT NULL,
	Image varbinary(max),
	ImageThumb varbinary(max),

	PRIMARY KEY(ProductId),

	FK_UnitOfMeasureId INT FOREIGN KEY REFERENCES UnitsOfMeasure(UnitOfMeasureId),
	FK_CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
);



CREATE TABLE Ratings(
	RatingId INT IDENTITY(1,1) NOT NULL,
	Date date,
	Rating int,
	PRIMARY KEY(RatingId),

	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),
	FK_ProductId INT FOREIGN KEY REFERENCES Products(ProductId)
);


CREATE TABLE Offers(
	OfferId INT IDENTITY(1,1) NOT NULL,
	Title nvarchar(100),
	Description nvarchar(1000),
	DateFrom date,
	DateTo date
	PRIMARY KEY(OfferId)
);


CREATE TABLE ProductOffers(
	ProductOfferId INT IDENTITY(1,1) NOT NULL,
	Discount decimal(18,2),
	PriceWithDiscount decimal(18,2),
	PRIMARY KEY(ProductOfferId),

	FK_ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	FK_OfferId INT FOREIGN KEY REFERENCES Offers(OfferId)

);

CREATE TABLE BuyerOrders(
	BuyerOrderId INT IDENTITY(1,1) NOT NULL,
	Date datetime NOT NULL,
	Active bit NOT NULL,
	Canceled bit NOT NULL,
	PRIMARY KEY(BuyerOrderId),

	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),
);

CREATE TABLE BuyerOrderItems(
	BuyerOrderItemsId INT IDENTITY(1,1) NOT NULL,
	Quantity int,
	PRIMARY KEY(BuyerOrderItemsId),

	FK_ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
	FK_BuyerOrder INT FOREIGN KEY REFERENCES BuyerOrders(BuyerOrderId),

);



CREATE TABLE Bills(
	BillId INT IDENTITY(1,1) NOT NULL,
	BillNumber int NOT NULL,
	IssuingDate date NOT NULL,
	Closed bit NOT NULL,
	Tax decimal(18,2) NOT NULL,
	Amount decimal(18,2) NOT NULL,
	AmountWithTax decimal(18,2) NOT NULL,
	PRIMARY KEY(BillId),
	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),
	FK_BuyerOrder INT FOREIGN KEY REFERENCES BuyerOrders(BuyerOrderId),

);

CREATE TABLE BillItems(
	BillItemId INT IDENTITY(1,1) NOT NULL,
	Price decimal(18,2) NOT NULL,
	Discount decimal(18,2),
	Quantity int NOT NULL,

	PRIMARY KEY(BillItemId),
	FK_BillId INT FOREIGN KEY REFERENCES Bills(BillId),
	FK_ProductId INT FOREIGN KEY REFERENCES Products(ProductId)


);

CREATE TABLE Suppliers(
	SupplierId INT IDENTITY(1,1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Email nvarchar(100) NOT NULL,
	PhoneNumber nvarchar(100) NOT NULL,
	WebAddress nvarchar(50),
	BankAccount nvarchar(150) NOT NULL,
	Description nvarchar(200),
	Active bit NOT NULL,
	PRIMARY KEY(SupplierId)
);


CREATE TABLE Orders(
	OrderId INT IDENTITY(1,1) NOT NULL,
	OrderNumber int NOT NULL,
	Date datetime NOT NULL,
	Active bit NOT NULL,
	Amount decimal(18,2) NOT NULL,
	PRIMARY KEY(OrderId),
	FK_UserId INT FOREIGN KEY REFERENCES Users(UserId),
	FK_SupplierId INT FOREIGN KEY REFERENCES Suppliers(SupplierId)

);


CREATE TABLE OrderItems(
	OrderItemId INT IDENTITY(1,1) NOT NULL,
	Quantity int,
	Amount decimal(18,2),
	PRIMARY KEY(OrderItemId),
	FK_OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	FK_ProductId INT FOREIGN KEY REFERENCES Products(ProductId),

);



