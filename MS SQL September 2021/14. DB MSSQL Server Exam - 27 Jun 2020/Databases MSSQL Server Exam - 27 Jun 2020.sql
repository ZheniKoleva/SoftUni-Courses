/***** Databases MSSQL Server Exam - 27 Jun 2020 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [WMS]
GO

USE [WMS]
GO

CREATE TABLE [Clients](
	[ClientId]   INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName] VARCHAR(50)              NOT NULL
	,[LastName]  VARCHAR(50)              NOT NULL
	,[Phone]     CHAR(12)                 NOT NULL
	,CHECK (LEN([Phone]) = 12)
)

CREATE TABLE [Mechanics](
	[MechanicId] INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName] VARCHAR(50)              NOT NULL
	,[LastName]  VARCHAR(50)              NOT NULL
	,[Address]   VARCHAR(255)             NOT NULL
)

CREATE TABLE [Models](
	[ModelId] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]   VARCHAR(50) UNIQUE       NOT NULL
)

CREATE TABLE [Jobs](
	[JobId]       INT PRIMARY KEY IDENTITY                             NOT NULL
	,[ModelId]    INT FOREIGN KEY REFERENCES [Models]([ModelId])       NOT NULL
	,[Status]     VARCHAR(11) DEFAULT('Pending')                       NOT NULL
	,[ClientId]   INT FOREIGN KEY REFERENCES [Clients]([ClientId])     NOT NULL
	,[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]) 
	,[IssueDate]  DATE                                                 NOT NULL
	,[FinishDate] DATE 
	,CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE [Orders](
	[OrderId]    INT PRIMARY KEY IDENTITY                   NOT NULL
	,[JobId]     INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL
	,[IssueDate] DATE 
	,[Delivered] BIT DEFAULT(0)                             NOT NULL
)

CREATE TABLE [Vendors](
	[VendorId] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]    VARCHAR(50) UNIQUE       NOT NULL
)

CREATE TABLE [Parts](
	[PartId]         INT PRIMARY KEY IDENTITY                         NOT NULL
	,[SerialNumber]  VARCHAR(50) UNIQUE                               NOT NULL
	,[Description]   VARCHAR(255)
	,[Price]         DECIMAL(6,2)                                     NOT NULL
	,[VendorId]      INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL
	,[StockQty]      INT DEFAULT(0)                                   NOT NULL
	,CHECK ([Price] > 0)
	,CHECK ([StockQty] >= 0)
)

CREATE TABLE [OrderParts](
	[OrderId]   INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL
	,[PartId]   INT FOREIGN KEY REFERENCES [Parts]([PartId])   NOT NULL
	,[Quantity] INT DEFAULT(1)                                 NOT NULL
	,CHECK ([Quantity] > 0)
	,PRIMARY KEY([OrderId], [PartId])
)

CREATE TABLE [PartsNeeded](
	[JobId]     INT FOREIGN KEY REFERENCES [Jobs]([JobId])   NOT NULL
	,[PartId]   INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL
	,[Quantity] INT DEFAULT(1)                               NOT NULL
	,CHECK ([Quantity] > 0)
	,PRIMARY KEY([JobId], [PartId])
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Clients]([FirstName], [LastName], [Phone])
     VALUES ('Teri', 'Ennaco', '570-889-5187')
            ,('Merlyn', 'Lawler', '201-588-7810')
            ,('Georgene', 'Montezuma', '925-615-5185')
            ,('Jettie', 'Mconnell', '908-802-3564')
            ,('Lemuel' ,'Latzke', '631-748-6479')
            ,('Melodie', 'Knipp', '805-690-1682')
            ,('Candida', 'Corbley','908-275-8357')
 
INSERT INTO [Parts]([SerialNumber], [Description], [Price], [VendorId])
     VALUES ('WP8182119', 'Door Boot Seal', 117.86, 2)
            ,('W10780048', 'Suspension Rod', 42.81, 1)
            ,('W10841140', 'Silicone Adhesive', 6.77, 4)
            ,('WPY055980', 'High Temperature Adhesive', 13.94, 3)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Jobs]
   SET [MechanicId] = 3
 WHERE [MechanicId] IS NULL
   
UPDATE [Jobs]
   SET [Status] = 'In Progress'
 WHERE [Status] = 'Pending'
  
---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [OrderParts]
      WHERE [OrderId] = 19

DELETE FROM [Orders]
      WHERE [OrderId] = 19

---------------------------------------------------------------------------------------------------
-- 5 TASK Mechanic Assignments --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT(m.[FirstName], ' ', m.[LastName])  AS [Mechanic]
         ,j.[Status]
	     ,j.[IssueDate]
    FROM [Mechanics] AS m
    JOIN [Jobs]      AS j ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId]
         ,j.[IssueDate]
		 ,j.[JobId]

---------------------------------------------------------------------------------------------------
-- 6 TASK Current Clients -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT(c.[FirstName], ' ', c.[LastName])         AS [Client]
         ,DATEDIFF(DAY, j.[IssueDate], '24 April 2017') AS [Days Going]
 		,j.[Status]
    FROM [Clients] AS c
    JOIN [Jobs]    AS j ON c.[ClientId] = j.[ClientId]
   WHERE j.[Status] NOT IN ('Finished')
ORDER BY [Days Going] DESC
         ,[Client]

---------------------------------------------------------------------------------------------------
-- 7 TASK Mechanic Performance --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [Mechanic]
         ,AVG([Days]) AS [Average Days]
    FROM (SELECT m.[MechanicId]                                AS [Id]
                 ,CONCAT(m.[FirstName], ' ', m.[LastName])     AS [Mechanic]
                 ,DATEDIFF(DAY, j.[IssueDate], j.[FinishDate]) AS [Days]
            FROM [Mechanics] AS m
            JOIN [Jobs]      AS j ON m.[MechanicId] = j.[MechanicId]
           WHERE j.[Status] IN ('Finished')
         ) AS [DaysSubquery]
GROUP BY [Id], [Mechanic]
ORDER BY [Id]

--------
  SELECT CONCAT(m.[FirstName],' ',m.[LastName])           AS  [Mechanic]
		 ,AVG(DATEDIFF(DAY,j.[IssueDate], j.[FinishDate])) AS  [Average Days] 
    FROM [Mechanics] AS m
    JOIN [Jobs]      AS j  ON m.[MechanicId] = j.[MechanicId]
   WHERE j.[MechanicId] IS NOT NULL
GROUP BY m.[MechanicId], m.[FirstName], m.[LastName]
ORDER BY m.MechanicId

---------------------------------------------------------------------------------------------------
-- 8 TASK Available Mechanics ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT([FirstName], ' ', [LastName]) AS [Available] 
    FROM [Mechanics] 
   WHERE [MechanicId] NOT IN (  SELECT [MechanicId] 
                                  FROM [Jobs]
  					             WHERE [Status] IN ('In Progress')
  						      GROUP BY [MechanicId]
  						     )
ORDER BY [MechanicId]  

---------------------------------------------------------------------------------------------------
-- 9 TASK Past Expenses ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT  j.[JobId]
          ,ISNULL(SUM(p.[Price] * op.[Quantity]), 0)  AS [Total]
     FROM [Jobs]       AS j
LEFT JOIN [Orders]     AS o  ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
LEFT JOIN [Parts]      AS p  ON op.[PartId] = p.[PartId]
    WHERE j.[Status] IN ('Finished')
 GROUP BY j.[JobId]  
 ORDER BY [Total] DESC, j.[JobId]

---------------------------------------------------------------------------------------------------
-- 10 TASK Missing Parts --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT *
   FROM  (   SELECT p.[PartId]
                    ,p.[Description]
                    ,pn.[Quantity] AS [Required]
                    ,p.[StockQty] AS [In Stock]
                    ,ISNULL(op.[Quantity], 0) AS [Ordered]
               FROM [Jobs]        AS j
          LEFT JOIN [PartsNeeded] AS pn ON j.[JobId] = pn.[JobId]
          LEFT JOIN [Parts]       AS p  ON pn.[PartId] = p.[PartId]
          LEFT JOIN [Orders]      AS o  ON j.[JobId] = o.[JobId]
          LEFT JOIN [OrderParts]  AS op ON o.[OrderId] = op.[OrderId]
            WHERE j.[Status] NOT IN ('Finished') AND (o.[Delivered] = 0 OR o.Delivered IS NULL)
         ) AS [PartsQuantitySubQuery]
   WHERE [Required] > [In Stock] + [Ordered]
ORDER BY [PartId]

---------------------------------------------------------------------------------------------------
-- 11 TASK Place Order ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
GO
CREATE PROC usp_PlaceOrder(@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS
BEGIN
	IF((SELECT [Status] FROM [Jobs] WHERE [JobId] = @jobId) IN ('Finished'))	   	    
	    THROW 50011, 'This job is not active!', 1     
    ELSE IF(@quantity <= 0)
	    THROW 50012, 'Part quantity must be more than zero!', 1     
	ELSE IF(NOT EXISTS (SELECT [JobId] FROM [Jobs] WHERE [JobId] = @jobId))	 	    
	    THROW 50013, 'Job not found!', 1    
	ELSE IF(NOT EXISTS (SELECT [PartId] FROM [Parts] WHERE [SerialNumber] = @partSerialNumber))
	    THROW 50014, 'Part not found!', 1      

    DECLARE @partId INT = (SELECT [PartId]  FROM [Parts]  WHERE [SerialNumber] = @partSerialNumber)
	DECLARE @order  INT = (SELECT [OrderId] FROM [Orders] WHERE [JobId] = @jobId AND [IssueDate] IS NULL)

	IF(@order IS NULL)    /* няма такава поръчка, създаваме я */
	  BEGIN
	    INSERT INTO [Orders]([JobId], [IssueDate])
		     VALUES (@jobId, NULL)

        DECLARE @orderId INT = (SELECT [OrderId] FROM [Orders] WHERE [JobId] = @jobId AND [IssueDate] IS NULL)	

        INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
		     VALUES (@orderId, @partId, @quantity)		   
      END 
	ELSE IF(EXISTS (SELECT [Quantity] FROM [OrderParts] WHERE [OrderId] = @order AND [PartId] = @partId)) /* проверяваме дали частта я има в поръчката */
	  BEGIN 
		UPDATE [OrderParts]
		   SET [Quantity] += @quantity
         WHERE [OrderId] = @order AND [PartId] = @partId
	  END
    ELSE 
	  BEGIN
	    INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
	         VALUES (@order, @partId, @quantity)	
      END
END
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

---------------------------------------------------------------------------------------------------
-- 12 TASK Cost of Order --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @totalCost DECIMAL(15,2)

	SET @totalCost = ( SELECT SUM(p.[Price] * op.[Quantity])
	                     FROM [Jobs]       AS j
				     	 JOIN [Orders]     AS o  ON j.[JobId] = o.[JobId]
				     	 JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
				     	 JOIN [Parts]      AS p  ON op.[PartId] = p.[PartId]
                        WHERE j.[JobId] = @jobId
                     )

     RETURN ISNULL(@totalCost, 0)
END
GO

SELECT dbo.udf_GetCost(1)
SELECT dbo.udf_GetCost(3)
