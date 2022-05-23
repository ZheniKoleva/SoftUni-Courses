/***** Additional Exercises *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK Number of Users for Email Provider ------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

  SELECT SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])-CHARINDEX('@', [Email]))         AS [Email Provider]
         ,COUNT(SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])-CHARINDEX('@', [Email]))) AS [Number Of Users]
    FROM [Users]
GROUP BY SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])-CHARINDEX('@', [Email]))
ORDER BY [Number Of Users] DESC
         , SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])-CHARINDEX('@', [Email]))

 --- Option 2 ---
  SELECT RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email]))         AS [Email Provider]
         ,COUNT(RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email]))) AS [Number Of Users]
    FROM [Users]
GROUP BY RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) 
ORDER BY [Number Of Users] DESC
         , RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email]))
		 
---------------------------------------------------------------------------------------------------
-- 2 TASK All Users in Games ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

  SELECT g.[Name]         AS [Game]
		 ,gt.[Name]       AS [Game Type]
		 ,u.[Username]    AS [Username]
		 ,ug.[Level]      AS [Level]
		 ,ug.[Cash]       AS [Cash]
		 ,c.[Name]        AS [Character]
    FROM [Games]      AS g
    JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
    JOIN [Users]      AS u  ON ug.[UserId] = u.[Id]
    JOIN [GameTypes]  AS gt ON g.[GameTypeId] = gt.[Id]
    JOIN [Characters] AS c  ON ug.[CharacterId] = c.[Id]
ORDER BY [Level] DESC
         ,[Username]
		 ,[Game]

---------------------------------------------------------------------------------------------------
-- 3 TASK Users in Games with Their Items ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

  SELECT u.[Username] 
         ,g.[Name]            AS [Game] 
	     ,COUNT(ugi.[ItemId]) AS [Items Count]
		 ,SUM(i.[Price])      AS [Items Price]
    FROM [Games]         AS g
    JOIN [UsersGames]    AS ug  ON g.[Id] = ug.[GameId]    
    JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
	JOIN [Items]         AS i   ON ugi.[ItemId] = i.[Id]
	JOIN [Users]         AS u   ON u.[Id] = ug.[UserId] 
GROUP BY g.[Name], u.[Username]
  HAVING COUNT(ugi.[ItemId]) >= 10
ORDER BY [Items Count] DESC
         ,[Items Price] DESC
         ,u.[Username]

---------------------------------------------------------------------------------------------------
-- 4 TASK Users in Games with Their Items ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

   SELECT u.Username
          ,g.[Name]                                                    AS [Game]
	      , MAX(ch.[Name])                                             AS [Character]
	      ,SUM(iSt.Strength) + MAX(gtSt.Strength) + MAX(chSt.Strength) AS [Strength]
	      ,SUM(iSt.Defence) + MAX(gtSt.Defence) + MAX(chSt.Defence)    AS [Defence]
	      ,SUM(iSt.Speed) + MAX(gtSt.Speed) + MAX(chSt.Speed)          AS [Speed]
	      ,SUM(iSt.Mind) + MAX(gtSt.Mind) + MAX(chSt.Mind)             AS [Mind]
	      ,SUM(iSt.Luck) + MAX(gtSt.Luck) + MAX(chSt.Luck)             AS [Luck]             
     FROM Users         AS u
LEFT JOIN UsersGames    AS ug    ON u.Id = ug.UserId
LEFT JOIN Games         AS g     ON ug.GameId = g.Id
LEFT JOIN GameTypes     AS gt    ON g.GameTypeId = gt.Id
LEFT JOIN [Statistics]  AS gtSt  ON gt.BonusStatsId = gtSt.Id  
LEFT JOIN Characters    AS ch    ON ug.CharacterId = ch.Id
LEFT JOIN [Statistics]  AS chSt  ON ch.StatisticId = chSt.Id   
LEFT JOIN UserGameItems AS ugi   ON ug.Id = ugi.UserGameId
LEFT JOIN Items         AS i     ON ugi.ItemId = i.Id
LEFT JOIN [Statistics]  AS iSt   ON i.StatisticId = iSt.Id     
 GROUP BY u.Username, g.[Name]
 ORDER BY [Strength] DESC
          ,[Defence] DESC
		  ,[Speed] DESC
		  ,[Mind] DESC
		  ,[Luck] DESC 

---------------------------------------------------------------------------------------------------
-- 5 TASK All Items with Greater than Average Statistics ------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo
 
  SELECT i.[Name]
         ,i.[Price]
  	     ,i.[MinLevel]
  	     ,s.[Strength]
  	     ,s.[Defence]
  	     ,s.[Speed]
  	     ,s.[Luck]
  	     ,s.[Mind]       
    FROM [Items]        AS i 
    JOIN [Statistics]   AS s ON i.[StatisticId] = s.[Id]
   WHERE s.[Speed] > (SELECT AVG([Speed]) FROM [Statistics])                
         AND s.[Mind] > (SELECT AVG([Mind]) FROM [Statistics]) 
         AND s.[Luck] > (SELECT AVG([Luck]) FROM [Statistics]) 
ORDER BY i.[Name]

 --- Option 2 ---
WITH CTE_AvgStatistics(AvgMind, AvgLuck, AvgSpeed)
AS 
(SELECT AVG([Mind])  AS [AvgMind], 
        AVG([Luck])  AS [AvgLuck], 
        AVG([Speed]) AS [AvgSpeed]
  FROM  [Statistics])

  SELECT i.[Name]
         ,i.[Price]
  	     ,i.[MinLevel]
  	     ,s.[Strength]
  	     ,s.[Defence]
  	     ,s.[Speed]
  	     ,s.[Luck]
  	     ,s.[Mind]       
    FROM [Items]        AS i 
    JOIN [Statistics]   AS s ON i.[StatisticId] = s.[Id]
   WHERE s.[Speed] > (SELECT [AvgSpeed] FROM CTE_AvgStatistics)                
         AND s.[Mind] > (SELECT [AvgMind] FROM CTE_AvgStatistics) 
         AND s.[Luck] > (SELECT [AvgLuck] FROM CTE_AvgStatistics) 
ORDER BY i.[Name]

---------------------------------------------------------------------------------------------------
-- 6 TASK Display All Items about Forbidden Game Type ---------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

  SELECT i.[Name]       AS [Item]
         ,i.[Price]     AS [Price]
	     ,i.[MinLevel]  AS [MinLevel]
	     ,gt.[Name]     AS [Forbidden Game Type]
    FROM [Items]                   AS i
LEFT JOIN [GameTypeForbiddenItems] AS gtf ON i.[Id] = gtf.[ItemId]
LEFT JOIN [GameTypes]              AS gt  ON gtf.[GameTypeId] = gt.[Id]
ORDER BY gt.[Name] DESC
         ,i.[Name]

---------------------------------------------------------------------------------------------------
-- 7 TASK Buy Items for User in Game --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

DECLARE @userName   VARCHAR(50) = 'Alex'
DECLARE @gameName   VARCHAR(50) = 'Edinburgh'
DECLARE @userNameId INT = (SELECT [Id] FROM [Users] WHERE [Username] = @userName)                              /* 5 */
DECLARE @gameId     INT = (SELECT [Id] FROM [Games] WHERE [Name] =  @gameName)                                 /* 221 */
DECLARE @userGameId INT = (SELECT [Id] FROM [UsersGames] WHERE [UserId] =  @userNameId AND [GameId] = @gameId) /* 235 */
DECLARE @cash       DECIMAL(18,4) = (SELECT [Cash] FROM [UsersGames] WHERE [Id] =  @userGameId)                /* 7659,00 */

