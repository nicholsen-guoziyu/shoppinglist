USE [master]
GO
/****** Object:  Database [ShoppingList]    Script Date: 15/04/2020 10:27:58 pm ******/
CREATE DATABASE [ShoppingList]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingList', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShoppingList.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShoppingList_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShoppingList_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShoppingList] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingList].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingList] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingList] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingList] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingList] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingList] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingList] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShoppingList] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingList] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingList] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingList] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingList] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingList] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingList] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingList] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingList] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShoppingList] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingList] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingList] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingList] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingList] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingList] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShoppingList] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingList] SET RECOVERY FULL 
GO
ALTER DATABASE [ShoppingList] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingList] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingList] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingList] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingList] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShoppingList] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShoppingList', N'ON'
GO
ALTER DATABASE [ShoppingList] SET QUERY_STORE = OFF
GO
USE [ShoppingList]
GO
/****** Object:  Table [dbo].[Shopping]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ShoppingDate] [datetime2](7) NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingItem]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ShoppingId] [bigint] NOT NULL,
	[Store] [varchar](50) NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[ItemBrand] [varchar](50) NOT NULL,
	[ItemQuantity] [decimal](18, 0) NOT NULL,
	[ItemPrice] [decimal](18, 0) NOT NULL,
	[ItemPriority] [int] NOT NULL,
	[ItemStatus] [int] NOT NULL,
	[ItemRemark] [varchar](255) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [bigint] NOT NULL,
	[ModifiedOnUtc] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingItemImage]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingItemImage](
	[Id] [bigint] NOT NULL,
	[ShoppingItemId] [bigint] NOT NULL,
	[ImageName] [varchar](255) NOT NULL,
	[ImageFile] [varbinary](max) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccess]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccess](
	[UserId] [bigint] NOT NULL,
	[AuthorizedUserId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserShopping]    Script Date: 15/04/2020 10:27:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShopping](
	[UserId] [bigint] NOT NULL,
	[ShoppingListId] [bigint] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ShoppingList] SET  READ_WRITE 
GO
