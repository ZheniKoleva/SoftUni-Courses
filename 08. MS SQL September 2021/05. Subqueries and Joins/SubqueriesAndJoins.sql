/***** Subqueries and Joins *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK Employee Address-------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(5)
		 e.EmployeeID
		 ,e.JobTitle
		 ,a.AddressID
		 ,a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a ON e.AddressID = a.AddressID /* може и LEFT JOIN*/
ORDER BY a.AddressID

---------------------------------------------------------------------------------------------------
-- 2 TASK Addresses with Towns---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT TOP(50)
		 e.[FirstName]
		 ,e.[LastName]
		 ,t.[Name]    AS [Town]
		 ,a.[AddressText]
    FROM [Employees]  AS e
    JOIN [Addresses]  AS a ON e.[AddressID] = a.[AddressID]
LEFT JOIN [Towns]     AS t ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName]
         ,e.[LastName]

---------------------------------------------------------------------------------------------------
-- 3 TASK Sales Employees--------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT e.[EmployeeID]
		 ,e.[FirstName]
		 ,e.[LastName]
		 ,d.[Name]      AS [DepartmentName]
    FROM [Employees]    AS e
    JOIN [Departments]  AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

--------
  SELECT e.[EmployeeID]
		 ,e.[FirstName]
		 ,e.[LastName]
		 ,d.[Name]      AS [DepartmentName]
    FROM [Employees]    AS e
    JOIN [Departments]  AS d ON e.[DepartmentID] = d.[DepartmentID] AND d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]

---------------------------------------------------------------------------------------------------
-- 4 TASK Employee Departments---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(5)  
         e.[EmployeeID]
		 ,e.[FirstName]
		 ,e.[Salary]
		 ,d.[Name]    AS [DepartmentName]
    FROM [Employees]  AS e
    JOIN Departments  AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[Salary] > 15000
ORDER BY d.[DepartmentID]

--------
  SELECT TOP(5)  
         e.[EmployeeID]
		 ,e.[FirstName]
		 ,e.[Salary]
		 ,d.[Name]      AS [DepartmentName]
    FROM Employees      AS e
    JOIN [Departments]  AS d ON e.[DepartmentID] = d.[DepartmentID] AND e.[Salary] > 15000
ORDER BY d.[DepartmentID]

---------------------------------------------------------------------------------------------------
-- 5 TASK Employees Without Projects---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

    SELECT TOP(3)   
           e.EmployeeID
		   ,e.FirstName		
      FROM Employees         AS e
 LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID

---------
    SELECT TOP(3)   
           e.EmployeeID
		   ,e.FirstName		
      FROM Employees AS e 
     WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
  ORDER BY e.EmployeeID

---------------------------------------------------------------------------------------------------
-- 6 TASK Employees Hired After--------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT e.[FirstName]
         ,e.[LastName]
	     ,e.[HireDate]
	     ,d.[Name]     AS [DeptName]
    FROM [Employees]   AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[Name] IN ('Sales', 'Finance') AND e.[HireDate] > '1999-01-01' 
ORDER BY e.[HireDate]

---------------------------------------------------------------------------------------------------
-- 7 TASK Employees With Project ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT TOP(5) 
         e.[EmployeeID]
         ,e.[FirstName]
	     ,p.[Name]           AS [ProjectName]
    FROM [Employees]         AS e
    JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects]          AS p  ON ep.[ProjectID] = p.[ProjectID]
   WHERE p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID]

---------------------------------------------------------------------------------------------------
-- 8 TASK Employee 24 -----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

SELECT e.[EmployeeID]
       ,e.[FirstName]
	   ,CASE
			WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
		    ELSE p.[Name]
       END                 AS [ProjectName]
  FROM [Employees]         AS e
  JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
  JOIN [Projects]          AS p  ON ep.[ProjectID] = p.[ProjectID]
 WHERE e.[EmployeeID] = 24

---------------------------------------------------------------------------------------------------
-- 9 TASK Employee 24 -----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

    SELECT e.EmployeeID
	       ,e.FirstName
		   ,e.ManagerID
		   ,m.FirstName
      FROM Employees AS e
      JOIN Employees AS m ON e.ManagerID = m.EmployeeID
     WHERE e.ManagerID IN (3,7)
  ORDER BY e.EmployeeID