DECLARE @sumNeeded DECIMAL(18,4) = (SELECT SUM([Price])
                                      FROM Items
                                     WHERE [Name] IN ('Blackguard'
                                                      ,'Bottomless Potion of Amplification'
                                   				      ,'Eye of Etlich (Diablo III)'
                                   				      ,'Gem of Efficacious Toxin'
                                   				      ,'Golden Gorget of Leoric'
                                   				      ,'Hellfire Amulet')) /* 2957,00 */
UPDATE [UsersGames]
   SET [Cash] -= @sumNeeded
 WHERE [Id] = @userGameId

INSERT INTO [UserGameItems]
     SELECT [Id]
	        ,@userGameId 
	   FROM [Items]
      WHERE [Name] IN ('Blackguard'
                       ,'Bottomless Potion of Amplification'
                       ,'Eye of Etlich (Diablo III)'
                       ,'Gem of Efficacious Toxin'
                       ,'Golden Gorget of Leoric'
                       ,'Hellfire Amulet')

   SELECT u.[Username]
          ,@gameName      AS [Game]
		  ,ug.[Cash]      AS [Cash]
		  ,i.[Name]       AS [Item Name]
     FROM [UsersGames]    AS ug
     JOIN [Users]         AS u   ON ug.[UserId] = u.[Id]
     JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
     JOIN [Items]         AS i   ON ugi.[ItemId] = i.[Id]
    WHERE ug.[GameId] = @gameId 
 ORDER BY i.[Name]  

 --- Option 2 ---

