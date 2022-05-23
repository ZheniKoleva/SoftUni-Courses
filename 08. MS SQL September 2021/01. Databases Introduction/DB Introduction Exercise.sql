/***** Data Base Introduction EXERCISE *****/

---------------------------------------------------------------------------------------------------
-- 1 TASK Create Database--------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Minions]

USE [Minions]
GO

---------------------------------------------------------------------------------------------------
-- 2 TASK Create Tables----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE TABLE [Minions](
	 [Id]    INT          NOT NULL 
	,[Name]  NVARCHAR(50) NOT NULL
	,[Age]   INT 
)

   ALTER TABLE [Minions]             
ADD CONSTRAINT [PK_MinionsId] 
   PRIMARY KEY (Id)                  

DROP TABLE [Minions]

-----------
CREATE TABLE [Towns](
	         [Id]    INT PRIMARY KEY  NOT NULL  
	         ,[Name] NVARCHAR(50)     NOT NULL
)

---------------------------------------------------------------------------------------------------
-- 3 TASK Alter Minions Table----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
ALTER TABLE [Minions]
        ADD [TownId] INT

   ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsId] 
   FOREIGN KEY (TownId) 
    REFERENCES [Towns]([Id]) 

---------------------------------------------------------------------------------------------------
--4 TASK Insert Records in Both Tables ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Towns] ([Id], [Name]) 
     VALUES (1, 'Sofia')
	        ,(2, 'Plovdiv')
	        ,(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId]) 
     VALUES (1, 'Kevin', 22, 1)
	        ,(2, 'Bob', 15, 3)
	        ,(3, 'Steward', NULL, 2)

	   
---------------------------------------------------------------------------------------------------
-- 5 TASK Truncate Table Minions ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
TRUNCATE TABLE [Minions]

---------------------------------------------------------------------------------------------------
-- 6 TASK Drop All Tables -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DROP TABLE [Minions]

DROP TABLE [Towns]

---------------------------------------------------------------------------------------------------
-- 7 TASK Create Table People ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE TABLE [People](
	 [Id]        INT PRIMARY KEY IDENTITY NOT NULL 
	,[Name]      NVARCHAR(200)            NOT NULL
	,[Picture]   VARBINARY(2000)
	,[Height]    FLOAT(2)
	,[Weight]    FLOAT(2)
	,[Gender]    CHAR                     NOT NULL  
	,CHECK (Gender = 'm' OR Gender = 'f')
	,[Birthdate] DATE                     NOT NULL
	,[Biography] NVARCHAR(MAX) 
)

INSERT INTO [People]([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography]) 
     VALUES  ('Zheni', NULL, 1.54, 48, 'f', '1987-05-09','Ala bala')
		    ,('Stoyan', NULL, 1.80, 70, 'm', '1984-01-10','Ala bala nica')
		    ,('Petar', NULL, 1.73, 67, 'm', '1978-12-31','Ala bala')
		    ,('Georgi', NULL, 1.83, 76, 'm', '1992-09-17','Ala bala')
		    ,('Maria', NULL, 1.64, 51, 'f', '1989-11-21','Ala bala')

--DROP TABLE [People]

---------------------------------------------------------------------------------------------------
-- 8 TASK Create Table Users ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE TABLE [Users](
	[Id]              BIGINT PRIMARY KEY IDENTITY, /* AUTO INCEREMENTATION*/
	[Username]        VARCHAR(30) NOT NULL UNIQUE, /*DISTINGT VALUES*/
	[Password]        VARCHAR(26) NOT NULL,
	[ProfilePicture]  VARBINARY(MAX),
	CHECK (DATALENGTH ([ProfilePicture]) <= 900000), /* проверява размера на снимката да не надвишава даденият размер*/
	[LastLoginTime]   DATETIME2,
	[IsDeleted]       BIT NOT NULL,
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLOginTime], [IsDeleted])
     VALUES  ('Zheni', '123456', NULL, '2021-05-17', 'true'),
		     ('Stoyan', 'qawsed', NULL, '2021-05-02','false'),
		     ('Petar', 'RFTGYH765', NULL, '2021-09-15','false'),
		     ('Georgi', '2w3e4r1q', NULL, '2021-08-27','true'),
		     ('Maria', 'azqwsxedc453', NULL, '2021-07-03','true')

