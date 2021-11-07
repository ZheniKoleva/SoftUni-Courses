/***** Databases MSSQL Server Exam - 16 October 2021 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [CigarShop]
GO 

USE [CigarShop]
GO

CREATE TABLE Sizes(
	Id         INT PRIMARY KEY IDENTITY NOT NULL
	,[Length]  INT                      NOT NULL
	,RingRange DECIMAL(3,2)             NOT NULL
	,CHECK ([Length] BETWEEN 10 AND 25)
	,CHECK (RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes(
    Id             INT PRIMARY KEY IDENTITY NOT NULL
	,TasteType     VARCHAR(20)              NOT NULL
	,TasteStrength VARCHAR(15)              NOT NULL
	,ImageURL      NVARCHAR(100)            NOT NULL
)

CREATE TABLE Brands(
	 Id               INT PRIMARY KEY IDENTITY NOT NULL
	,BrandName        VARCHAR(30) UNIQUE       NOT NULL
	,BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
	 Id                  INT PRIMARY KEY IDENTITY              NOT NULL
	,CigarName           VARCHAR(80)                           NOT NULL
	,BrandId             INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL
	,TastId              INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL
	,SizeId              INT FOREIGN KEY REFERENCES Sizes(Id)  NOT NULL
	,PriceForSingleCigar DECIMAL(18,2)                         NOT NULL
	,ImageURL            NVARCHAR(100)                         NOT NULL
)

CREATE TABLE Addresses(
	 Id      INT PRIMARY KEY IDENTITY NOT NULL
	,Town    VARCHAR(30)              NOT NULL
	,Country NVARCHAR(30)             NOT NULL
	,Streat  NVARCHAR(100)            NOT NULL
	,ZIP     VARCHAR(20)              NOT NULL
)

CREATE TABLE Clients(
	Id         INT PRIMARY KEY IDENTITY                     NOT NULL
	,FirstName NVARCHAR(30)                                 NOT NULL
	,LastName  NVARCHAR(30)                                 NOT NULL
	,Email     NVARCHAR(30)                                 NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE ClientsCigars(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
	,CigarId INT FOREIGN KEY REFERENCES Cigars(Id)  NOT NULL
	,PRIMARY KEY(ClientId, CigarId)
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
     VALUES ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg')
            ,('COHIBA SIGLO I',	9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg')
            ,('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg')
            ,('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg')
            ,('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
    VALUES ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000)
           ,('Athens', 'Greece', '4342 McDonald Avenue', 10435)
           ,('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE Cigars
   SET PriceForSingleCigar *= 1.20
 WHERE TastId IN (SELECT Id 
                   FROM Tastes 
				  WHERE TasteType IN ('Spicy')
				 )

UPDATE Brands
   SET BrandDescription = 'New description'
 WHERE BrandDescription IS NULL

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM Clients
      WHERE AddressId IN (SELECT Id 
	                        FROM Addresses
						   WHERE Country LIKE ('C%')
						  )

DELETE FROM Addresses
      WHERE Country LIKE ('C%')

-----------
DELETE FROM Clients
      WHERE AddressId IN (SELECT Id 
	                        FROM Addresses
						   WHERE LEFT(Country, 1) IN ('C')
						  )

DELETE FROM Addresses
      WHERE LEFT(Country, 1) IN ('C')
---------------------------------------------------------------------------------------------------
-- 5 TASK Cigars by Price -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE master
DROP DATABASE [CigarShop]
GO
USE [CigarShop]
GO

   SELECT CigarName
         ,PriceForSingleCigar
		 ,ImageURL
    FROM Cigars
ORDER BY PriceForSingleCigar
         ,CigarName DESC

---------------------------------------------------------------------------------------------------
-- 6 TASK Cigars by Taste -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT c.Id
         ,c.CigarName
	     ,c.PriceForSingleCigar
	     ,t.TasteType
	     ,t.TasteStrength
    FROM Cigars  AS c
    JOIN Tastes  AS t ON c.TastId = t.Id
   WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

---------------------------------------------------------------------------------------------------
-- 7 TASK Clients without Cigars ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT Id
         ,CONCAT(FirstName, ' ', LastName) AS ClientName
		 ,Email
    FROM Clients 
   WHERE Id NOT IN (SELECT DISTINCT ClientId 
	                           FROM ClientsCigars)
ORDER BY ClientName 

---------------------------------------------------------------------------------------------------
-- 8 TASK First 5 Cigars --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT TOP(5)
         c.CigarName
         ,c.PriceForSingleCigar
		 ,c.ImageURL 
    FROM  Cigars AS c
    JOIN Sizes   AS s ON c.SizeId = s.Id
   WHERE s.[Length] >= 12.0 
         AND (c.CigarName LIKE ('%ci%') OR (c.PriceForSingleCigar > 50.0 AND s.RingRange > 2.55))
ORDER BY c.CigarName
         ,c.PriceForSingleCigar DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Clients with ZIP Codes ------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT CONCAT(cl.FirstName, ' ', cl.LastName) AS FullName
        ,a.Country
		,a.ZIP
         ,CONCAT('$',MAX(c.PriceForSingleCigar))
    FROM Clients       AS cl
    JOIN ClientsCigars AS cc ON cl.Id = cc.ClientId
    JOIN Cigars        AS c  ON cc.CigarId = c.Id
	JOIN Addresses     AS a  ON cl.AddressId = a.Id
   WHERE cl.Id IN (SELECT c.Id 
                     FROM Clients   AS c
                     JOIN Addresses AS a ON c.AddressId = a.Id
                    WHERE ZIP NOT LIKE ('%[^0-9]%')
                   )
GROUP BY cl.Id, cl.FirstName, cl.LastName, a.Country, a.ZIP
ORDER BY FullName

-----------------
  SELECT CONCAT(cl.FirstName, ' ', cl.LastName) AS FullName
        ,a.Country
		,a.ZIP
         ,CONCAT('$',MAX(c.PriceForSingleCigar))
    FROM Clients       AS cl
    JOIN ClientsCigars AS cc ON cl.Id = cc.ClientId
    JOIN Cigars        AS c  ON cc.CigarId = c.Id
	JOIN Addresses     AS a  ON cl.AddressId = a.Id
   WHERE ISNUMERIC(a.ZIP) = 1                    
GROUP BY cl.Id, cl.FirstName, cl.LastName, a.Country, a.ZIP
ORDER BY FullName

---------------------------------------------------------------------------------------------------
-- 10 TASK Cigars by Size -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT cl.LastName
         ,AVG(s.[Length])           AS CigarLength
	     ,CEILING(AVG(s.RingRange)) AS CiagrRingRange
    FROM Clients       AS cl
    JOIN ClientsCigars AS cc ON cl.Id = cc.ClientId
    JOIN Cigars        AS c  ON cc.CigarId = c.Id
    JOIN Sizes         AS s  ON c.SizeId = s.Id
GROUP BY cl.LastName
ORDER BY CigarLength DESC

---------------------------------------------------------------------------------------------------
-- 11 TASK Client with Cigars ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
  BEGIN
	DECLARE @cigarsCount INT = (SELECT COUNT(*) 
	                              FROM ClientsCigars AS cc
								  JOIN Clients       AS c ON cc.ClientId = c.Id
								 WHERE c.FirstName = @name
								)
    RETURN ISNULL(@cigarsCount, 0)
  END
GO

SELECT dbo.udf_ClientWithCigars('Betty')

---------------------------------------------------------------------------------------------------
-- 12 TASK Search for Cigar with Specific Taste ---------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE PROC usp_SearchByTaste @taste VARCHAR(20)
AS
  BEGIN
	SELECT c.CigarName                         AS CigarName
	       ,CONCAT('$',c.PriceForSingleCigar)  AS Price
		   ,t.TasteType                        AS TasteType
		   ,b.BrandName                        AS BrandName
		   ,CONCAT(s.[Length], ' cm')          AS CigarLength
		   ,CONCAT(s.RingRange, ' cm')         AS CigarRingRange
	  FROM Cigars AS c
	  JOIN Tastes AS t ON c.TastId = t.Id
	  JOIN Sizes  AS s ON c.SizeId = s.Id
	  JOIN Brands AS b ON c.BrandId = b.Id
	 WHERE t.TasteType = @taste
  ORDER BY s.[Length] 
           ,s.RingRange DESC
  END
GO

EXEC usp_SearchByTaste 'Woody'
