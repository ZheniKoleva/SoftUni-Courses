/***** Build-in-Functions *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK Find Names of All Employees by First Name -----------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

 --- Option 2 ---
SELECT FirstName, LastName
  FROM Employees
 WHERE SUBSTRING(FirstName, 1, 2) = 'Sa'

 --- Option 3 ---
SELECT FirstName, LastName
  FROM Employees
 WHERE LEFT(FirstName, 2) = 'Sa'

---------------------------------------------------------------------------------------------------
-- 2 TASK Find Names of All Employees by Last Name ------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'

 --- Option 2 ---
SELECT FirstName
	   ,LastName	   
  FROM Employees
 WHERE CHARINDEX('ei', LastName) <> 0

---------------------------------------------------------------------------------------------------
-- 3 TASK Find First Names of All Employess -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

 --- Option 2 ---
SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

---------------------------------------------------------------------------------------------------
-- 4 TASK Find All Employees Except Engineers -----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE ('%engineer%')
  
---------------------------------------------------------------------------------------------------
-- 5 TASK Find Towns with Name Length -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

 --- Option 2 ---
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

---------------------------------------------------------------------------------------------------
-- 6 TASK Find Towns Starting With ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE [Name] LIKE '[M, K, B, E]%' /* [MKBE] */
ORDER BY [Name]

 --- Option 2 ---
  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

 --- Option 3 ---
  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

---------------------------------------------------------------------------------------------------
-- 7 TASK Find Towns Not Starting With ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE '[R, B, D]%'
ORDER BY [Name]

 --- Option 2 ---
  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

 --- Option 3 ---
  SELECT [Townid], [Name]
    FROM [Towns]
   WHERE SUBSTRING([Name], 1, 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

---------------------------------------------------------------------------------------------------
-- 8 TASK Create View Employees Hired After -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE VIEW [V_EmployeesHiredAfter2000] AS
     SELECT FirstName, LastName
       FROM Employees
      WHERE DATEPART(YEAR, HireDate) > 2000

---------------------------------------------------------------------------------------------------
-- 9 TASK Length of Last Name ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5

---------------------------------------------------------------------------------------------------
-- 10 TASK Rank Employees by Salary ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT EmployeeID
	     ,FirstName
         ,LastName
	     ,Salary
	     ,DENSE_RANK() OVER (PARTITION BY Salary 
							     ORDER BY EmployeeID
		  ) AS Rank 
    FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC 

---------------------------------------------------------------------------------------------------
-- 11 TASK Find All Employees with Rank 2 ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT *
    FROM (
	       SELECT EmployeeID
	              ,FirstName
                  ,LastName
	              ,Salary
	              ,DENSE_RANK() OVER (PARTITION BY Salary 
							             ORDER BY EmployeeID
				  ) AS Rank 
             FROM Employees
            WHERE Salary BETWEEN 10000 AND 50000
		 ) AS Result
   WHERE Rank = 2
ORDER BY Salary DESC 

 --- Option 2 ---
CREATE VIEW V_RankBySalary AS
     SELECT EmployeeID
	        ,FirstName
            ,LastName
	        ,Salary
	        ,DENSE_RANK() OVER (PARTITION BY Salary 
							        ORDER BY EmployeeID) AS Rank 
       FROM Employees
      WHERE Salary BETWEEN 10000 AND 50000
 GO
 
  SELECT *
    FROM V_RankBySalary
   WHERE Rank = 2
ORDER BY Salary DESC
  
---------------------------------------------------------------------------------------------------
-- 12 TASK Countries Holding 'A' ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography] 

  SELECT [CountryName]  AS [Country Name]
	     ,[IsoCode]     AS [ISO Code] 		 
    FROM [Countries]
   WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [ISO Code]

---------------------------------------------------------------------------------------------------
-- 13 TASK Mix of Peak and River Names ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]   

  SELECT p.PeakName
         ,r.RiverName
	     ,LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName)))) 
		         AS [Mix]
    FROM Peaks   AS p
		 ,Rivers AS r
   WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

 --- Option 2 ---
  SELECT  p.PeakName
          ,r.RiverName
		  ,LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) 
		         AS [Mix]
    FROM  Peaks  AS p
    JOIN  Rivers AS r
      ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)  
ORDER BY [Mix]

---------------------------------------------------------------------------------------------------
-- 14 TASK Games From 2011 and 2012 Year ----------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Diablo] 

  SELECT TOP(50) 
         [Name]
		 ,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

---------------------------------------------------------------------------------------------------
-- 15 TASK User Email Providers -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Diablo] 

  SELECT [Username]
         ,SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email])) 
		 AS [Email Provider]		 
    FROM [Users]  
ORDER BY [Email Provider], [Username] 

 --- Option 2 ---
  SELECT [Username]
         ,RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) 
		 AS [Email Provider]		 
    FROM [Users]  
ORDER BY [Email Provider], [Username] 

---------------------------------------------------------------------------------------------------
-- 16 TASK Get Users with IPAddress Like Pattern --------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Diablo] 

  SELECT [Username]
         ,[IpAddress] AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

---------------------------------------------------------------------------------------------------
-- 17 TASK Show All Games with Duration -----------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Diablo] 

SELECT [Name]    AS [Game]       	 
		 ,CASE 
				WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
			    WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			    ELSE 'Evening'
		  END 
		         AS [Part of the Day]         
		 ,CASE 
				WHEN [Duration] <= 3 THEN 'Extra Short'
			    WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			    WHEN [Duration] > 6 THEN 'Long'
				ELSE 'Extra Long'
	     END 
		         AS [Duration]
	FROM [Games] AS g
ORDER BY [Game],[Duration],[Part of the Day] 

 --- Option 2 ---
  SELECT [Name]  AS [Game]       	 
		 ,CASE 
				WHEN DATEPART(HOUR,[Start]) >= 0 AND DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
			    WHEN DATEPART(HOUR,[Start]) >= 12 AND DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
			    ELSE 'Evening'
		  END 
		         AS [Part of the Day]         
		 ,CASE 
				WHEN [Duration] <= 3 THEN 'Extra Short'
			    WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			    WHEN [Duration] > 6 THEN 'Long'
				ELSE 'Extra Long'
	     END 
		         AS [Duration]
	FROM [Games] AS g
ORDER BY [Game],[Duration],[Part of the Day] 

---------------------------------------------------------------------------------------------------
-- 18 TASK Orders Table ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Orders

SELECT ProductName
	   ,OrderDate
	   ,DATEADD(DAY, 3, OrderDate) AS 'Pay Due'
	   ,DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
  FROM Orders

---------------------------------------------------------------------------------------------------
-- 19 TASK People Table ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE Peoples

USE Peoples

CREATE TABLE People(
	 [Id]        INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]      VARCHAR(30) NOT NULL
	,[Birthdate] DATETIME2 NOT NULL
)


INSERT INTO [People]([Name], [Birthdate])
     VALUES ('Victor', '2020-12-07')
	        ,('Steven', '1992-09-10')
			,('Stephen', '1910-09-19')
			,('John', '2010-01-06')

SELECT [Name]
       ,DATEDIFF(YEAR, [Birthdate], GETDATE())   AS [Age in Years]
	   ,DATEDIFF(MONTH, [Birthdate], GETDATE())  AS [Age in Months]
	   ,DATEDIFF(DAY, [Birthdate], GETDATE())    AS [Age in Days]
	   ,DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
  FROM [People]