---------------------------------------------------------------------------------------------------
-- 10 TASK Employees Summary ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(50)
         e.EmployeeID
         ,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
		 ,CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
		 ,d.[Name]   AS DepartmentName
    FROM Employees   AS e
    JOIN Employees   AS m ON e.ManagerID = m.EmployeeID
    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

---------------------------------------------------------------------------------------------------
-- 11 TASK Min Average Salary ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(1)
         AVG(Salary) AS MinAverageSalary				       
	FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary

 --- Option 2 ---
SELECT MIN(s.AvgSalary) AS MinAverageSalary
FROM 
(
    SELECT d.[Name]
	       ,AVG(Salary) AS AvgSalary				       
	  FROM Employees    AS e
	  JOIN Departments  AS d ON e.DepartmentID = d.DepartmentID
  GROUP BY d.[Name]
) AS s

---------------------------------------------------------------------------------------------------
-- 12 TASK Highest Peaks in Bulgaria --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT  c.CountryCode
          ,m.MountainRange
          ,p.PeakName
		  ,p.Elevation
     FROM Countries          AS c
	 JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     JOIN Mountains          AS m  ON mc.MountainId = m.Id
     JOIN Peaks              AS p  ON m.Id = p.MountainId
    WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 --- Option 2 ---
  SELECT  mc.CountryCode
          ,m.MountainRange
          ,p.PeakName
		  ,p.Elevation
     FROM MountainsCountries AS mc	
     JOIN Mountains          AS m  ON mc.MountainId = m.Id
     JOIN Peaks              AS p  ON m.Id = p.MountainId
    WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 --- Option 3 ---
   SELECT mc.CountryCode
          ,m.MountainRange
          ,p.PeakName
		  ,p.Elevation
     FROM Peaks              AS p
     JOIN Mountains          AS m  ON p.MountainId = m.Id
     JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
    WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 --- Option 4 ---
 SELECT   c.CountryCode
          ,m.MountainRange
          ,p.PeakName
		  ,p.Elevation
     FROM Peaks              AS p
     JOIN Mountains          AS m  ON p.MountainId = m.Id
     JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	 JOIN Countries          AS c  ON mc.CountryCode = c.CountryCode
    WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

---------------------------------------------------------------------------------------------------
-- 13 TASK Count Mountain Ranges ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT c.CountryCode
          ,COUNT(mc.MountainId) AS MountainRanges
     FROM Countries             AS c
LEFT JOIN MountainsCountries    AS mc ON c.CountryCode = mc.CountryCode
    WHERE c.CountryName IN ('United States', 'Russia','Bulgaria')
 GROUP BY c.CountryCode

---------------------------------------------------------------------------------------------------
-- 14 TASK Countries With or Without Rivers -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

   SELECT TOP(5)
          c.CountryName
          ,r.RiverName
     FROM Countries       AS c
LEFT JOIN Continents      AS cn ON c.ContinentCode = cn.ContinentCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers          AS r  ON cr.RiverId = r.Id
    WHERE cn.ContinentName = 'Africa'
 ORDER BY c.CountryName

---------------------------------------------------------------------------------------------------
-- 15 TASK Continents and Currencies --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

SELECT ContinentCode
       ,CurrencyCode
	   ,Usage         AS CurrencyUsage
  FROM
       (SELECT  *
	            ,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY Usage DESC) AS CurrencyRank
          FROM
                (  SELECT ContinentCode 
                          ,CurrencyCode  
		                  ,COUNT(CurrencyCode) AS Usage
                     FROM Countries
                 GROUP BY ContinentCode, CurrencyCode
                ) AS [CurrencyFilter]
         WHERE Usage > 1
	    ) AS FinalResult
 WHERE CurrencyRank = 1

---------------------------------------------------------------------------------------------------
-- 16 TASK Countries Without any Mountains --------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]
 
   SELECT COUNT(c.CountryName) AS 'Count'
     FROM Countries            AS c
LEFT JOIN MountainsCountries   AS mc ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL

