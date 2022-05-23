/***** Databases MSSQL Server Exam - 21 Jun 2020 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [TripService]
GO

USE [TripService]
GO

CREATE TABLE [Cities](
	[Id]           INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]        NVARCHAR(20)             NOT NULL
	,[CountryCode] CHAR(2)                  NOT NULL
)

CREATE TABLE [Hotels](
	[Id]             INT PRIMARY KEY IDENTITY                  NOT NULL
	,[Name]          NVARCHAR(30)                              NOT NULL
	,[CityId]        INT FOREIGN KEY REFERENCES [Cities]([Id]) NOT NULL
	,[EmployeeCount] INT                                       NOT NULL
	,[BaseRate]      DECIMAL(15,2)
)

CREATE TABLE [Rooms](
	[Id]       INT PRIMARY KEY IDENTITY                  NOT NULL
	,[Price]   DECIMAL(15,2)                             NOT NULL
	,[Type]    NVARCHAR(20)                              NOT NULL
	,[Beds]    INT                                       NOT NULL
	,[HotelId] INT FOREIGN KEY REFERENCES [Hotels]([Id]) NOT NULL
)

CREATE TABLE [Trips](
	[Id]           INT PRIMARY KEY IDENTITY                 NOT NULL
	,[RoomId]      INT FOREIGN KEY REFERENCES [Rooms]([Id]) NOT NULL 
	,[BookDate]    DATE                                     NOT NULL
	,[ArrivalDate] DATE                                     NOT NULL
	,[ReturnDate]  DATE                                     NOT NULL
	,[CancelDate]  DATE                                     
	,CHECK ([BookDate] < [ArrivalDate])
	,CHECK ([ArrivalDate] < [ReturnDate])
)

CREATE TABLE [Accounts](
	[Id]          INT PRIMARY KEY IDENTITY                  NOT NULL
	,[FirstName]  NVARCHAR(50)                              NOT NULL
	,[MiddleName] NVARCHAR(20)
	,[LastName]   NVARCHAR(50)                              NOT NULL
	,[CityId]     INT FOREIGN KEY REFERENCES [Cities]([Id]) NOT NULL
	,[BirthDate]  DATE                                      NOT NULL
	,[Email]      VARCHAR(100) UNIQUE                       NOT NULL
)

CREATE TABLE [AccountsTrips](
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL
	,[TripId]   INT FOREIGN KEY REFERENCES [Trips]([Id])    NOT NULL
	,[Luggage]  INT                                         NOT NULL
	,CHECK ([Luggage] >= 0)
	,PRIMARY KEY([AccountId],[TripId])
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Accounts]([FirstName], [MiddleName], [LastName], [CityId], [BirthDate], [Email])
	 VALUES ('John', 'Smith', 'Smith', 34, '1975-07-21' , 'j_smith@gmail.com')
	        ,('Gosho', NULL, 'Petrov', 11, '1978-05-16' , 'g_petrov@gmail.com')
			,('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26' , 'i_pavlov@softuni.bg')
			,('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15' , 'f_nietzsche@softuni.bg')

INSERT INTO [Trips]([RoomId], [BookDate], [ArrivalDate], [ReturnDate], [CancelDate])
     VALUES (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02')
	        ,(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29')
			,(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL)
			,(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10')
			,(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Rooms]
   SET [Price] *= 1.14
 WHERE [HotelId] IN (5,7,9)

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [AccountsTrips]
      WHERE [AccountId] = 47

---------------------------------------------------------------------------------------------------
-- 5 TASK EEE-Mails -------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT a.[FirstName]
          ,a.[LastName]
		  ,FORMAT(a.[BirthDate], 'MM-dd-yyyy') AS [BirthDate]
		  ,c.[Name]                            AS [Hometown]
		  ,a.[Email]
     FROM [Accounts]  AS a
LEFT JOIN [Cities]    AS c ON a.[CityId] = c.[Id]
    WHERE [Email] LIKE ('e%')
 ORDER BY c.[Name] 

---------------------------------------------------------------------------------------------------
-- 6 TASK City Statistics -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT c.[Name]
         ,COUNT(h.Id) AS [Hotels]    
    FROM [Cities]  AS c
	JOIN [Hotels]  AS h ON c.[Id] = h.[CityId]
GROUP BY c.[Name]
ORDER BY COUNT(h.Id) DESC
         ,c.[Name]

---------------------------------------------------------------------------------------------------
-- 7 TASK Longest and Shortest Trips --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
 SELECT  [AccountId]
        ,[FullName]
 	    ,MAX(TripsDuration)  AS [LongestTrip]
 	    ,MIN(TripsDuration)  AS [ShortestTrip]
   FROM (SELECT a.[Id]                                           AS [AccountId]
                ,CONCAT(a.[FirstName], ' ', a.[LastName])        AS [FullName]
 		        ,DATEDIFF(DAY,t.[ArrivalDate], t.[ReturnDate])   AS [TripsDuration]		      
           FROM [Accounts]  AS a
           JOIN [AccountsTrips] AS at ON a.[Id] = at.[AccountId]
           JOIN [Trips]  AS t ON at.[TripId] = t.[Id]
          WHERE a.[MiddleName] IS NULL AND t.[CancelDate] IS NULL
         ) AS r
GROUP BY [AccountId], [FullName]
ORDER BY [LongestTrip] DESC
         ,[ShortestTrip]

---------------------------------------------------------------------------------------------------
-- 8 TASK Metropolis ------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT TOP(10)
         c.[Id]
         ,c.[Name]
	     ,c.[CountryCode]
		 ,COUNT(a.[Id])    AS [Accounts]
    FROM [Cities]   AS c
    JOIN [Accounts] AS a ON c.[Id] = a.CityId
GROUP BY c.[Id], c.[Name], c.[CountryCode]
ORDER BY [Accounts] DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Romantic Getaways -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT a.[Id]
         ,a.[Email]
		 ,c.[Name]          AS [City]
		 ,COUNT(c1.[Name])  AS [Trips]
    FROM [Accounts]      AS a
    JOIN [Cities]        AS c   ON a.[CityId] = c.[Id]
    JOIN [AccountsTrips] AS act ON a.[Id] = act.[AccountId]
    JOIN [Trips]         AS t   ON act.[TripId] = t.[Id]
    JOIN [Rooms]         AS r   ON t.[RoomId] = r.[Id]
    JOIN [Hotels]        AS h   ON r.[HotelId] = h.[Id]
    JOIN [Cities]        AS c1  ON h.[CityId] = c1.[Id]
   WHERE c.[Name] = c1.[Name]
GROUP BY a.[Id], a.[Email], c.[Name]
ORDER BY [Trips] DESC
         ,a.[Id]  

---------------------------------------------------------------------------------------------------
-- 10 TASK GDPR Violation -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT t.[Id]
          ,CONCAT(a.[FirstName], ' ', ISNULL(a.[MiddleName] + ' ',''), a.[LastName])  AS [Full Name]
	      ,c.[Name] AS [From]
	      ,c2.[Name] AS [To]
	      ,CASE 
	          WHEN t.[CancelDate] IS NOT NULL THEN 'Canceled'
		      ELSE CONCAT(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate]), ' ', 'days')
           END AS [Duration]
     FROM [Trips]         AS t 
     JOIN [AccountsTrips] AS act ON t.[Id] = act.[TripId]
     JOIN [Accounts]      AS a   ON act.[AccountId] = a.[Id]
     JOIN [Cities]        AS c   ON a.[CityId] = c.[Id]
     JOIN [Rooms]         AS r   ON t.[RoomId] = r.[Id]
     JOIN [Hotels]        AS h   ON r.[HotelId] = h.[Id]
     JOIN [Cities]        AS c2  ON h.[CityId] = c2.[Id]
 ORDER BY [Full Name]
          ,t.[Id]

---------------------------------------------------------------------------------------------------
-- 11 TASK Available Room -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(100)
AS
BEGIN
   DECLARE @output VARCHAR(100)
   DECLARE @resultTable TABLE (roomId INT, roomType NVARCHAR(20), beds INT, price DECIMAL (15,2))

   INSERT INTO @resultTable SELECT TOP(1)
                                    r.[Id], r.[Type], r.[Beds] 
                                    ,(h.[BaseRate] + r.[Price]) * 2  AS [TotalPrice]
                               FROM [Rooms]  AS r	
                               JOIN [Hotels] AS h ON r.[HotelId] = h.[Id]
                               JOIN [Trips]  AS t ON r.[Id] = t.[RoomId]
                              WHERE r.[HotelId] = @HotelId 
                                    AND t.[CancelDate] IS NULL 
                                    AND (@Date NOT BETWEEN t.[ArrivalDate] AND t.[ReturnDate])
                             	    AND r.[Beds] >= @People 
									AND YEAR(@Date) = YEAR(t.[ArrivalDate])
                           ORDER BY [TotalPrice] DESC
							  
   DECLARE @room INT = (SELECT roomId FROM @resultTable)  
	
   IF(@room IS NULL)
     BEGIN
     SET @output = 'No rooms available'	  
     END
   ELSE
     BEGIN
     DECLARE @roomType NVARCHAR(20) = (SELECT roomType FROM @resultTable)
     DECLARE @beds INT = (SELECT beds FROM @resultTable)
     DECLARE @price DECIMAL(15,2) = (SELECT price FROM @resultTable)
     
     SET @output = CONCAT('Room ', @room, ': ', @roomType, ' (', @beds, ' beds) - $', @price)
    END      
  RETURN @output		
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

---------------------------------------------------------------------------------------------------
-- 12 TASK Switch Room ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
   DECLARE @tripHotelId INT = (SELECT r.[HotelId]
							     FROM [Trips] AS t
							     JOIN [Rooms] AS r ON t.[RoomId] = r.[Id]
								WHERE t.[Id] = @TripId)

   DECLARE @targetRoomHotelId INT = (SELECT [HotelId] FROM [Rooms] WHERE [Id] = @TargetRoomId)
   DECLARE @tripAccounts INT = (SELECT COUNT(AccountId) FROM [AccountsTrips] WHERE [TripId] = @TripId)
   DECLARE @targetRoomBeds INT = (SELECT [Beds] FROM [Rooms] WHERE [Id] = @TargetRoomId)

   IF(@tripHotelId <> @targetRoomHotelId)
     BEGIN
	 RAISERROR('Target room is in another hotel!', 16, 1)
	 END
   ELSE IF(@tripAccounts > @targetRoomBeds)
     BEGIN
	 RAISERROR('Not enough beds in target room!', 16, 1)
	 END
   ELSE
     BEGIN
     UPDATE [Trips]
	    SET [RoomId] = @TargetRoomId
      WHERE [Id] = @TripId
	  END
END
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
