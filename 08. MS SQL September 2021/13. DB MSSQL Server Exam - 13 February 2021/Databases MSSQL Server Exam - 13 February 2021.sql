/***** Databases MSSQL Server Exam - 13 February 2021 *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK DDL -------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE DATABASE [Bitbucket]
GO

USE [Bitbucket]
GO

CREATE TABLE Users(
	Id          INT PRIMARY KEY IDENTITY NOT NULL
	,Username   VARCHAR(30)              NOT NULL
	,[Password] VARCHAR(30)              NOT NULL
	,Email      VARCHAR(50)              NOT NULL
)

CREATE TABLE Repositories(
	Id      INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50)              NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId   INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
	,ContributorId INT FOREIGN KEY REFERENCES Users(Id)        NOT NULL
	,PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id            INT PRIMARY KEY IDENTITY                    NOT NULL
	,Title        VARCHAR(MAX)                                NOT NULL
	,IssueStatus  VARCHAR(6)                                  NOT NULL 
	,RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
	,AssigneeId   INT FOREIGN KEY REFERENCES Users(Id)        NOT NULL	
)

CREATE TABLE Commits(
	Id             INT PRIMARY KEY IDENTITY                    NOT NULL
	,[Message]     VARCHAR(MAX)                                NOT NULL
	,IssueId       INT FOREIGN KEY REFERENCES Issues(Id) 
	,RepositoryId  INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
	,ContributorId INT FOREIGN KEY REFERENCES Users(Id)        NOT NULL
)

CREATE TABLE Files(
	Id        INT PRIMARY KEY IDENTITY              NOT NULL
	,[Name]   VARCHAR(100)                          NOT NULL
	,Size     DECIMAL(18,2)                         NOT NULL
	,ParentId INT FOREIGN KEY REFERENCES Files(Id) 
	,CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

---------------------------------------------------------------------------------------------------
-- 2 TASK Insert ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
INSERT INTO Files([Name], Size, ParentId, CommitId) 
     VALUES ('Trade.idk', 2598.0, 1, 1)
            ,('menu.net', 9238.31, 2, 2)
            ,('Administrate.soshy', 1246.93, 3, 3)
            ,('Controller.php', 7353.15, 4, 4)
            ,('Find.java', 9957.86, 5, 5)
            ,('Controller.json', 14034.87, 3, 6)
            ,('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId) 
     VALUES ('Critical Problem with HomeController.cs file','open', 1, 4)
            ,('Typo fix in Judge.html','open', 4, 3)
            ,('Implement documentation for UsersService.cs','closed', 8, 2)
            ,('Unreachable code in Index.cs','open', 9, 8)

---------------------------------------------------------------------------------------------------
-- 3 TASK Update ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
UPDATE Issues
   SET IssueStatus = 'closed'
 WHERE AssigneeId = 6

---------------------------------------------------------------------------------------------------
-- 4 TASK Delete ----------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
DELETE FROM RepositoriesContributors
      WHERE RepositoryId IN (SELECT Id FROM Repositories WHERE [Name] IN ('Softuni-Teamwork'))

DELETE FROM Issues
      WHERE RepositoryId IN (SELECT Id FROM Repositories WHERE [Name] IN ('Softuni-Teamwork'))

---------------------------------------------------------------------------------------------------
-- 5 TASK Commits ---------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT Id
         ,[Message]
		 ,RepositoryId
		 ,ContributorId
    FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

---------------------------------------------------------------------------------------------------
-- 6 TASK Front-end -------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT Id
         ,[Name]
		 ,Size
    FROM Files
   WHERE Size > 1000 AND [Name] LIKE ('%html')
ORDER BY Size DESC, Id, [Name] 

---------------------------------------------------------------------------------------------------
-- 7 TASK Issue Assignment ------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
SELECT i.Id
       ,CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
  FROM Issues AS i
  JOIN Users  AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC
         ,i.AssigneeId

---------------------------------------------------------------------------------------------------
-- 8 TASK Single Files ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
SELECT Id
       ,[Name]
	   ,CONCAT(Size, 'KB')  AS Size
  FROM Files
 WHERE Id NOT IN (SELECT ParentId 
                    FROM Files 
				   WHERE ParentId IS NOT NULL)
ORDER BY Id, [Name], Size DESC

---------------------------------------------------------------------------------------------------
-- 9 TASK Commits in Repositories -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT TOP(5)
         r.Id
         ,r.[Name]
		 ,COUNT(c.Id)  AS Commits
    FROM Repositories AS r
    JOIN  Commits AS c ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC
         ,r.Id
		 ,r.[Name]        

---------------------------------------------------------------------------------------------------
-- 10 TASK Average Size ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
  SELECT u.Username    AS Username
         ,AVG(f.Size)  AS Size
    FROM Users                    AS u
    JOIN RepositoriesContributors AS rc ON u.Id = rc.ContributorId
    JOIN Commits                  AS c  ON u.Id = c.ContributorId
    JOIN Files                    AS f  ON c.Id = f.CommitId
GROUP BY u.Username 
ORDER BY Size DESC, Username

---------------------------------------------------------------------------------------------------
-- 11 TASK All User Commits -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
  DECLARE @result INT = ( SELECT COUNT(*)
                            FROM Users AS u
	                        JOIN Commits AS c ON u.Id = c.ContributorId
                           WHERE u.[Username] = @username)
  
  RETURN @result
END
GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

---------------------------------------------------------------------------------------------------
-- 12 Search for Files ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
GO
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
BEGIN    
	SELECT Id
	       ,[Name]
		   ,CONCAT(Size,'KB') AS Size
	  FROM Files  AS f
     WHERE RIGHT([Name],LEN(@fileExtension)) = @fileExtension
  ORDER BY Id
           ,[Name]
		   ,f.Size DESC
END

EXEC usp_SearchForFiles 'txt'