---------------------------------------------------------------------------------------------------
-- 17 TASK Highest Peak and Longest River by Country ----------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT TOP(5)
         CountryName
         ,HighestPeakElevation
	     ,LongestRiverLength
    FROM
         (     SELECT c.CountryName
			          ,p.Elevation    AS HighestPeakElevation
			          ,r.[Length]     AS LongestRiverLength
			          ,DENSE_RANK() OVER (PARTITION BY c.CountryName 
			                        ORDER BY p.Elevation DESC, r.[Length] DESC, c.CountryName ) AS Ranking
                 FROM Countries           AS c
            LEFT JOIN MountainsCountries  AS mc ON c.CountryCode = mc.CountryCode
            LEFT JOIN Mountains           AS m  ON mc.MountainId = m.Id
            LEFT JOIN Peaks               AS p  ON m.Id = p.MountainId
            LEFT JOIN CountriesRivers     AS cr ON c.CountryCode = cr.CountryCode
            LEFT JOIN Rivers              AS r  ON cr.RiverId = r.Id
         ) AS SubQuery
   WHERE Ranking = 1
ORDER BY HighestPeakElevation DESC
         ,LongestRiverLength DESC
		 ,CountryName

 --- Option 2 ---
   SELECT TOP(5)
          CountryName
          ,MAX(p.Elevation) AS HighestPeakElevation
	      ,MAX(r.[Length])  AS LongestRiverLength
     FROM Countries           AS c
LEFT JOIN MountainsCountries  AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains           AS m  ON mc.MountainId = m.Id
LEFT JOIN Peaks               AS p  ON m.Id = p.MountainId
LEFT JOIN CountriesRivers     AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers              AS r  ON cr.RiverId = r.Id
 GROUP BY c.CountryName
 ORDER BY HighestPeakElevation DESC
         ,LongestRiverLength DESC
		 ,CountryName

---------------------------------------------------------------------------------------------------
-- 18 TASK Highest Peak Name and Elevation by Country ---------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

   SELECT TOP(5)
          CountryName AS Country
          ,CASE 
	          WHEN Result.PeakName IS NULL THEN '(no highest peak)'
			  ELSE Result.PeakName
           END               AS [Highest Peak Name]
	      ,CASE 
	          WHEN Result.Elevation IS NULL THEN '0'
			  ELSE Result.Elevation
           END               AS [Highest Peak Elevation]
		  ,CASE 
	          WHEN Result.MountainRange IS NULL THEN '(no mountain)'
			  ELSE Result.MountainRange
           END               AS [Mountain]	
     FROM
	      (    SELECT c.CountryName
                      ,p.PeakName
		              ,p.Elevation
		              ,m.MountainRange
		              ,DENSE_RANK() OVER (PARTITION BY c.CountryName 
					                          ORDER BY p.Elevation DESC) AS Rank
                 FROM Countries           AS c
            LEFT JOIN MountainsCountries  AS mc ON c.CountryCode = mc.CountryCode
            LEFT JOIN Mountains           AS m  ON mc.MountainId = m.Id
            LEFT JOIN Peaks               AS p  ON m.Id = p.MountainId
          ) AS Result
    WHERE Rank = 1
 ORDER BY Country, [Highest Peak Name]

 --- Option 2 ---
   SELECT TOP(5)
          CountryName                                   AS [Country]
          ,ISNULL(Result.PeakName, '(no highest peak)') AS [Highest Peak Name]
		  ,ISNULL(Result.Elevation, 0)                  AS [Highest Peak Elevation]
	      ,ISNULL(Result.MountainRange,'(no mountain)') AS [Mountain]
     FROM
	      (    SELECT c.CountryName
                      ,p.PeakName
		              ,p.Elevation
		              ,m.MountainRange
		              ,DENSE_RANK() OVER (PARTITION BY c.CountryName 
					                          ORDER BY p.Elevation DESC) AS [Rank]
                 FROM Countries           AS c
            LEFT JOIN MountainsCountries  AS mc ON c.CountryCode = mc.CountryCode
            LEFT JOIN Mountains           AS m  ON mc.MountainId = m.Id
            LEFT JOIN Peaks               AS p  ON m.Id = p.MountainId
          ) AS Result
    WHERE [Rank] = 1
 ORDER BY [Country], [Highest Peak Name]