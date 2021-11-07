/***** Databases MSSQL Server Exam - 28 Jun 2020 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [ColonialJourney]
USE ColonialJourney

CREATE TABLE [Colonists](
	[Id]         INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName] VARCHAR(20)              NOT NULL
	,[LastName]  VARCHAR(20)              NOT NULL
	,[Ucn]       VARCHAR(10) UNIQUE       NOT NULL
	,[BirthDate] DATE                     NOT NULL
)

CREATE TABLE [Spaceships](
	[Id]              INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]           VARCHAR(50)              NOT NULL
	,[Manufacturer]   VARCHAR(30)              NOT NULL
	,[LightSpeedRate] INT DEFAULT(0)           NOT NULL
)

CREATE TABLE [Planets](
	[Id]    INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(30)              NOT NULL
)

CREATE TABLE [Spaceports](
	[Id]        INT PRIMARY KEY IDENTITY                   NOT NULL
	,[Name]     VARCHAR(50)                                NOT NULL
	,[PlanetId] INT FOREIGN KEY REFERENCES [Planets]([Id]) NOT NULL
)

CREATE TABLE [Journeys](
	[Id]                      INT PRIMARY KEY IDENTITY                      NOT NULL
	,[JourneyStart]           DATETIME2                                     NOT NULL
	,[JourneyEnd]             DATETIME2                                     NOT NULL
	,[Purpose]                VARCHAR(11)
	,[DestinationSpaceportId] INT FOREIGN KEY REFERENCES [Spaceports]([Id]) NOT NULL
	,[SpaceshipId]            INT FOREIGN KEY REFERENCES [Spaceships]([Id]) NOT NULL
	,CHECK ([Purpose] IN ('Medical', 'Technical', 'Educational', 'Military'))
)

CREATE TABLE [TravelCards](
	[Id]                INT PRIMARY KEY IDENTITY                     NOT NULL
	,[CardNumber]       CHAR(10) UNIQUE                              NOT NULL
	,[JobDuringJourney] VARCHAR(8) 
	,[ColonistId]       INT FOREIGN KEY REFERENCES [Colonists]([Id]) NOT NULL
	,[JourneyId]        INT FOREIGN KEY REFERENCES [Journeys]([Id])  NOT NULL
	,CHECK ([JobDuringJourney] IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'))
)

SELECT * FROM Colonists
SELECT * FROM Planets
SELECT * FROM Spaceships
SELECT * FROM Spaceports
SELECT * FROM Journeys
SELECT * FROM TravelCards

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Planets]([Name])
     VALUES ('Mars') ,('Earth'), ('Jupiter'), ('Saturn')

INSERT INTO [Spaceships]([Name], [Manufacturer], [LightSpeedRate])
	 VALUES ('Golf', 'VW', 3)
	        ,('WakaWaka', 'Wakanda', 4)
			,('Falcon9', 'SpaceX', 1)
			,('Bed', 'Vidolov', 6)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Spaceships]
   SET [LightSpeedRate] += 1
 WHERE [Id] BETWEEN 8 AND 12

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [TravelCards]
      WHERE [JourneyId] IN (1,2,3)

DELETE FROM [Journeys]
      WHERE [Id] IN (1,2,3)

---------------------------------------------------------------------------------------------------
-- 5 TASK Select All Military Journeys ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DROP DATABASE [ColonialJourney]

  SELECT [Id]
         ,FORMAT([JourneyStart], 'dd/MM/yyyy') AS [JourneyStart]
	     ,FORMAT([JourneyEnd], 'dd/MM/yyyy')   AS [JourneyEnd]
    FROM [Journeys]
   WHERE [Purpose] IN ('Military')
ORDER BY [JourneyStart]

---------------------------------------------------------------------------------------------------
-- 6 TASK Select All Pilots -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT c.[Id]
          ,CONCAT(c.FirstName, ' ', c.LastName)  AS [full_name]
     FROM [TravelCards] AS tc
LEFT JOIN [Colonists]   AS c ON tc.ColonistId = c.Id
    WHERE tc.JobDuringJourney IN ('Pilot')
 ORDER BY c.[Id]

---------------------------------------------------------------------------------------------------
-- 7 TASK Count Colonists -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT COUNT(c.Id)   AS [count]
     FROM [TravelCards] AS tc
LEFT JOIN [Colonists]   AS c ON tc.ColonistId = c.Id
LEFT JOIN [Journeys]    AS j ON tc.JourneyId = j.Id
    WHERE j.Purpose IN ('Technical')

---------------------------------------------------------------------------------------------------
-- 8 TASK Select Spaceships With Pilots -----------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT s.[Name]
          ,s.[Manufacturer]          
     FROM [Spaceships]  AS s
LEFT JOIN [Journeys]    AS j  ON s.[Id] = j.[SpaceshipId]
LEFT JOIN [TravelCards] AS tc ON j.Id = tc.[JourneyId]
LEFT JOIN [Colonists]   AS c  ON tc.ColonistId = c.[Id]
    WHERE DATEDIFF(YEAR,c.BirthDate, '01/01/2019') < 30 AND tc.[JobDuringJourney] IN ('Pilot')
 GROUP BY s.[Name], s.[Manufacturer]
 ORDER BY s.[Name]

---------------------------------------------------------------------------------------------------
-- 9 TASK Planets And Journeys --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT p.[Name]     AS [PlanetName]
         ,COUNT(j.Id) AS [JourneysCount]
    FROM [Planets]    AS p
    JOIN [Spaceports] AS s ON p.[Id] = s.[PlanetId]
    JOIN [Journeys]   AS j ON s.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY COUNT(j.Id) DESC
         ,p.[Name]

---------------------------------------------------------------------------------------------------
-- 10 TASK Select Special Colonists ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
SELECT *
  FROM (   SELECT tc.[JobDuringJourney]
                  ,CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName] 
                  ,DENSE_RANK() OVER (PARTITION BY tc.[JobDuringJourney] ORDER BY c.[BirthDate]) AS [JobRank]
             FROM [TravelCards]  AS tc
        LEFT JOIN [Colonists] AS c ON tc.[ColonistId] = c.[Id] 
		) AS [RankinSubQuery]
  WHERE [JobRank] = 2

---------------------------------------------------------------------------------------------------
-- 11 TASK Get Colonists Count --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
  DECLARE @result INT
      SET @result = (    SELECT COUNT(c.Id)  
                           FROM [Colonists]   AS c
                      LEFT JOIN [TravelCards] AS tc ON c.[Id] = tc.[ColonistId]
                      LEFT JOIN [Journeys]    AS j  ON tc.[JourneyId] = j.[Id]
                      LEFT JOIN [Spaceports]  AS sp ON j.[DestinationSpaceportId] = sp.[Id]
                      LEFT JOIN [Planets]     AS p  ON sp.[PlanetId] = p.[Id]
                          WHERE p.[Name] = @PlanetName
                    )
   RETURN @result 
END
GO

SELECT dbo.udf_GetColonistsCount('Otroyphus')

---------------------------------------------------------------------------------------------------
-- 12 TASK Change Journey Purpose -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
  BEGIN TRANSACTION
  IF( NOT EXISTS (SELECT * FROM [Journeys] WHERE [Id] = @JourneyId))
	 BEGIN
       ROLLBACK
       RAISERROR('The journey does not exist!', 16, 1)
       RETURN
     END
  ELSE IF ((SELECT [Purpose] FROM [Journeys] WHERE [Id] = @JourneyId) = @NewPurpose)
     BEGIN
       ROLLBACK
       RAISERROR('You cannot change the purpose!', 16, 1)
       RETURN
     END
   
UPDATE [Journeys]
   SET [Purpose] = @NewPurpose
 WHERE [Id] = @JourneyId

COMMIT
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
