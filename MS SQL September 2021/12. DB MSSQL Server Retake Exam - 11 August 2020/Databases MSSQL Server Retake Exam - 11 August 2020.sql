/***** Databases MSSQL Server Retake Exam - 11 August 2020 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Bakery]
GO

USE [Bakery]
GO

CREATE TABLE [Countries](
	[Id]    INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(50) UNIQUE      NOT NULL
)

CREATE TABLE [Customers](
	[Id]           INT PRIMARY KEY IDENTITY                     NOT NULL
	,[FirstName]   NVARCHAR(25)                                 NOT NULL
	,[LastName]    NVARCHAR(25)                                 NOT NULL
	,[Gender]      CHAR(1)                                      NOT NULL
	,[Age]         INT                                          NOT NULL
	,[PhoneNumber] CHAR(10)                                     NOT NULL
	,[CountryId]   INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
	,CHECK ([Gender] IN ('M', 'F'))
	,CHECK ([Age] > 0)
	,CHECK (LEN([PhoneNumber]) = 10)
)

CREATE TABLE [Products](
	[Id]           INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]        NVARCHAR(25) UNIQUE      NOT NULL
	,[Description] NVARCHAR(250)
	,[Recipe]      NVARCHAR(MAX)            NOT NULL
	,[Price]       DECIMAL(15,2)            NOT NULL
	,CHECK ([Price] >= 0)
)

CREATE TABLE [Feedbacks](
	[Id]           INT PRIMARY KEY IDENTITY                     NOT NULL
	,[Description] NVARCHAR(255)
	,[Rate]        DECIMAL(4,2)                                 NOT NULL
	,[ProductId]   INT FOREIGN KEY REFERENCES [Products]([Id])  NOT NULL
	,[CustomerId]  INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL
	,CHECK ([Rate] BETWEEN 0 AND 10)
)

CREATE TABLE [Distributors](
	[Id]           INT PRIMARY KEY IDENTITY                     NOT NULL 
	,[Name]        NVARCHAR(25) UNIQUE                          NOT NULL
	,[AddressText] NVARCHAR(30)                                 NOT NULL
	,[Summary]     NVARCHAR(200)                                NOT NULL
	,[CountryId]   INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Ingredients](
	[Id]               INT PRIMARY KEY IDENTITY                        NOT NULL
	,[Name]            NVARCHAR(30)                                    NOT NULL
	,[Description]     NVARCHAR(200)
	,[OriginCountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])    NOT NULL
	,[DistributorId]   INT FOREIGN KEY REFERENCES [Distributors]([Id]) NOT NULL
)

CREATE TABLE [ProductsIngredients](
	[ProductId]     INT FOREIGN KEY REFERENCES [Products]([Id])    NOT NULL
	,[IngredientId] INT FOREIGN KEY REFERENCES [Ingredients]([Id]) NOT NULL
	,PRIMARY KEY([ProductId],[IngredientId])
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Distributors]([Name], [CountryId], [AddressText], [Summary])
     VALUES ('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling')
            ,('Congress Title', 13, '58 Hancock St', 'Customer loyalty')
            ,('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery')
            ,('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group')
            ,('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO [Customers]([FirstName], [LastName], [Age], [Gender], [PhoneNumber], [CountryId])
     VALUES ('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5)
            ,('Kendra', 'Loud', 22, 'F', '0063631526', 11)
            ,('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8)
            ,('Hannah', 'Edmison', 18, 'F', '0043343686', 1)
            ,('Tom', 'Loeza', 31, 'M', '0144876096', 23)
            ,('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29)
            ,('Hiu', 'Portaro', 25, 'M', '0068277755', 16)
            ,('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Ingredients]
   SET [DistributorId] = 35
 WHERE [Name] IN ('Bay Leaf', 'Paprika','Poppy')

 UPDATE [Ingredients]
   SET [OriginCountryId] = 14
 WHERE [OriginCountryId] = 8

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [Feedbacks]
      WHERE [CustomerId] = 14 OR [ProductId] = 5

---------------------------------------------------------------------------------------------------
-- 5 TASK Products By Price -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [Name]
         ,[Price]
		 ,[Description]
    FROM [Products]
ORDER BY [Price] DESC
         ,[Name]

---------------------------------------------------------------------------------------------------
-- 6 TASK Negative Feedback -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT f.[ProductId]
         ,f.[Rate]
		 ,f.[Description]
		 ,f.[CustomerId]   
		 ,c.[Age]
		 ,c.[Gender]
    FROM [Feedbacks] AS f
    JOIN [Customers] AS c ON f.[CustomerId] = c.[Id]
   WHERE f.[Rate] < 5.0
ORDER BY f.[ProductId] DESC
         ,f.[Rate]

---------------------------------------------------------------------------------------------------
-- 7 TASK Customers without Feedback --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT([FirstName], ' ', [LastName]) AS [CustomerName]
         ,[PhoneNumber]
	     ,[Gender]
    FROM [Customers]
   WHERE [Id] NOT IN (SELECT [CustomerId] FROM [Feedbacks])
ORDER BY [Id]

---------------------------------------------------------------------------------------------------
-- 8 TASK Customers by Criteria -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [FirstName]
         ,[Age]
		 ,[PhoneNumber]
    FROM [Customers]
   WHERE ([Age] >= 21 AND [FirstName] LIKE ('%an%'))
         OR ([PhoneNumber] LIKE ('%38') AND [CountryId] NOT IN (SELECT [Id] 
		                                                          FROM [Countries] 
																 WHERE [Name] IN ('Greece')))
ORDER BY [FirstName]
         ,[Age] DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Middle Range Distributors ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
 SELECT d.[Name]     AS [DistributorName]
        ,i.[Name]    AS [IngredientName] 
		,p.[Name]    AS [ProductName]
		,AVG(f.Rate) AS [AverageRate]
   FROM [Distributors]        AS d
   JOIN [Ingredients]         AS i   ON d.[Id] = i.[DistributorId]
   JOIN [ProductsIngredients] AS pri ON i.[Id] = pri.IngredientId
   JOIN [Products]            AS p   ON pri.[ProductId] = p.[Id]
   JOIN [Feedbacks]           AS f   ON p.[Id] = f.[ProductId]
  WHERE p.[Id] IN (  SELECT p.[Id]		                   
		               FROM [Products]  AS p
		               JOIN [Feedbacks] AS f ON p.[Id] = f.[ProductId]
		           GROUP BY p.[Id], p.[Name]
		             HAVING AVG(f.Rate) BETWEEN 5 AND 8)
GROUP BY d.[Name], i.[Name], p.[Name] 					 
ORDER BY [DistributorName], [IngredientName], [ProductName]

--2
  SELECT d.[Name]     AS [DistributorName]
         ,i.[Name]    AS [IngredientName] 
 		 ,p.[Name]    AS [ProductName]
 		 ,AVG(f.Rate) AS [AverageRate]
    FROM [Distributors]        AS d
    JOIN [Ingredients]         AS i   ON d.[Id] = i.[DistributorId]
    JOIN [ProductsIngredients] AS pri ON i.[Id] = pri.IngredientId
    JOIN [Products]            AS p   ON pri.[ProductId] = p.[Id]
    JOIN [Feedbacks]           AS f   ON p.[Id] = f.[ProductId]
GROUP BY d.[Name], i.[Name], p.[Name] 
  HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY [DistributorName], [IngredientName], [ProductName]
 
---------------------------------------------------------------------------------------------------
-- 10 TASK Country Representative -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [RankingSubquery].[CountryName]
         ,[RankingSubquery].[DisributorName]
    FROM (   SELECT c.[Name]                                                         AS [CountryName]
                    ,d.[Name]	                                                     AS [DisributorName]	  
                    ,RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.[Id]) DESC) AS [Rank]
               FROM [Distributors] AS d
          LEFT JOIN [Ingredients]  AS i ON d.[Id] = i.[DistributorId]
          LEFT JOIN [Countries]    AS c ON d.[CountryId] = c.[Id]
           GROUP BY c.[Name], d.[Name]
	     ) AS [RankingSubquery]
   WHERE [Rank] = 1
ORDER BY [CountryName], [DisributorName]

---------------------------------------------------------------------------------------------------
-- 11 TASK Customers With Countries ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE VIEW v_UserWithCountries
AS 
SELECT CONCAT(cu.[FirstName], ' ', cu.[LastName]) AS [CustomerName]
       ,cu.[Age]
	   ,cu.[Gender]
	   ,c.[Name]   AS [CountryName]
  FROM [Customers] AS cu
  JOIN [Countries] AS c  ON cu.[CountryId] = c.[Id]
GO

  SELECT TOP(5) *
    FROM [v_UserWithCountries]
ORDER BY [Age]

---------------------------------------------------------------------------------------------------
-- 12 TASK Delete Products ------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------- 
CREATE TRIGGER tr_DeleteProducts
ON [Products] instead of DELETE
AS
BEGIN
    DECLARE @productToDelete INT = (SELECT p.[Id] 
                                     FROM [Products] AS p
									 JOIN  deleted AS d ON p.[Id] = d.[Id])
DELETE FROM [Feedbacks]
      WHERE [ProductId] = @productToDelete

DELETE FROM [ProductsIngredients]
      WHERE [ProductId] = @productToDelete

DELETE FROM [Products]
      WHERE [Id] = @productToDelete

END

DELETE FROM [Products] 
      WHERE [Id] = 7


SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_CATALOG = DB_NAME()