---------------------------------------------------------------------------------------------------
-- 9 TASK Change Primary Key ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
    ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC079A5D3080]

   ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] 
   PRIMARY KEY ([Id], [Username])


--------------------------------------------------------------------------------------------------
-- 10 TASK Add Check Constraint ------------------------------------------------------------------
--------------------------------------------------------------------------------------------------
ALTER TABLE [Users]
  ADD CHECK (DATALENGTH([Password]) >= 5)


---------------------------------------------------------------------------------------------------
-- 11 TASK Set Default Value of a Field -----------------------------------------------------------
---------------------------------------------------------------------------------------------------
   ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] 
       DEFAULT (CURRENT_TIMESTAMP) 
           FOR [LastLoginTime]

---------------------------------------------------------------------------------------------------
-- 12 TASK Set Unique Field -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
    ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]

   ALTER TABLE [Users]
ADD CONSTRAINT [PK_Id] 
   PRIMARY KEY ([Id])

   ALTER TABLE [Users]
ADD CONSTRAINT [UC_Username] 
        UNIQUE (DATALENGTH([Username]) >= 3)


---------------------------------------------------------------------------------------------------
-- 13 TASK Movies Database ------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Movies]

USE [Movies]
CREATE TABLE [Directors](
	 [Id]            INT PRIMARY KEY IDENTITY
	,[DirectorName]  VARCHAR(30) NOT NULL
	,[Notes]         VARCHAR(MAX)	
)

CREATE TABLE [Genres](
	 [Id]         INT PRIMARY KEY IDENTITY
	,[GenderName] VARCHAR(30) NOT NULL
	,[Notes]      VARCHAR(MAX)
)

CREATE TABLE [Categories](
	 [Id]           INT PRIMARY KEY IDENTITY
	,[CategoryName] VARCHAR(30) NOT NULL
	,[Notes]        VARCHAR(MAX)
)

CREATE TABLE [Movies](
	 [Id]             INT PRIMARY KEY IDENTITY
	,[Title]          VARCHAR(30) NOT NULL
	,[DirectorId]     INT FOREIGN KEY REFERENCES [Directors]([Id])
	,[CopyRightYear]  DATETIME2 DATEPART(YEAR, [CopyRightYear])
	,[Length]         DECIMAL(5,2)
	,[GenreId]        INT FOREIGN KEY REFERENCES [Genres]([Id])
	,[CategoryId]     INT FOREIGN KEY REFERENCES [Categories]([Id])
	,[Rating]         FLOAT(2)
	,[Notes]          VARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName], [Notes]) 
     VALUES	 ('Ala Bala', 'ahdafhksfhks')
            ,('Stoqn', 'zadjklalks')
            ,('Petar', NULL)
            ,('Ivan Ivanov', NULL)
            ,('Maria Petrova', NULL)

INSERT INTO [Genres] ([GenderName], [Notes]) 
     VALUES   ('comedy', NULL)
             ,('action', NULL)
		     ,('thriller', NULL)
		     ,('criminal', NULL)
		     ,('drama', NULL)

INSERT INTO [Categories] ([CategoryName], [Notes]) 
     VALUES	('fantasy', NULL)
		    ,('sci-fi', NULL)
		    ,('discovery', NULL)
		    ,('biography', NULL)
		    ,('war', NULL)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyRightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes]) 
     VALUES	('Spiderman', 2, NULL, 123.50, 3, 4, 6.7, NULL)
		    ,('Batman', 5, '1997', 89.00, 1, 3, NULL, 'alabala')
		    ,('Avengers', 3, '2019', NULL, 2, 1, 9.7, NULL)
		    ,('Dark', 4, NULL, 61.00, 4, 5, 9.9, NULL)
		    ,('Lost', 1, '2004', 48.30, 5, 2, 5.6, NULL)

