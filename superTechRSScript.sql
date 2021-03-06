USE [master]
GO
/****** Object:  Database [superTechRS]    Script Date: 2.9.2021. 23:33:01 ******/
CREATE DATABASE [superTechRS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'superTechRS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\superTechRS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'superTechRS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\superTechRS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [superTechRS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [superTechRS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [superTechRS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [superTechRS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [superTechRS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [superTechRS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [superTechRS] SET ARITHABORT OFF 
GO
ALTER DATABASE [superTechRS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [superTechRS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [superTechRS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [superTechRS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [superTechRS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [superTechRS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [superTechRS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [superTechRS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [superTechRS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [superTechRS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [superTechRS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [superTechRS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [superTechRS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [superTechRS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [superTechRS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [superTechRS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [superTechRS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [superTechRS] SET RECOVERY FULL 
GO
ALTER DATABASE [superTechRS] SET  MULTI_USER 
GO
ALTER DATABASE [superTechRS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [superTechRS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [superTechRS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [superTechRS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [superTechRS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [superTechRS] SET QUERY_STORE = OFF
GO
USE [superTechRS]
GO
/****** Object:  User [NT Service\MSSQLSERVER]    Script Date: 2.9.2021. 23:33:01 ******/
CREATE USER [NT Service\MSSQLSERVER] FOR LOGIN [NT Service\MSSQLSERVER] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 2.9.2021. 23:33:01 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Irhad\Irhad]    Script Date: 2.9.2021. 23:33:01 ******/
CREATE USER [Irhad\Irhad] FOR LOGIN [Irhad\Irhad] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Irhad\Irhad]
GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[BillItemId] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[FK_BillId] [int] NULL,
	[FK_ProductId] [int] NULL,
 CONSTRAINT [PK_BillItems] PRIMARY KEY CLUSTERED 
(
	[BillItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [int] NOT NULL,
	[IssuingDate] [date] NOT NULL,
	[Closed] [bit] NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[AmountWithTax] [decimal](18, 2) NOT NULL,
	[FK_UserId] [int] NULL,
	[FK_BuyerOrder] [int] NULL,
 CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[WebAddress] [nvarchar](150) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyerOrderItems]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyerOrderItems](
	[BuyerOrderItemsId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[FK_ProductId] [int] NULL,
	[FK_BuyerOrder] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK__BuyerOrd__8E1D118BEDBD0F49] PRIMARY KEY CLUSTERED 
(
	[BuyerOrderItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyerOrders]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyerOrders](
	[BuyerOrderId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[Canceled] [bit] NOT NULL,
	[FK_UserId] [int] NULL,
	[OrderNumber] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Confirmed] [bit] NULL,
 CONSTRAINT [PK_BuyerOrders] PRIMARY KEY CLUSTERED 
(
	[BuyerOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[DateOfCreation] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[FK_UserId] [int] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
	[DateFrom] [date] NULL,
	[DateTo] [date] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[FK_OrderId] [int] NULL,
	[FK_ProductId] [int] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NULL,
	[Date] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[FK_UserId] [int] NULL,
	[FK_SupplierId] [int] NULL,
	[Confirmed] [bit] NULL,
	[Canceled] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOffers]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOffers](
	[ProductOfferId] [int] IDENTITY(1,1) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[PriceWithDiscount] [decimal](18, 2) NULL,
	[FK_ProductId] [int] NULL,
	[FK_OfferId] [int] NULL,
 CONSTRAINT [PK_ProductOffers] PRIMARY KEY CLUSTERED 
(
	[ProductOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Active] [bit] NOT NULL,
	[Image] [varbinary](max) NULL,
	[ImageThumb] [varbinary](max) NULL,
	[FK_UnitOfMeasureId] [int] NULL,
	[FK_CategoryId] [int] NULL,
	[BrandId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Rating] [int] NULL,
	[FK_UserId] [int] NULL,
	[FK_ProductId] [int] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](80) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](100) NOT NULL,
	[WebAddress] [nvarchar](50) NULL,
	[BankAccount] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitsOfMeasure]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitsOfMeasure](
	[UnitOfMeasureId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK__UnitsOfM__F36083F1EE73BD8B] PRIMARY KEY CLUSTERED 
(
	[UnitOfMeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[RegistrationDate] [date] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[PasswordSalt] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[FK_CityId] [int] NULL,
	[ProfilePicture] [varbinary](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 2.9.2021. 23:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[DateOfModification] [datetime] NOT NULL,
	[FK_UserId] [int] NULL,
	[FK_RoleId] [int] NULL,
 CONSTRAINT [PK__UsersRol__3D978A354EF9B121] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2.9.2021. 23:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillItems_FK_BillId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_BillItems_FK_BillId] ON [dbo].[BillItems]
(
	[FK_BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillItems_FK_ProductId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_BillItems_FK_ProductId] ON [dbo].[BillItems]
(
	[FK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bills_FK_BuyerOrder]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Bills_FK_BuyerOrder] ON [dbo].[Bills]
(
	[FK_BuyerOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bills_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Bills_FK_UserId] ON [dbo].[Bills]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuyerOrderItems_FK_BuyerOrder]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_BuyerOrderItems_FK_BuyerOrder] ON [dbo].[BuyerOrderItems]
(
	[FK_BuyerOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuyerOrderItems_FK_ProductId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_BuyerOrderItems_FK_ProductId] ON [dbo].[BuyerOrderItems]
(
	[FK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuyerOrders_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_BuyerOrders_FK_UserId] ON [dbo].[BuyerOrders]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_News_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_News_FK_UserId] ON [dbo].[News]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_FK_OrderId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_FK_OrderId] ON [dbo].[OrderItems]
(
	[FK_OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_FK_ProductId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_FK_ProductId] ON [dbo].[OrderItems]
(
	[FK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_FK_SupplierId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_FK_SupplierId] ON [dbo].[Orders]
(
	[FK_SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_FK_UserId] ON [dbo].[Orders]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOffers_FK_OfferId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_ProductOffers_FK_OfferId] ON [dbo].[ProductOffers]
(
	[FK_OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOffers_FK_ProductId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_ProductOffers_FK_ProductId] ON [dbo].[ProductOffers]
(
	[FK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [dbo].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_FK_CategoryId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Products_FK_CategoryId] ON [dbo].[Products]
(
	[FK_CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_FK_UnitOfMeasureId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Products_FK_UnitOfMeasureId] ON [dbo].[Products]
(
	[FK_UnitOfMeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_FK_ProductId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_FK_ProductId] ON [dbo].[Ratings]
(
	[FK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Ratings_FK_UserId] ON [dbo].[Ratings]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_FK_CityId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_Users_FK_CityId] ON [dbo].[Users]
(
	[FK_CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053469742187]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Users__A9D1053469742187] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__C9F28456803E0209]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Users__C9F28456803E0209] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersRoles_FK_RoleId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_UsersRoles_FK_RoleId] ON [dbo].[UsersRoles]
(
	[FK_RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersRoles_FK_UserId]    Script Date: 2.9.2021. 23:33:02 ******/
CREATE NONCLUSTERED INDEX [IX_UsersRoles_FK_UserId] ON [dbo].[UsersRoles]
(
	[FK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK__BillItems__FK_Bi__628FA481] FOREIGN KEY([FK_BillId])
REFERENCES [dbo].[Bills] ([BillId])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK__BillItems__FK_Bi__628FA481]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK__BillItems__FK_Pr__6383C8BA] FOREIGN KEY([FK_ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK__BillItems__FK_Pr__6383C8BA]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK__Bills__FK_BuyerO__5FB337D6] FOREIGN KEY([FK_BuyerOrder])
REFERENCES [dbo].[BuyerOrders] ([BuyerOrderId])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK__Bills__FK_BuyerO__5FB337D6]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK__Bills__FK_UserId__5EBF139D] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK__Bills__FK_UserId__5EBF139D]
GO
ALTER TABLE [dbo].[BuyerOrderItems]  WITH CHECK ADD  CONSTRAINT [FK__BuyerOrde__FK_Bu__5BE2A6F2] FOREIGN KEY([FK_BuyerOrder])
REFERENCES [dbo].[BuyerOrders] ([BuyerOrderId])
GO
ALTER TABLE [dbo].[BuyerOrderItems] CHECK CONSTRAINT [FK__BuyerOrde__FK_Bu__5BE2A6F2]
GO
ALTER TABLE [dbo].[BuyerOrderItems]  WITH CHECK ADD  CONSTRAINT [FK__BuyerOrde__FK_Pr__5AEE82B9] FOREIGN KEY([FK_ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[BuyerOrderItems] CHECK CONSTRAINT [FK__BuyerOrde__FK_Pr__5AEE82B9]
GO
ALTER TABLE [dbo].[BuyerOrders]  WITH CHECK ADD  CONSTRAINT [FK__BuyerOrde__FK_Us__5812160E] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[BuyerOrders] CHECK CONSTRAINT [FK__BuyerOrde__FK_Us__5812160E]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK__News__FK_UserId__440B1D61] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK__News__FK_UserId__440B1D61]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__FK_Or__6C190EBB] FOREIGN KEY([FK_OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK__OrderItem__FK_Or__6C190EBB]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__FK_Pr__6D0D32F4] FOREIGN KEY([FK_ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK__OrderItem__FK_Pr__6D0D32F4]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__FK_Suppl__693CA210] FOREIGN KEY([FK_SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__FK_Suppl__693CA210]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__FK_UserI__68487DD7] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__FK_UserI__68487DD7]
GO
ALTER TABLE [dbo].[ProductOffers]  WITH CHECK ADD  CONSTRAINT [FK__ProductOf__FK_Of__5535A963] FOREIGN KEY([FK_OfferId])
REFERENCES [dbo].[Offers] ([OfferId])
GO
ALTER TABLE [dbo].[ProductOffers] CHECK CONSTRAINT [FK__ProductOf__FK_Of__5535A963]
GO
ALTER TABLE [dbo].[ProductOffers]  WITH CHECK ADD  CONSTRAINT [FK__ProductOf__FK_Pr__5441852A] FOREIGN KEY([FK_ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductOffers] CHECK CONSTRAINT [FK__ProductOf__FK_Pr__5441852A]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__BrandI__160F4887] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__BrandI__160F4887]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__FK_Cat__4BAC3F29] FOREIGN KEY([FK_CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__FK_Cat__4BAC3F29]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__FK_Uni__4AB81AF0] FOREIGN KEY([FK_UnitOfMeasureId])
REFERENCES [dbo].[UnitsOfMeasure] ([UnitOfMeasureId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__FK_Uni__4AB81AF0]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK__Ratings__FK_Prod__4F7CD00D] FOREIGN KEY([FK_ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK__Ratings__FK_Prod__4F7CD00D]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK__Ratings__FK_User__4E88ABD4] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK__Ratings__FK_User__4E88ABD4]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__FK_CityId__3B75D760] FOREIGN KEY([FK_CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__FK_CityId__3B75D760]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK__UsersRole__FK_Ro__412EB0B6] FOREIGN KEY([FK_RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK__UsersRole__FK_Ro__412EB0B6]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK__UsersRole__FK_Us__403A8C7D] FOREIGN KEY([FK_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK__UsersRole__FK_Us__403A8C7D]
GO
USE [master]
GO
ALTER DATABASE [superTechRS] SET  READ_WRITE 
GO
