/****** Table Relations Exercise *****/

---------------------------------------------------------------------------------------------------
-- 1 TASK One-To-One Relationship -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE TableRelations

USE TableRelations

CREATE TABLE Passports(
	 PassportID       INT PRIMARY KEY IDENTITY(101,1) NOT NULL
	,PassportNumber   VARCHAR(10) UNIQUE              NOT NULL 
)

CREATE TABLE Persons(
	 PersonID     INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName    VARCHAR(20)              NOT NULL
	,Salary       DECIMAL(8,2)             NOT NULL
	,PassportID   INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
)

INSERT INTO  Passports (PassportNumber)
	 VALUES  ('N34FG21B')
	        ,('K65LO4R7')
			,('ZE657QP2')

INSERT INTO  Persons(FirstName,Salary, PassportID)
	 VALUES  ('Roberto', 43300.00, 102)
			,('Tom', 56100.00, 103)
			,('Yana', 60200.00, 101)

---------------------------------------------------------------------------------------------------
-- 2 TASK One-To-Many Relationship ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [TableRelations]

CREATE TABLE [Manufacturers](
	 [ManufacturerID]  INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]            VARCHAR(20)              NOT NULL
	,[EstablishedOn]   DATE                     NOT NULL
)

CREATE TABLE [Models](
	 [ModelID]         INT PRIMARY KEY IDENTITY(101,1) NOT NULL
	,[Name]            VARCHAR(20)                     NOT NULL
	,[ManufacturerID]  INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO  [Manufacturers]([Name], [EstablishedOn])
	 VALUES  ('BMW', '07/03/1916')
			,('Tesla', '01/01/2003')
			,('Lada', '01/05/1996')

INSERT INTO  [Models]([Name], [ManufacturerID])
	 VALUES  ('X1', 1)
			,('i6', 1)
			,('Model S', 2)
			,('Model X', 2)
			,('Model 3', 2)
			,('Nova', 3)

---------------------------------------------------------------------------------------------------
-- 3 TASK Many-To-Many Relationship ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE TableRelations

CREATE TABLE [Students](
	 [StudentID]  INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]       VARCHAR(10)              NOT NULL
)

CREATE TABLE [Exams](
	 [ExamID]  INT PRIMARY KEY IDENTITY(101,1) NOT NULL
	,[Name]    VARCHAR(30)                     NOT NULL
)

CREATE TABLE [StudentsExams](
	 [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
	,[ExamID]    INT FOREIGN KEY REFERENCES [Exams]([ExamID])       NOT NULL
	,CONSTRAINT  INT PRIMARY KEY ([StudentID], [ExamID]) 
)

INSERT INTO  [Students]([Name])
	 VALUES  ('Mila')
			,('Toni')
			,('Ron')

INSERT INTO  [Exams]([Name])
	 VALUES  ('SpringMVC')
			,('Neo4j')
			,('Oracle 11g')

INSERT INTO  [StudentsExams]([StudentID], [ExamID])
	 VALUES  (1, 101)
		    ,(1, 102)
			,(2, 101)
			,(3, 103)
			,(2, 102)
			,(2, 103)

---------------------------------------------------------------------------------------------------
-- 4 TASK Self-Referencing ------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [TableRelations]

CREATE TABLE [Teachers](
	 [TeacherID]  INT PRIMARY KEY IDENTITY(101,1) NOT NULL
	,[Name]       VARCHAR(20)                     NOT NULL
	,[ManagerID]  INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO  [Teachers]([Name], [ManagerID])
	 VALUES  ('John', NULL)
	        ,('Maya', 106)
			,('Silvia', 106)
			,('Ted', 105)
			,('Mark', 101)
			,('Greta', 101)

---------------------------------------------------------------------------------------------------
-- 5 TASK Online Store Database -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [OnlineStoreData]

USE [OnlineStoreData]

CREATE TABLE [ItemTypes](
	 [ItemTypesID]  INT PRIMARY KEY IDENTITY
	,[Name]         VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	 [ItemID]      INT PRIMARY KEY IDENTITY
	,[Name]        VARCHAR(50) NOT NULL
	,[ItemTypeID]  INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypesID]) NOT NULL
)

CREATE TABLE [Cities](
	 [CityID] INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	 [CustomerID] INT PRIMARY KEY IDENTITY
	,[Name]       VARCHAR(50) NOT NULL
	,[Birthday]   DATETIME2
	,[CityID]     INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE [Orders](
	 [OrderID]     INT PRIMARY KEY IDENTITY NOT NULL	
	,[CustomerID]  INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL	
)

CREATE TABLE [OrderItems](
	 [OrderID]  INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL
	,[ItemID]   INT FOREIGN KEY REFERENCES [Items]([ItemID])   NOT NULL
	,PRIMARY KEY ([OrderID], [ItemID])
)

---------------------------------------------------------------------------------------------------
-- 6 TASK University Database ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects](
	 [SubjectID]    INT PRIMARY KEY IDENTITY NOT NULL
	,[SubjectName]  VARCHAR(20)              NOT NULL
)

CREATE TABLE [Majors](
	 [MajorID]  INT PRIMARY KEY IDENTITY NOT NULL
	,[Name]     VARCHAR(20)              NOT NULL
)

CREATE TABLE [Students](
	 [StudentID]      INT PRIMARY KEY IDENTITY NOT NULL
	,[StudentNumber]  VARCHAR(8)               NOT NULL
	,[StudentName]    VARCHAR(50)              NOT NULL
	,[MajorID]        INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments](
	 [PaymentID]      INT PRIMARY KEY IDENTITY NOT NULL
	,[PaymentDate]    DATETIME2                NOT NULL
	,[PaymentAccount] VARCHAR(20)              NOT NULL
	,[StudentID]      INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE [Agenda](
	 [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
	,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL
	,PRIMARY KEY ([StudentID],[SubjectID])
)


---------------------------------------------------------------------------------------------------
-- 9 TASK Peaks in Rila ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Geography]

  SELECT  m.MountainRange, p.PeakName, p.Elevation
    FROM  Mountains AS m
    JOIN  Peaks AS p ON p.MountainId = m.Id
   WHERE  m.MountainRange = 'Rila'
ORDER BY  p.Elevation DESC

