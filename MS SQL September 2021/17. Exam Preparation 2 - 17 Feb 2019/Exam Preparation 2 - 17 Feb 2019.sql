/***** Exam Preparation 2 - 17 Feb 2019 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [School]
GO

USE [School]
GO

CREATE TABLE [Students](
	[Id]          INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName]  NVARCHAR(30)             NOT NULL
	,[MiddleName] NVARCHAR(25)
	,[LastName]   NVARCHAR(30)             NOT NULL
	,[Age]        INT                      NOT NULL
	,[Address]    NVARCHAR(50)
	,[Phone]      NCHAR(10)
	,CHECK ([Age] BETWEEN 5 AND 100)
)

CREATE TABLE [Subjects](
	[Id]       INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]    NVARCHAR(20)             NOT NULL
	,[Lessons] INT                      NOT NULL
	,CHECK ([Lessons] > 0)
)

CREATE TABLE [StudentsSubjects](
	[Id]         INT PRIMARY KEY IDENTITY                    NOT NULL
	,[StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL
	,[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
	,[Grade]     DECIMAL(3,2)                                NOT NULL
	,CHECK ([Grade] BETWEEN 2 AND 6)
)

CREATE TABLE [Exams](
	[Id]         INT PRIMARY KEY IDENTITY                    NOT NULL
	,[Date]      DATETIME
	,[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentId] INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL
	,[ExamId]   INT FOREIGN KEY REFERENCES [Exams]([Id])    NOT NULL
	,[Grade]     DECIMAL(3,2)                               NOT NULL
	,CHECK ([Grade] BETWEEN 2 AND 6)
	,PRIMARY KEY([StudentId], [ExamId])
)

CREATE TABLE [Teachers](
	[Id]         INT PRIMARY KEY IDENTITY                    NOT NULL
	,[FirstName] NVARCHAR(20)                                NOT NULL
	,[LastName]  NVARCHAR(20)                                NOT NULL 
	,[Address]   NVARCHAR(20)                                NOT NULL 
	,[Phone]     NCHAR(10)
	,[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL
)

CREATE TABLE [StudentsTeachers](
	[StudentId]  INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL
	,[TeacherId] INT FOREIGN KEY REFERENCES [Teachers]([Id]) NOT NULL
	,PRIMARY KEY([StudentId], [TeacherId])
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Teachers]([FirstName], [LastName], [Address], [Phone], [SubjectId])
     VALUES ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146',6)
            ,('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2)
            ,('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5)
            ,('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO [Subjects]([Name], [Lessons])
     VALUES ('Geometry', 12)
            ,('Health',	10)
            ,('Drama', 7)
            ,('Sports',	9)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE [StudentsSubjects]
   SET [Grade] = 6.00
 WHERE [SubjectId] IN (1,2) AND [Grade] >= 5.50

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM [StudentsTeachers]
      WHERE [TeacherId] IN (SELECT [Id] 
	                          FROM [Teachers]
							  WHERE [Phone] IS NOT NULL AND [Phone] LIKE ('%72%')	   
	                        )

DELETE FROM [Teachers]
      WHERE [Phone] IS NOT NULL AND [Phone] LIKE ('%72%') 

--2
DELETE FROM [StudentsTeachers]
      WHERE [TeacherId] IN (SELECT [Id] 
	                          FROM [Teachers]
							  WHERE [Phone] IS NOT NULL AND CHARINDEX('72', [Phone]) > 0	   
	                        )

DELETE FROM [Teachers]
      WHERE [Phone] IS NOT NULL AND CHARINDEX('72', [Phone]) > 0 

---------------------------------------------------------------------------------------------------
-- 5 TASK Teen Students ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT [FirstName]
         ,[LastName]
		 ,[Age]
    FROM [Students]
   WHERE [Age] >= 12
ORDER BY [FirstName], [LastName]

---------------------------------------------------------------------------------------------------
-- 6 TASK Students Teachers -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT s.[FirstName]
         ,s.[LastName]
		 ,COUNT(st.[TeacherId])  AS [TeachersCount]
    FROM [Students] AS s
    JOIN [StudentsTeachers] AS st ON s.[Id] = st.[StudentId]
GROUP BY s.[Id], s.[FirstName], s.[LastName]
ORDER BY s.[LastName]

---------------------------------------------------------------------------------------------------
-- 7 TASK Students to Go --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT([FirstName], ' ', [LastName])  AS [Full Name] 
    FROM [Students]
   WHERE [Id] NOT IN (SELECT DISTINCT [StudentId] 
                                 FROM [StudentsExams]
   				     )
ORDER BY [Full Name] 

--2
   SELECT CONCAT([FirstName], ' ', [LastName])  AS [Full Name]
     FROM [Students]      AS s
LEFT JOIN [StudentsExams] AS se ON s.[Id] = se.[StudentId]
    WHERE se.[ExamId] IS NULL
 ORDER BY [Full Name]

---------------------------------------------------------------------------------------------------
-- 8 TASK Top Students ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT TOP(10)
         s.[FirstName]
         ,s.[LastName]
         ,CAST((AVG(se.[Grade])) AS DECIMAL(3,2))   AS [Grade]
    FROM [StudentsExams] AS se
    JOIN [Students]      AS s  ON se.[StudentId] = s.[Id]
GROUP BY s.[Id], s.[FirstName], s.[LastName]
ORDER BY [Grade] DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Not So In The Studying ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
   SELECT CONCAT([FirstName], ' ', ISNULL([MiddleName] + ' ' ,''), [LastName]) AS [Full Name]
    FROM [Students]
   WHERE [Id] NOT IN (SELECT DISTINCT [StudentId]  
                                 FROM [StudentsSubjects])
ORDER BY [Full Name]

--2
   SELECT CONCAT(s.[FirstName], ' ', ISNULL(s.[MiddleName] + ' ' ,''), s.[LastName]) AS [Full Name]
     FROM [Students]  AS s
LEFT JOIN [StudentsSubjects] AS ss ON s.[Id] = ss.[StudentId]
    WHERE ss.[SubjectId] IS NULL
ORDER BY [Full Name]

---------------------------------------------------------------------------------------------------
-- 10 TASK Average Grade per Subject --------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT s.[Name]
         ,AVG(ss.[Grade])  AS [AverageGrade]
    FROM [Subjects]         AS s
    JOIN [StudentsSubjects] AS ss ON s.[Id] = ss.[SubjectId]   
GROUP BY s.[Id], s.[Name]
ORDER BY s.[Id]

---------------------------------------------------------------------------------------------------
-- 11 TASK Exam Grades ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(100)
AS
BEGIN
   IF(NOT EXISTS (SELECT [Id] FROM [Students] WHERE [Id] = @studentId))
	 RETURN 'The student with provided id does not exist in the school!'	
   
   IF(@grade > 6.00)
	 RETURN 'Grade cannot be above 6.00!'	

   DECLARE @studentName VARCHAR(30) = (SELECT [FirstName] FROM [Students] WHERE [Id] =  @studentId)

   DECLARE @gradesCount INT = (SELECT COUNT(*)
                                 FROM [StudentsSubjects]
								WHERE [StudentId] = @studentId 
								      AND [Grade] > @grade AND [Grade] <= (@grade + 0.50)
                              )

   RETURN CONCAT('You have to update ', @gradesCount,' grades for the student ',  @studentName)
END
GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

---------------------------------------------------------------------------------------------------
-- 12 TASK Exclude From School --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN TRANSACTION
	IF(NOT EXISTS (SELECT [Id] FROM [Students] WHERE [Id] = @StudentId))
	  BEGIN
	    ROLLBACK
		RAISERROR('This school has no student with the provided id!', 16, 1)
	  END
    ELSE
	  BEGIN
        DELETE FROM [StudentsTeachers]
              WHERE [StudentId] = @StudentId
        
        DELETE FROM [StudentsSubjects]
              WHERE [StudentId] = @StudentId
        
        DELETE FROM [StudentsExams]
              WHERE [StudentId] = @StudentId
        
        DELETE FROM [Students]
              WHERE [Id] = @StudentId
	  END
COMMIT
GO

--2
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN 
	IF(NOT EXISTS (SELECT [Id] FROM [Students] WHERE [Id] = @StudentId))
	  BEGIN	    
		RAISERROR('This school has no student with the provided id!', 16, 1)
	  END    
	 
    DELETE FROM [StudentsTeachers]
          WHERE [StudentId] = @StudentId
    
    DELETE FROM [StudentsSubjects]
          WHERE [StudentId] = @StudentId
    
    DELETE FROM [StudentsExams]
          WHERE [StudentId] = @StudentId
    
    DELETE FROM [Students]
          WHERE [Id] = @StudentId
	 
END
GO

EXEC usp_ExcludeFromSchool 301

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) 
  FROM Students