--DROP TABLE [Movies]


---------------------------------------------------------------------------------------------------
-- 14 TASK Car Rental Database --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [CarRental]

CREATE TABLE [Categories](
	 [Id]           INT PRIMARY KEY IDENTITY
	,[CategoryName] VARCHAR(10)              NOT NULL
	,[DailyRate]    DECIMAL(5,2)             NOT NULL
	,[WeaklyRate]   DECIMAL(5,2)             NOT NULL
	,[MontlyRate]   DECIMAL(5,2)             NOT NULL
	,[WeekendRate]  DECIMAL(5,2)             NOT NULL
)

CREATE TABLE [Cars](
	 [Id]           INT PRIMARY KEY IDENTITY
	,[PlateNumber]  INT UNIQUE                    NOT NULL
	,[Manufacterer] VARCHAR(20)                   NOT NULL
	,[Model]		VARCHAR(20)                   NOT NULL
	,[CarYear]      INT                           NOT NULL
	,[CategoryId]   INT FOREIGN KEY REFERENCES [Categories]([Id])
	,[Doors]        TINYINT                       NOT NULL
	,[Picture]      VARBINARY(MAX)
	,[Condition]    VARCHAR(50)
	,[Available]    BIT                           NOT NULL
)

CREATE TABLE [Employees](
	 [Id]        INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(20)               NOT NULL
	,[LastName]  VARCHAR(20)               NOT NULL
	,[Title]     VARCHAR(10)               NOT NULL
	,[Notes]     VARCHAR(80)
)

CREATE TABLE [Customers](
	 [Id]                   INT PRIMARY KEY IDENTITY
	,[DriverLicenceNumber]  INT UNIQUE               NOT NULL
	,[FullName]             VARCHAR(40)              NOT NULL
	,[Address]              VARCHAR(50)              NOT NULL
	,[City]				    VARCHAR(20)              NOT NULL
	,[ZIPCode]              SMALLINT
	,[Notes]                VARCHAR(MAX)
)

CREATE TABLE [RentalOrders](
	 [Id]               INT PRIMARY KEY IDENTITY
	,[EmployeeId]       INT FOREIGN KEY REFERENCES [Employees]([Id])
	,[CustomerId]       INT FOREIGN KEY REFERENCES [Customers]([Id])
	,[CarId]            INT FOREIGN KEY REFERENCES [Cars]([Id])
	,[TankLevel]        TINYINT                                     NOT NULL
	,[KilometrageStart] DECIMAL(9,3)                                NOT NULL
	,[KilometrageEnd]   DECIMAL(9,3)                                NOT NULL
	,[TotalKilometrage] AS ([KilometrageEnd]-[KilometrageStart])
	,[StartDate]        DATETIME2                                   NOT NULL
	,[EndDate]          DATETIME2                                   NOT NULL
	,[TotalDays]        AS DATEDIFF(DAY, [StartDate], [EndDate])
	,[RateApplied]      DECIMAL(5,2)                                NOT NULL
    ,[TaxRate]          DECIMAL DEFAULT 0.20
    ,[OrderStatus]      VARCHAR(20)                                 NOT NULL
    ,[Notes]            NVARCHAR(MAX)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeaklyRate], [MontlyRate], [WeekendRate])
     VALUES	 ('sedan', 60, 350, 900, 100.00)
		    ,('combi', 70.00, 320.00, 700.00, 100.00)
		    ,('suv', 85.00, 400.00, 980.00, 150.00)

