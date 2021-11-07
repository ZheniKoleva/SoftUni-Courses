/***** Databases MSSQL Server Retake Exam - 8 April 2021 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Service]
GO

USE [Service]
GO

CREATE TABLE [Users](
	[Id]         INT PRIMARY KEY IDENTITY NOT NULL
	,[Username]  NVARCHAR(30) UNIQUE      NOT NULL
	,[Password]  NVARCHAR(50)             NOT NULL
	,[Name]      NVARCHAR(50)
	,[Birthdate] DATETIME2
	,[Age]       INT 
	,[Email]     VARCHAR(50)              NOT NULL
	,CHECK ([Age] BETWEEN 14 AND 110)
)

CREATE TABLE [Departments](
	[Id]     INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]  NVARCHAR(50)             NOT NULL
)

CREATE TABLE [Employees](
	[Id]            INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName]    NVARCHAR(25)
	,[LastName]     NVARCHAR(25)
	,[Birthdate]    DATETIME2
	,[Age]          INT
	,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id])
	,CHECK ([Age] BETWEEN 18 AND 110)
)

CREATE TABLE [Categories](
	[Id]            INT PRIMARY KEY IDENTITY                       NOT NULL
	,[Name]         NVARCHAR(50)                                   NOT NULL
	,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL
)

CREATE TABLE [Status](
	[Id]     INT PRIMARY KEY IDENTITY NOT NULL
	,[Label] NVARCHAR(30)             NOT NULL
)

CREATE TABLE [Reports](
	[Id]           INT PRIMARY KEY IDENTITY                      NOT NULL
	,[CategoryId]  INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL
	,[StatusId]    INT FOREIGN KEY REFERENCES [Status]([Id])     NOT NULL
	,[OpenDate]    DATETIME2                                     NOT NULL
	,[CloseDate]   DATETIME2 
	,[Description] NVARCHAR(200)                                 NOT NULL
	,[UserId]      INT FOREIGN KEY REFERENCES [Users]([Id])      NOT NULL
	,[EmployeeId]  INT FOREIGN KEY REFERENCES [Employees]([Id])
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Employees]([FirstName], [LastName], [Birthdate], [DepartmentId])
     VALUES ('Marlo', 'O''Malley', '1958-9-21', 1)
	        ,('Niki', 'Stanaghan', '1969-11-26', 4)
			,('Ayrton', 'Senna', '1960-03-21', 9)
			,('Ronnie', 'Peterson', '1944-02-14', 9)
			,('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO [Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId])
     VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2)
	        ,(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5)
			,(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2)
			,(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [Reports]
   SET [CloseDate] = GETDATE()
 WHERE [CloseDate] IS NULL

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [Reports]
      WHERE [StatusId] = 4

---------------------------------------------------------------------------------------------------
-- 5 TASK Unassigned Reports ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [Description]
         ,FORMAT(r.[OpenDate], 'dd-MM-yyyy') AS [OpenDate]
    FROM [Reports]  AS r
   WHERE [EmployeeId] IS NULL
ORDER BY r.[OpenDate]
         ,[Description]

---------------------------------------------------------------------------------------------------
-- 6 TASK Reports & Categories --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT r.[Description]
         ,c.[Name]    AS [CategoryName]
    FROM [Reports]    AS r
    JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
ORDER BY r.[Description]
         ,c.[Name]

---------------------------------------------------------------------------------------------------
-- 7 TASK Most Reported Category ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT TOP(5)
          c.[Name]     AS [CategoryName]
          ,COUNT(r.Id) AS [ReportsNumber]
     FROM [Categories] AS c
LEFT JOIN [Reports]    AS r ON c.[Id] = r.[CategoryId]
 GROUP BY c.[Name]
 ORDER BY [ReportsNumber] DESC
          ,[CategoryName]

---------------------------------------------------------------------------------------------------
-- 8 TASK Birthday Report -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT u.[Username]
         ,c.[Name]    AS [CategoryName]		 
    FROM [Users]      AS u
    JOIN [Reports]    AS r ON u.[Id] = r.[UserId]
    JOIN [Categories] AS c ON r.[CategoryId] = c.[Id]
   WHERE DATEPART(DAY, u.[Birthdate]) = DATEPART(DAY, r.[OpenDate])
         AND DATEPART(MONTH, u.[Birthdate]) = DATEPART(MONTH, r.[OpenDate])
ORDER BY u.[Username]
         ,c.[Name]

---------------------------------------------------------------------------------------------------
-- 9 TASK User per Employee -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName]
          ,COUNT(DISTINCT r.[UserId])              AS [UsersCount]
     FROM [Employees] AS e
LEFT JOIN [Reports]   AS r ON e.[Id] = r.[EmployeeId]
 GROUP BY CONCAT(e.[FirstName], ' ', e.[LastName])
 ORDER BY [UsersCount] DESC
          ,[FullName]

---------------------------------------------------------------------------------------------------
-- 10 TASK Full Info ------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------  		 
   SELECT CASE
             WHEN r.[EmployeeId] IS NULL THEN 'None'
			 ELSE CONCAT(e.[FirstName], ' ', e.[LastName]) 
		  END                                                  AS [Employee]                
          ,ISNULL(d.[Name], 'None')                            AS [Department]
	      ,ISNULL(c.[Name], 'None')                            AS [Category]
	      ,ISNULL(r.[Description], 'None')                     AS [Description] 
	      ,ISNULL(FORMAT(r.[OpenDate], 'dd.MM.yyyy'), 'None')  AS [OpenDate]
	      ,ISNULL(s.[Label], 'None')                           AS [Status]
	      ,ISNULL(u.[Name],'None')                             AS [User]
     FROM [Reports]     AS r
LEFT JOIN [Employees]   AS e ON r.[EmployeeId] = e.[Id]
LEFT JOIN [Categories]  AS c ON r.[CategoryId] = c.[Id]
LEFT JOIN [Departments] AS d ON e.[DepartmentId] = d.[Id]
LEFT JOIN [Users]       AS u ON r.[UserId] = u.[Id]
LEFT JOIN [Status]      AS s ON r.[StatusId] = s.[Id]
ORDER BY e.[FirstName] DESC
         ,e.[LastName] DESC
		 ,d.[Name] 
		 ,c.[Name]
		 ,r.[Description]
		 ,r.[OpenDate]
		 ,s.[Label]
		 ,u.[Username]

---------------------------------------------------------------------------------------------------
-- 11 TASK Full Info ------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
	DECLARE @hours INT = DATEDIFF(HOUR, @StartDate, @EndDate) 

RETURN ISNULL(@hours, 0)	
END
GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports

---------------------------------------------------------------------------------------------------
-- 12 TASK Assign Employee ------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @employeeDepartment INT = (SELECT [DepartmentId] 
	                                     FROM [Employees]                                          
										WHERE [Id] = @EmployeeId
									   )	

	DECLARE @reportDepartment INT = (SELECT d.[Id] 
	                                   FROM [Reports]     AS r 
                                       JOIN [Categories]  AS c ON r.[CategoryId] = c.[Id]
									   JOIN [Departments] AS d ON c.[DepartmentId] = d.[Id]
									  WHERE r.[Id] = @ReportId
									)
									   
    IF(@employeeDepartment = @reportDepartment)	  
	     UPDATE [Reports]
		    SET [EmployeeId] = @EmployeeId
		  WHERE	[Id] = @ReportId	  
     ELSE
	   RAISERROR('Employee doesn''t belong to the appropriate department!',16, 1)
END
GO

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2