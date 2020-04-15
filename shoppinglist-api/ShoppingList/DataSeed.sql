USE [ShoppingList]
GO

INSERT INTO [dbo].[Shopping]
           ([UserId]
           ,[ShoppingDate]
           ,[CreatedOnUtc])
     VALUES
           (1
           ,'2020-04-16 00:00:00.0000000'
           ,'2020-04-16 00:00:00.0000000')
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
           ,GETDATE()
           ,1
           ,GETDATE())
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