INSERT INTO [Cars]([PlateNumber], [Manufacterer], [Model],[CarYear], [CategoryId], [Doors], [Picture], [Condition],[Available] )
     VALUES	('123456', 'Toyota', 'CHR', 2020, 3, 5, NULL, 'Perfect', 1)
           ,('673829282', 'Honda', 'Jazz', 2017, 1, 3, NULL, 'Perfect', 1)
           ,('234343546', 'Peugeout', '307', 2013, 2, 5, NULL, 'Perfect', 1)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
     VALUES	 ('Ivan', 'Petrov', 'Manager', NULL)
		    ,('Stoyan', 'Georgiev', 'Seller', 'out of office')
		    ,('Marya', 'Dimitrova', 'Seller', NULL)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
     VALUES (123456789, 'Ivan Georgiev', '3 Lozengrad Str.', 'Varna', 9002, NULL)
            ,(236749092, 'Dimitar Petrov', '17 Mladezhka Str.' , 'Varna', NULL, 'drive good')
            ,(678423823, 'Ivanka Stoyanova', '45 Mir Str.', 'Varna', 9010, NULL)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [OrderStatus], [Notes]) 
     VALUES (1, 2, 2, 60, 34567, 35489, '2021-09-01', '2021-09-05', 60.00, 'complete', NULL)
            ,(3, 1, 3, 65, 13565, 13565, '2021-09-03', '2021-09-10', 320.00, 'refused', NULL)
            ,(3, 3, 1, 80, 23455, 24678, '2021-09-12', '2021-10-12', 980.00, 'complete', NULL)
					   
---------------------------------------------------------------------------------------------------
-- 15 TASK Hotel Database -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Hotel]

CREATE TABLE [Employees](
	 [Id]		 INT PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(20)     NOT NULL
	,[LastName]	 NVARCHAR(20)     NOT NULL
	,[Title]	 NVARCHAR(30)     NOT NULL
	,[Notes]	 NVARCHAR(120)
)

INSERT INTO [Employees]([FirstName],[LastName], [Title], [Notes])
     VALUES	 ('Ivan', 'Petrov', 'manager', 'out of office')
		    ,('Petya', 'Stoyanova', 'receptionist', NULL)
		    ,('Drago', 'Dimitrov', 'bartender', NULL)

CREATE TABLE [Customers](	
	 [AccountNumber]    SMALLINT PRIMARY KEY IDENTITY
	,[FirstName]	    NVARCHAR(20)     NOT NULL
	,[LastName]		    NVARCHAR(20)     NOT NULL
	,[PhoneNumber]	    INT UNIQUE       NOT NULL
	,[EmergencyName]	NVARCHAR(40)
	,[EmergencyNumber]  INT	
	,[Notes]            NVARCHAR(120)
)

INSERT INTO [Customers]([FirstName],[LastName],[PhoneNumber],[EmergencyName],[EmergencyNumber], [Notes])
     VALUES  ('Ivan', 'Ivanov', 0898123456, NULL, NULL, NULL)
	        ,('Mariya', 'Petrova', 0888987654, 'Dimitar Petrov', 0888134678, NULL)
	        ,('Georgi', 'Kirilov', 0876543234, NULL, NULL, NULL)

CREATE TABLE [RoomStatus](
	 [Id]         INT PRIMARY KEY IDENTITY
	,[RoomStatus] VARCHAR(30) NOT NULL
	,[Notes]      VARCHAR(30)
)


INSERT INTO [RoomStatus]([RoomStatus], [Notes])
     VALUES	 ('free', NULL)
		    ,('occupied', NULL)
		    ,('under repair', NULL)

CREATE TABLE [RoomTypes](
	 [Id]       INT PRIMARY KEY IDENTITY
	,[RoomType] NVARCHAR(10) NOT NULL
	,[Notes]    VARCHAR(20)
)

INSERT INTO [RoomTypes]([RoomType], [Notes])
     VALUES	('regular', NULL)
		   ,('apartment', NULL)
		   ,('luxury', NULL)

