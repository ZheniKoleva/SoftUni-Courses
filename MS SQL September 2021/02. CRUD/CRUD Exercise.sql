/***** CRUD EXERCISE *****/

---------------------------------------------------------------------------------------------------
-- 2 TASK Find All Information About Departments --------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT * FROM Departments

---------------------------------------------------------------------------------------------------
-- 3 TASK Find all Department Names ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT [Name] 
	AS [Departments Name]
  FROM Departments

---------------------------------------------------------------------------------------------------
-- 4 TASK Find Salary of Each Employee ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName, Salary
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 5 TASK Find Full Name of Each Employee ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, MiddleName, LastName
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 6 TASK Find Email Address of Each Employee -----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT CONCAT(FirstName,'.', LastName,'@softuni.bg') 
	AS [Full Email Address]
  FROM Employees

---------------
GO

CREATE VIEW [V_FullEmailAddress] AS
	 SELECT CONCAT(FirstName,'.', LastName,'@softuni.bg') 
	     AS [Full Email Address]
       FROM Employees

GO

SELECT * FROM V_FullEmailAddress

---------------------------------------------------------------------------------------------------
-- 7 TASK Find All Different Employee’s Salaries --------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT DISTINCT Salary
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 8 TASK Find all Information About Employees ----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT * FROM Employees
 WHERE JobTitle = 'Sales Representative'

---------------------------------------------------------------------------------------------------
-- 9 TASK Find Names of All Employees by Salary in Range ------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName, JobTitle 
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

-----------------
SELECT FirstName, LastName, JobTitle 
  FROM Employees
 WHERE Salary >= 20000 AND Salary <= 30000

---------------------------------------------------------------------------------------------------
-- 10 TASK Find Names of All Employees ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT CONCAT(FirstName,' ', MiddleName,' ', LastName) 
    AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600)

 --- Option 2 ---
 CREATE VIEW V_FullNameBySalary AS
 SELECT CONCAT(FirstName,' ', MiddleName,' ', LastName) 
    AS [Full Name]
  FROM Employees
  WHERE Salary IN (25000, 14000, 12500, 23600)

GO

SELECT * FROM V_FullNameBySalary

 --- Option 3 ---
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) /* judge не я поддържа все още */
    AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600)

---------------------------------------------------------------------------------------------------
-- 11 TASK Find All Employees Without Manager -----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName 
  FROM Employees
 WHERE ManagerID IS NULL

---------------------------------------------------------------------------------------------------
-- 12 TASK Find All Employees with Salary More Than -----------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT FirstName, LastName, Salary
    FROM Employees
   WHERE Salary > 50000
ORDER BY Salary DESC

---------------------------------------------------------------------------------------------------
-- 13 TASK Find 5 Best Paid Employees -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(5) FirstName ,LastName
           FROM Employees
       ORDER BY Salary DESC 

---------------------------------------------------------------------------------------------------
-- 14 TASK Find All Employees Except Marketing ----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentId NOT IN (4)

---------------------------------------------------------------------------------------------------
-- 15 TASK Sort Employees Table -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT * FROM Employees
ORDER BY Salary DESC
		 ,FirstName ASC
		 ,LastName DESC
		 ,MiddleName ASC

---------------------------------------------------------------------------------------------------
-- 16 TASK Create View Employees with Salaries ----------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni
GO

CREATE VIEW V_EmployeesSalaries AS
     SELECT FirstName, LastName, Salary
       FROM Employees
GO

SELECT * FROM V_EmployeesSalaries /* в джъдж се качва само view-то */

---------------------------------------------------------------------------------------------------
-- 17 TASK Create View Employees with Job Titles --------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni
GO

CREATE VIEW V_EmployeeNameJobTitle AS
     SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
		    ,JobTitle AS [Job Title]
       FROM Employees
GO

SELECT * FROM V_EmployeeNameJobTitle

 --- Option 2 ---
CREATE VIEW V_EmployeeNameJobTitle AS
     SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS [Full Name]
		    ,JobTitle AS [Job Title]
       FROM Employees
GO

---------------------------------------------------------------------------------------------------
-- 18 TASK Distinct Job Titles --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT DISTINCT JobTitle
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 19 TASK Find First 10 Started Projects ---------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT TOP(10) * 
    FROM [Projects]
ORDER BY [StartDate]
		 ,[Name]

---------------------------------------------------------------------------------------------------
-- 20 TASK Last 7 Hired Employees -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT TOP(7) 
		 FirstName
	     ,LastName
	     ,HireDate
    FROM Employees
ORDER BY HireDate DESC

---
GO

CREATE VIEW V_EmployeesByHireDate AS
     SELECT FirstName
	       ,LastName
	       ,HireDate
      FROM Employees

GO

   SELECT TOP(7) *
     FROM V_EmployeesByHireDate
 ORDER BY HireDate DESC

---------------------------------------------------------------------------------------------------
-- 21 TASK Increase Salaries ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

UPDATE Employees
   SET Salary *= 1.12
 WHERE DepartmentID IN (1, 2, 4, 11) 

SELECT Salary
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 22 TASK All Mountain Peaks ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

SELECT PeakName
  FROM Peaks
ORDER BY PeakName ASC

---------------------------------------------------------------------------------------------------
-- 23 TASK Biggest Countries by Population --------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT TOP(30) [CountryName], [Population]
    FROM [Countries]
   WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC
		,[CountryName]

---------------------------------------------------------------------------------------------------
-- 24 TASK Countries and Currency (Euro / Not Euro) -----------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT [CountryName]
         ,[CountryCode]	   
         ,CASE
		    WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		    ELSE 'Not Euro' /* WHEN [CurrencyCode ] <> 'EUR' THEN 'Not Euro' */
         END AS [Currency]
    FROM [Countries]
ORDER BY CountryName

---------------------------------------------------------------------------------------------------
-- 25 TASK All Diablo Characters ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

  SELECT [Name]
    FROM [Characters]
ORDER BY [Name] ASC

