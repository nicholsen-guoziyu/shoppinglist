USE [ShoppingList]
GO

INSERT INTO [dbo].[Shopping]
           ([UserId]
           ,[ShoppingDate]
           ,[CreatedOnUtc])
     VALUES
           (1
           ,CAST (GETDATE() AS DATE)
           ,GETDATE())
GO

INSERT INTO [dbo].[ShoppingItem]
           ([ShoppingId]
           ,[Store]
           ,[ItemName]
           ,[ItemBrand]
           ,[ItemQuantity]
           ,[ItemPrice]
           ,[ItemPriority]
           ,[ItemStatus]
           ,[ItemRemark]
           ,[CreatedBy]
           ,[CreatedOnUtc]
           ,[ModifiedBy]
           ,[ModifiedOnUtc])
     VALUES
           (1
           ,'Countdown'
           ,'Rice'
           ,'Wonder Rose'
           ,1
           ,5.00
           ,1
           ,1
           ,'Rice'
           ,1
           ,CAST (GETDATE() AS DATE)
           ,1
           ,CAST (GETDATE() AS DATE))
GO



USE [ShoppingList]
GO

INSERT INTO [dbo].[ShoppingItemImage]
           ([ShoppingItemId]
           ,[ImageName]
           ,[ImageFile]
           ,[CreatedBy]
           ,[CreatedOnUtc])
     VALUES
           (1
           ,'Test1.jpg'
           ,CAST('Test1' AS VARBINARY(MAX))
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ShoppingItemImage]
           ([ShoppingItemId]
           ,[ImageName]
           ,[ImageFile]
           ,[CreatedBy]
           ,[CreatedOnUtc])
     VALUES
           (1
           ,'Test2.jpg'
           ,CAST('Test2' AS VARBINARY(MAX))
           ,1
           ,GETDATE())
GO