CREATE TABLE [BedTypes](
	 [Id]      INT PRIMARY KEY IDENTITY
	,[BedType] NVARCHAR(20) NOT NULL
	,[Notes]   NVARCHAR(30)
)

INSERT INTO [BedTypes]([BedType], [Notes])
     VALUES	('single', NULL)
		    ,('double', NULL)
		    ,('two single beds', NULL)

CREATE TABLE [Rooms](
	 [RoomNumber]  TINYINT PRIMARY KEY IDENTITY
	,[RoomType]    INT FOREIGN KEY REFERENCES [RoomTypes]([Id])
	,[BedType]     INT FOREIGN KEY REFERENCES [BedTypes]([Id])
	,[Rate]        MONEY NOT NULL
	,[RoomStatus]  INT FOREIGN KEY REFERENCES [RoomStatus]([Id])
	,[Notes]       NVARCHAR(MAX)
)

INSERT INTO [Rooms]([RoomType], [BedType], [Rate], [RoomStatus], [Notes])
     VALUES	(1, 1, 50.00, 1, NULL) /* regular, single, 50, free */
		    ,(2, 2, 65.00, 2, NULL) /* apartment, double, 65, occupied */
		    ,(3, 3, 80.00, 3, NULL) /* luxury, two single beds, 80, under repair */

CREATE TABLE [Payments](
	 [Id]				 INT PRIMARY KEY IDENTITY(1,1)
	,[EmployeeId]		 INT FOREIGN KEY REFERENCES [Employees]([Id])                 NOT NULL
	,[PaymentDate]		 DATETIME2
	,[AccountNumber]	 SMALLINT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL
	,[FirstDateOccupied] DATETIME2                                                    NOT NULL
	,[LastDateOccupied]  DATETIME2                                                    NOT NULL
	,[TotalDays]		 AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied])
	,[AmountCharged]	 MONEY                                                        NOT NULL
	,[TaxRate]			 DECIMAL(5,2) DEFAULT 0.20 
	,[TaxAmount]		 AS ([AmountCharged] * [TaxRate])
	,[PaymentTotal]		 AS [AmountCharged]
	,[Notes]			 NVARCHAR(MAX)
)

INSERT INTO [Payments]([EmployeeId], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged])
     VALUES	(2, 1, '2021-09-15', '2021-09-18', 195.00) /* receptionist */
		    ,(3, 2, '2021-09-16', '2021-09-17', 50.00) /* bartender, */
		    ,(2, 3, '2021-09-17', '2021-09-21', 150.00) /* receptionist*/


CREATE TABLE [Occupancies](
	 [Id ]			 INT PRIMARY KEY IDENTITY
	,[EmployeeId]	 INT FOREIGN KEY REFERENCES [Employees]([Id])                 NOT NULL
	,[DateOccupied]  DATETIME2
	,[AccountNumber] SMALLINT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL
	,[RoomNumber]	 TINYINT FOREIGN KEY REFERENCES [Rooms]([RoomNumber])         NOT NULL
	,[RateApplied]   DECIMAL(5,2)
	,[PhoneCharge]	 BIT
	,[Notes]		 NVARCHAR(MAX)
)

INSERT INTO [Occupancies]([EmployeeId], [AccountNumber], [RoomNumber], [RateApplied])
     VALUES	(2, 1, 2, 0.20)
		    ,(3, 2, 1, 0.10)
		    ,(2, 3, 2, 0.15) 


---------------------------------------------------------------------------------------------------
-- 16 TASK Create SoftUni Database ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [SoftUni]

CREATE TABLE [Towns](
	 [Id]    INT IDENTITY(1,1)
	,[Name]  NVARCHAR(30)      NOT NULL	
)

   ALTER TABLE [Towns]
ADD CONSTRAINT [PK_TownId] 
   PRIMARY KEY ([Id])