DECLARE @userGameId INT
    SET @userGameId = (SELECT ug.[Id]                        
                       FROM [UsersGames] AS ug
                       JOIN [Users] AS u ON ug.[UserId] = u.[Id]
                       JOIN [Games] AS g ON ug.[GameId] = g.[Id]
                      WHERE u.[Username] IN ('Alex') AND g.[Name] IN ('Edinburgh')) /* 235 */

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Blackguard')) /* 756, 00 */
 WHERE Id = @userGameId

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Bottomless Potion of Amplification')) /* 90, 00 */
 WHERE Id = @userGameId

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Eye of Etlich (Diablo III)')) /* 412, 00 */
 WHERE Id = @userGameId

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Gem of Efficacious Toxin')) /* 726, 00 */
 WHERE Id = @userGameId

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Golden Gorget of Leoric')) /* 772, 00 */
 WHERE Id = @userGameId

UPDATE UsersGames
   SET Cash -= (SELECT Price FROM Items WHERE [Name] IN ('Hellfire Amulet'))         /* 201, 00 */
 WHERE Id = @userGameId

INSERT INTO UserGameItems(ItemId, UserGameId)
     VALUES ((SELECT Id FROM Items WHERE [Name] IN ('Blackguard')) ,@userGameId)                         /* 51, 235 */
	        ,((SELECT Id FROM Items WHERE [Name] IN ('Bottomless Potion of Amplification')),@userGameId) /* 71, 235 */
	        ,((SELECT Id FROM Items WHERE [Name] IN ('Eye of Etlich (Diablo III)')),@userGameId)         /* 157, 235 */
			,((SELECT Id FROM Items WHERE [Name] IN ('Gem of Efficacious Toxin')),@userGameId)           /* 184, 235 */
			,((SELECT Id FROM Items WHERE [Name] IN ('Golden Gorget of Leoric')),@userGameId)            /* 197, 235 */
			,((SELECT Id FROM Items WHERE [Name] IN ('Hellfire Amulet')),@userGameId)                    /* 223, 235 */

-- 1
   SELECT u.[Username]
          ,g.[Name]
		  ,ug.[Cash]      
		  ,i.[Name]       AS [Item Name]
     FROM [Users]         AS u
     JOIN [UsersGames]    AS ug  ON u.[Id] = ug.[UserId]
     JOIN [Games]         AS g   ON ug.[GameId] = g.[Id]
     JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
     JOIN [Items]         AS i   ON ugi.[ItemId] = i.[Id]
    WHERE g.[Name] IN ('Edinburgh')
 ORDER BY i.[Name]

-- 2
  SELECT u.[Username]
          ,g.[Name]
		  ,ug.[Cash] 
		  ,i.[Name]     AS [Item Name]
     FROM [Games]         AS g
LEFT JOIN [UsersGames]    AS ug  ON g.[Id] = ug.[GameId]
LEFT JOIN [Users]         AS u   ON ug.[UserId] = u.[Id]
LEFT JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
LEFT JOIN [Items]         AS i   ON ugi.[ItemId] = i.[Id]
    WHERE g.[Name] IN ('Edinburgh')
 ORDER BY i.[Name]

---------------------------------------------------------------------------------------------------
-- 8 TASK Peaks and Mountains ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]
 
  SELECT p.[PeakName]
         ,m.[MountainRange]
		 ,p.[Elevation]
    FROM [Peaks]     AS p
    JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
ORDER BY p.[Elevation] DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Peaks with Mountain, Country and Continent ----------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT p.[PeakName]
         ,m.[MountainRange]   AS [Mountain]
		 ,c.[CountryName]
		 ,co.[ContinentName]
    FROM [Peaks]              AS p
    JOIN [Mountains]          AS m  ON p.[MountainId] = m.[Id]
    JOIN [MountainsCountries] AS mc ON m.Id = mc.[MountainId]
    JOIN [Countries]          AS c  ON mc.[CountryCode] = c.[CountryCode]
    JOIN [Continents]         AS co ON c.[ContinentCode] = co.[ContinentCode]
ORDER BY p.[PeakName]
         ,c.[CountryName] 

---------------------------------------------------------------------------------------------------
-- 10 TASK Rivers by Country ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

   SELECT c.[CountryName]
          ,co.[ContinentName]
		  ,ISNULL(COUNT(cr.[RiverId]), 0)  AS [RiverCount]
		  ,ISNULL(SUM(r.[Length]), 0)      AS [TotalLength]
     FROM [Countries]       AS c
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers]          AS r  ON cr.[RiverId] = r.[Id]
LEFT JOIN [Continents]      AS co ON c.[ContinentCode] = co.[ContinentCode]
GROUP BY c.[CountryName], co.[ContinentName]
ORDER BY [RiverCount] DESC
         ,[TotalLength] DESC
		 ,c.[CountryName]

