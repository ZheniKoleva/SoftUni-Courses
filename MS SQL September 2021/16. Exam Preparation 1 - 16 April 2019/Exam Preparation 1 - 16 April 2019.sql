/***** Exam Preparation 1 - 16 April 2019 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Airport]
GO

USE [Airport]
GO

CREATE TABLE [Planes](
	[Id]     INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]  VARCHAR(30)              NOT NULL
	,[Seats] INT                      NOT NULL
	,[Range] INT                      NOT NULL
)

CREATE TABLE [Flights](
	[Id]             INT PRIMARY KEY IDENTITY                  NOT NULL
	,[DepartureTime] DATETIME
	,[ArrivalTime]   DATETIME
	,[Origin]        VARCHAR(50)                               NOT NULL
	,[Destination]   VARCHAR(50)                               NOT NULL 
	,[PlaneId]       INT FOREIGN KEY REFERENCES [Planes]([Id]) NOT NULL
)

CREATE TABLE [Passengers](
	[Id]          INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName]  VARCHAR(30)              NOT NULL
	,[LastName]   VARCHAR(30)              NOT NULL
	,[Age]        INT                      NOT NULL
	,[Address]    VARCHAR(30)              NOT NULL
	,[PassportId] CHAR(11)                 NOT NULL	
)

CREATE TABLE [LuggageTypes](
	[Id]    INT PRIMARY KEY IDENTITY NOT NULL
	,[Type] VARCHAR(30)              NOT NULL
)

CREATE TABLE [Luggages](
	[Id]             INT PRIMARY KEY IDENTITY                        NOT NULL
	,[LuggageTypeId] INT FOREIGN KEY REFERENCES [LuggageTypes]([Id]) NOT NULL
	,[PassengerId]   INT FOREIGN KEY REFERENCES [Passengers]([Id])   NOT NULL
)

CREATE TABLE [Tickets](
	[Id]           INT PRIMARY KEY IDENTITY                      NOT NULL
	,[PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL
	,[FlightId]    INT FOREIGN KEY REFERENCES [Flights]([Id])    NOT NULL
	,[LuggageId]   INT FOREIGN KEY REFERENCES [Luggages]([Id])   NOT NULL
	,[Price]       DECIMAL(8,2)                                  NOT NULL
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Planes]([Name], [Seats], [Range])
     VALUES ('Airbus 336', 112, 5132)
	        ,('Airbus 330', 432, 5325)
			,('Boeing 369', 231, 2355)
	        ,('Stelt 297', 254, 2143)
			,('Boeing 338', 165, 5111)
			,('Airbus 558', 387, 1342)
			,('Boeing 128', 345, 5541)

INSERT INTO [LuggageTypes]([Type])
     VALUES ('Crossbody Bag')
	        ,('School Backpack')
			,('Shoulder Bag')

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Tickets]
   SET [Price] *= 1.13
 WHERE [FlightId] IN (SELECT [Id] 
                        FROM [Flights] 
				       WHERE [Destination] IN ('Carlsbad'))

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [Tickets]
      WHERE [FlightId] IN (SELECT [Id]  
	                         FROM [Flights]
							WHERE [Destination] IN ('Ayn Halagim'))

DELETE FROM [Flights]
      WHERE [Destination] IN ('Ayn Halagim')

---------------------------------------------------------------------------------------------------
-- 5 TASK The "Tr" Planes -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT *
    FROM [Planes]
   WHERE [Name] LIKE ('%tr%')
ORDER BY [Id], [Name], [Seats], [Range]

--2
  SELECT *
    FROM [Planes]
   WHERE CHARINDEX('tr', [Name]) > 0
ORDER BY [Id], [Name], [Seats], [Range]
---------------------------------------------------------------------------------------------------
-- 6 TASK Flight Profits --------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------- 
  SELECT [FlightId]
         ,SUM([Price]) AS [Price]
    FROM [Tickets]
GROUP BY [FlightId]
ORDER BY [Price] DESC
         ,[FlightId]

---------------------------------------------------------------------------------------------------
-- 7 TASK Passenger Trips -------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------- 
  SELECT CONCAT(p.[FirstName], ' ', p.[LastName]) AS [Full Name]
         ,f.[Origin]
   	     ,f.[Destination]
    FROM [Passengers] AS p
    JOIN [Tickets]    AS t ON p.[Id] = t.[PassengerId]
    JOIN [Flights]    AS f ON t.[FlightId] = f.[Id]
ORDER BY [Full Name]
         ,f.[Origin]
		 ,f.[Destination]

---------------------------------------------------------------------------------------------------
-- 8 TASK Non Adventures People -------------------------------------------------------------------
--------------------------------------------------------------------------------------------------- 
  SELECT [FirstName]
         ,[LastName]
 		 ,[Age]
    FROM [Passengers]
   WHERE [Id] NOT IN (SELECT DISTINCT [PassengerId] 
                                 FROM [Tickets])
ORDER BY [Age] DESC
         ,[FirstName]
		 ,[LastName]

--2
   SELECT [FirstName]
          ,[LastName]
 		  ,[Age]
     FROM [Passengers] AS p
LEFT JOIN [Tickets]    AS t ON p.[Id] = t.[PassengerId]
    WHERE t.[PassengerId] IS NULL
 ORDER BY [Age] DESC
          ,[FirstName]
		  ,[LastName]

---------------------------------------------------------------------------------------------------
-- 9 TASK Full Info ------------------------------------------------------------------------------- 
--------------------------------------------------------------------------------------------------- 
  SELECT CONCAT(p.[FirstName], ' ', p.[LastName])    AS [Full Name]
         ,pl.[Name]                                  AS [Plane Name]
  	     ,CONCAT(f.[Origin], ' - ', f.[Destination]) AS [Trip]
  	     ,lt.[Type]                                  AS [Luggage Type]
    FROM [Tickets]      AS t
    JOIN [Passengers]   AS p  ON p.[Id] = t.[PassengerId]
    JOIN [Flights]      AS f  ON t.[FlightId] = f.[Id]
    JOIN [Planes]       AS pl ON f.[PlaneId] = pl.[Id]
    JOIN [Luggages]     AS l  ON t.[LuggageId] = l.[Id]
    JOIN [LuggageTypes] AS lt ON l.[LuggageTypeId] = lt.[Id]
ORDER BY [Full Name]
         ,[Plane Name]
		 ,f.[Origin]
		 , f.[Destination]
		 ,[Luggage Type]

---------------------------------------------------------------------------------------------------
-- 10 TASK PSP ------------------------------------------------------------------------------------ 
--------------------------------------------------------------------------------------------------- 
   SELECT p.[Name]
          ,p.[Seats]
	      ,COUNT(t.[PassengerId]) AS [Passengers Count]
     FROM [Planes]  AS p
LEFT JOIN [Flights] AS f ON p.[Id] = f.[PlaneId]
LEFT JOIN [Tickets] AS t ON f.[Id] = t.[FlightId]
 GROUP BY p.[Id], p.[Name], p.[Seats]
 ORDER BY [Passengers Count] DESC
          ,p.[Name]
 		  ,p.[Seats]

---------------------------------------------------------------------------------------------------
-- 11 TASK Vacation ------------------------------------------------------------------------------- 
--------------------------------------------------------------------------------------------------- 
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(30)
AS
BEGIN
	IF(@peopleCount <= 0)	  
	  RETURN ('Invalid people count!')	  

    DECLARE @flightId INT = (SELECT [Id] 
	                           FROM [Flights] 
							  WHERE [Origin] IN (@origin) AND [Destination] IN (@destination)
							) 
							
    IF(@flightId IS NULL)	 
	  RETURN('Invalid flight!')  
	
	DECLARE @totalSum DECIMAL(8,2) = (SELECT TOP(1)
	                                         ([Price] * @peopleCount) AS [Price]
	                                    FROM [Tickets]
									   WHERE [FlightId] = @flightId
									 )

    RETURN CONCAT('Total price ', @totalSum)	  
END
GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

---------------------------------------------------------------------------------------------------
-- 12 TASK Wrong Data -----------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------- 
CREATE PROC usp_CancelFlights /* условието на задачата е некоректно зададено */
AS
BEGIN
   UPDATE [Flights]
      SET  [ArrivalTime] = NULL
	      ,[DepartureTime] = NULL
    WHERE [ArrivalTime] > [DepartureTime]
END
GO

EXEC usp_CancelFlights 