CREATE TABLE [Addresses](
	 [Id]          INT PRIMARY KEY IDENTITY(1,1)
	,[AddressText] NVARCHAR(80)                  NOT NULL
	,[TownId]      INT                           NOT NULL	
)

   ALTER TABLE [Addresses]
ADD CONSTRAINT [FK_AddressTown] 
   FOREIGN KEY (TownId) 
    REFERENCES [Towns]([Id])

CREATE TABLE [Departments](
	 [Id]   INT IDENTITY(1,1)
	,[Name] NVARCHAR(80)          NOT NULL
    ,CONSTRAINT [PK_DepartmentId] 
    ,PRIMARY KEY (Id)	
)

CREATE TABLE [Employees](
	 [Id]           INT IDENTITY(1,1)
	,[FirstName]    NVARCHAR(30)      NOT NULL
	,[MiddleName]   NVARCHAR(30)      NOT NULL
	,[LastName]     NVARCHAR(30)      NOT NULL
	,[JobTitle]	    NVARCHAR(50)      NOT NULL
	,[DepartmentId] INT               NOT NULL
	,[HireDate]     DATETIME2         NOT NULL
	,[Salary]       DECIMAL(6,2)      NOT NULL
	,[AddressId]    INT
)

   ALTER TABLE [Employees]
ADD CONSTRAINT [PK_EmployeeId] 
   PRIMARY KEY (Id)
    ,CONSTRAINT [FK_EmployeeDepartment]
   FOREIGN KEY (DepartmentId) 
    REFERENCES [Departments]([Id])
    ,CONSTRAINT [FK_EmployeeAddress]
   FOREIGN KEY (AddressId) 
    REFERENCES [Addresses]([Id])
	   
---------------------------------------------------------------------------------------------------
-- 17 TASK Backup Database ------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [master]
GO
DROP DATABASE [SoftUni]
GO

---------------------------------------------------------------------------------------------------
-- 18 TASK ----------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO [Towns]([Name])
    VALUES	('Sofia')
		    ,('Plovdiv')
		    ,('Varna')
		    ,('Burgas')

INSERT INTO [Departments]([Name])
     VALUES	('Engineering')
		    ,('Sales')
		    ,('Marketing')
		    ,('Software Development')
		    ,('Quality Assurance')


INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate], [Salary],[AddressId])
     VALUES	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, NULL)
		    ,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, NULL)
		    ,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, NULL)
		    ,('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, NULL)
		    ,('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 598.88, NULL)

---------------------------------------------------------------------------------------------------
-- 19 TASK Basic Select All Fields ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]


---------------------------------------------------------------------------------------------------
--20 TASK Basic Select All Fields and Order Them --------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT * FROM [Towns]
ORDER BY [Name] ASC

  SELECT * FROM [Departments]
ORDER BY [Name] ASC

  SELECT * FROM [Employees]
ORDER BY [Salary] DESC


---------------------------------------------------------------------------------------------------
--21 TASK Basic Select Some Fields ----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [SoftUni]

  SELECT [Name] FROM [Towns]
ORDER BY [Name] ASC

  SELECT [Name] FROM [Departments]
ORDER BY [Name] ASC

  SELECT [FirstName], [LastName], [JobTitle], [Salary] 
    FROM [Employees]
ORDER BY [Salary] DESC


--------------------------------------------------------------------------------------------------
--22 TASK Increase Employees Salary --------------------------------------------------------------
--------------------------------------------------------------------------------------------------
USE [SoftUni]

UPDATE [Employees]
   SET [Salary] *= 1.10

SELECT [Salary] FROM [Employees]


---------------------------------------------------------------------------------------------------
--23 TASK Decrease Tax Rate -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Hotel]

UPDATE [Payments]
   SET [TaxRate] *= 0.97

SELECT [TaxRate] FROM [Payments]

---------------------------------------------------------------------------------------------------
--24 TASK Delete All Records ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Hotel]

TRUNCATE TABLE [Occupancies]