---------------------------------------------------------------------------------------------------
-- 11 TASK Count of Countries by Currency ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

   SELECT cu.[CurrencyCode]
          ,cu.[Description]     AS [Currency]
		  ,COUNT(c.CountryCode) AS [NumberOfCountries]
     FROM [Currencies] AS cu
LEFT JOIN [Countries]  AS c  ON cu.[CurrencyCode] = c.[CurrencyCode]
 GROUP BY cu.[CurrencyCode], cu.[Description]
 ORDER BY [NumberOfCountries] DESC
          ,[Currency]

---------------------------------------------------------------------------------------------------
-- 12 TASK Population and Area by Continent -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

   SELECT c.[ContinentName]
          ,SUM(co.[AreaInSqKm])                 AS [CountriesArea]
		  ,SUM(CAST(co.[Population] AS BIGINT)) AS [CountriesPopulation]
     FROM [Continents] AS c
LEFT JOIN [Countries]  AS co ON c.[ContinentCode] = co.[ContinentCode]
 GROUP BY co.[ContinentCode], c.[ContinentName]
 ORDER BY [CountriesPopulation] DESC
      
 --- Option 2 ---
    SELECT co.[ContinentName]
           ,SUM(c.[AreaInSqKm])                 AS [CountriesArea]
           ,SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
      FROM [Countries]  AS c
RIGHT JOIN [Continents] AS co ON c.[ContinentCode] = co.[ContinentCode]
  GROUP BY c.[ContinentCode], co.[ContinentName]
  ORDER BY [CountriesPopulation] DESC

---------------------------------------------------------------------------------------------------
-- 13 TASK Monasteries by Country -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

CREATE TABLE [Monasteries](
	[Id]           INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]        NVARCHAR(50) NOT NULL
	,[CountryCode] CHAR(2) FOREIGN KEY REFERENCES [Countries]([CountryCode])
)

INSERT INTO [Monasteries]([Name], [CountryCode]) 
     VALUES ('Rila Monastery “St. Ivan of Rila”', 'BG')
			,('Bachkovo Monastery “Virgin Mary”', 'BG')
			,('Troyan Monastery “Holy Mother''s Assumption”', 'BG')
			,('Kopan Monastery', 'NP')
            ,('Thrangu Tashi Yangtse Monastery', 'NP')
            ,('Shechen Tennyi Dargyeling Monastery', 'NP')
            ,('Benchen Monastery', 'NP')
            ,('Southern Shaolin Monastery', 'CN')
            ,('Dabei Monastery', 'CN')
            ,('Wa Sau Toi', 'CN')
            ,('Lhunshigyia Monastery', 'CN')
            ,('Rakya Monastery', 'CN')
            ,('Monasteries of Meteora', 'GR')
            ,('The Holy Monastery of Stavronikita', 'GR')
            ,('Taung Kalat Monastery', 'MM')
            ,('Pa-Auk Forest Monastery', 'MM')
            ,('Taktsang Palphug Monastery', 'BT')
            ,('Sümela Monastery', 'TR')
            
ALTER TABLE [Countries]
ADD [IsDeleted] BIT DEFAULT(0) NOT NULL

UPDATE [Countries]
   SET [IsDeleted] = 1
 WHERE [CountryCode] IN (  SELECT [CountryCode]        
                           FROM [CountriesRivers]
                       GROUP BY [CountryCode]
                         HAVING COUNT([RiverId]) > 3)

  SELECT m.[Name]
         ,c.[CountryName]
    FROM [Monasteries] AS m
    JOIN [Countries]   AS c ON m.[CountryCode] = c.[CountryCode]
   WHERE c.[IsDeleted] = 0
ORDER BY m.[Name]

---------------------------------------------------------------------------------------------------
-- 14 TASK Monasteries by Continents and Countries ------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

UPDATE [Countries]
   SET [CountryName] = 'Burma'
 WHERE [CountryName] IN ('Myanmar')
 
INSERT INTO [Monasteries]([Name], [CountryCode]) 
     VALUES ('Hanga Abbey', (SELECT [CountryCode] FROM [Countries] WHERE [CountryName] IN ('Tanzania')))
	        ,('Myin-Tin-Daik',(SELECT [CountryCode] FROM [Countries] WHERE [CountryName] IN ('Myanmar')))

    SELECT co.[ContinentName]
           ,c.[CountryName]
		   ,COUNT(m.[Id])  AS [MonasteriesCount]
      FROM [Monasteries]   AS m
RIGHT JOIN [Countries]     AS c ON m.[CountryCode] = c.[CountryCode]
 LEFT JOIN [Continents]    AS co ON c.[ContinentCode] = co.[ContinentCode]
     WHERE [IsDeleted] = 0
  GROUP BY co.[ContinentName], c.[CountryName]
  ORDER BY [MonasteriesCount] DESC
          ,c.[CountryName] 