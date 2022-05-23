/***** Functions and Procedures *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK Employees with Salary Above 35000 -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
   SELECT FirstName AS [First Name]
          ,LastName AS [Last Name]
     FROM Employees
    WHERE Salary > 35000
END
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

---------------------------------------------------------------------------------------------------
-- 2 TASK Employees with Salary Above Number ------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18,4))
AS
BEGIN
   SELECT FirstName AS [First Name]
          ,LastName AS [Last Name]
     FROM Employees
    WHERE Salary >= @number
END 
GO

EXEC usp_GetEmployeesSalaryAboveNumber 50000

---------------------------------------------------------------------------------------------------
-- 3 TASK Town Names Starting With ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_GetTownsStartingWith (@string NVARCHAR(30))
AS
BEGIN
   SELECT [Name] AS Town
     FROM Towns
    WHERE LEFT([Name],LEN(@string)) = @string
END
GO

EXEC usp_GetTownsStartingWith 'Snoho'

---------------------------------------------------------------------------------------------------
-- 4 TASK Employees from Town ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_GetEmployeesFromTown (@town VARCHAR(50))
AS
BEGIN
   SELECT e.FirstName AS [First Name]
          ,e.LastName AS [Last Name] 
     FROM Employees   AS e
     JOIN Addresses   AS a ON e.AddressID = a.AddressID
     JOIN Towns       AS t ON a.TownID = t.TownID
    WHERE t.[Name] = @town
END
GO

EXEC usp_GetEmployeesFromTown 'Sofia'

---------------------------------------------------------------------------------------------------
-- 5 TASK Salary Level Function -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN 
   DECLARE @salaryLevel NVARCHAR(10)

   IF (@salary < 30000)
     SET @salaryLevel = 'Low'
   ELSE IF (@salary BETWEEN 30000 AND 50000)
     SET @salaryLevel = 'Average'
   ELSE
     SET @salaryLevel = 'High'

   RETURN @salaryLevel
END
GO

SELECT Salary
       ,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
  FROM Employees

---------------------------------------------------------------------------------------------------
-- 6 TASK Employees by Salary Level ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_EmployeesBySalaryLevel (@level NVARCHAR(10))
AS
BEGIN
   SELECT FirstName AS [First Name]
          ,LastName AS [Last Name]
     FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @level 
END
GO 

EXEC usp_EmployeesBySalaryLevel 'High'

---------------------------------------------------------------------------------------------------
-- 7 TASK Define Function -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
AS
BEGIN  	 
    DECLARE @currentIndx INT
    DECLARE @currentLetter CHAR(1)	 
    SET @currentIndx = 1

    WHILE(@currentIndx <= LEN(@word))
       BEGIN		   
      	  SET @currentLetter = SUBSTRING(@word, @currentIndx, 1)
      	  IF(CHARINDEX(@currentLetter, @setOfLetters) = 0) 
      	    RETURN 0
          ELSE 
      	    SET @currentIndx += 1
       END
	   
RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

---------------------------------------------------------------------------------------------------
-- 8 TASK Delete Employees and Departments --------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
    DELETE FROM EmployeesProjects
          WHERE [EmployeeID] IN (SELECT EmployeeID
                                   FROM Employees
                                  WHERE DepartmentID = @departmentId)
    
    UPDATE Employees
       SET ManagerID = NULL
     WHERE ManagerID IN (SELECT EmployeeID
                           FROM Employees
                          WHERE DepartmentID = @departmentId)
    
     ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL
    
    UPDATE Departments
       SET ManagerID = NULL
     WHERE ManagerID IN (SELECT EmployeeID
                           FROM Employees
                          WHERE DepartmentID = @departmentId)
    
    DELETE FROM Employees
          WHERE DepartmentID = @departmentId
    
    DELETE FROM Departments
          WHERE DepartmentID = @departmentId
    
    SELECT COUNT(*)
      FROM Employees
     WHERE DepartmentID = @departmentId                            
END
GO

EXEC usp_DeleteEmployeesFromDepartment 1

/* in reality we delete: */
ALTER TABLE Employees
ADD IsDeleted BIT NULL

CREATE PROC usp_DeleteEmployeesFromDepartmentReal (@departmentId INT)
AS
BEGIN
    UPDATE Employees
    SET IsDeleted = 0
    
    UPDATE Employees
    SET IsDeleted = 1
    WHERE DepartmentID = @departmentId 
END
GO

SELECT IsDeleted 
  FROM Employees
 WHERE DepartmentID = 1

EXEC usp_DeleteEmployeesFromDepartmentReal 1

SELECT IsDeleted 
  FROM Employees
 WHERE DepartmentID = 1

---------------------------------------------------------------------------------------------------
-- 9 TASK Find Full Name --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
    SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
      FROM AccountHolders
END
GO

EXEC usp_GetHoldersFullName

---------------------------------------------------------------------------------------------------
-- 10 TASK People with Balance Higher Than --------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@limit MONEY)
AS
BEGIN
     SELECT ah.FirstName    AS [First Name]
            ,ah.LastName    AS [Last Name]  		 
       FROM AccountHolders  AS ah
       JOIN Accounts        AS a  ON ah.Id = a.AccountHolderId
   GROUP BY ah.Id, ah.FirstName, ah.LastName
     HAVING SUM(Balance) >  @limit
   ORDER BY [First Name], [Last Name]
END
GO

EXEC usp_GetHoldersWithBalanceHigherThan 600000

--- or --
SELECT ah.FirstName      AS [First Name]
         ,ah.LastName    AS [Last Name] 
		 ,SUM(Balance)   AS [Total]
    FROM AccountHolders  AS ah
    JOIN Accounts        AS a  ON ah.Id = a.AccountHolderId
GROUP BY ah.Id, ah.FirstName, ah.LastName

---------------------------------------------------------------------------------------------------
-- 11 TASK Future Value Function ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyRate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
   DECLARE @result DECIMAL(18,4)
       SET @result = @sum * POWER((1 + @yearlyRate), @years)
    RETURN @result
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)

---------------------------------------------------------------------------------------------------
-- 12 TASK Calculating Interest -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
BEGIN
   SELECT a.Id           AS [Account Id]
          ,ah.FirstName  AS [First Name]
	      ,ah.LastName   AS [LastName]
	 	  ,a.Balance     AS [Current Balance]
	 	  ,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
     FROM dbo.Accounts       AS a 
     JOIN dbo.AccountHolders AS ah ON a.AccountHolderId = ah.Id
    WHERE a.Id = @accountId
END
GO

EXEC usp_CalculateFutureValueForAccount  1, 0.1

---------------------------------------------------------------------------------------------------
-- 13 TASK Cash in User Games Odd Rows ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE   
AS
BEGIN
RETURN SELECT( SELECT SUM(Cash) AS [SumCash]
                 FROM
                      (SELECT ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [Row]
					          ,g.[Name]  AS GameName
                              ,ug.Cash   AS Cash
                         FROM UsersGames AS ug
                         JOIN Games      AS g  ON ug.GameId = g.Id
                        WHERE g.[Name] = @gameName
                      ) AS [RowsNumber]
                WHERE [Row] % 2 <> 0
              ) AS [SumCash]
END
GO

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist')

