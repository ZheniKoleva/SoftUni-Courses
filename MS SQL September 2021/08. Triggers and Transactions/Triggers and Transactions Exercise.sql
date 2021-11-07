/***** Triggers and Transactions *****/


---------------------------------------------------------------------------------------------------
-- 1(14) TASK Create Table Logs -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE TABLE Logs(
	LogID       INT PRIMARY KEY IDENTITY NOT NULL
	,AccountId  INT                      NOT NULL
	,OldSum     MONEY                    NOT NULL
	,NewSum     MONEY                    NOT NULL
)
GO

CREATE TRIGGER tr_AddToLogsOnUpdate
ON dbo.Accounts FOR UPDATE
AS
  INSERT INTO Logs(AccountId, OldSum, NewSum)
       SELECT i.Id, d.Balance, i.Balance
         FROM inserted AS i
		 JOIN deleted AS d ON i.Id = d.Id
        WHERE d.Balance <> i.Balance
GO

UPDATE Accounts
   SET Balance = 113.12
 WHERE Id = 1

SELECT * FROM Accounts
SELECT * FROM Logs

---------------------------------------------------------------------------------------------------
-- 2(15) TASK Create Table Emails -----------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE TABLE [NotificationEmails](
	[Id]         INT PRIMARY KEY IDENTITY NOT NULL
	,[Recipient] INT                      NOT NULL
	,[Subject]   NVARCHAR(50)             NOT NULL
	,[Body]      NVARCHAR(MAX)            NOT NULL
)
GO

CREATE TRIGGER tr_AddToNotificationEmailsOnLogsUpdate
ON Logs FOR INSERT
AS
  INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
       SELECT i.AccountId
	          , CONCAT('Balance change for account: ', i.AccountId)
			  , CONCAT('On ', GETDATE() , ' your balance was changed from ', i.OldSum, ' to ', i.NewSum)
         FROM inserted AS i 		 
GO

UPDATE Accounts
   SET Balance = 103.12
 WHERE Id = 1

SELECT * FROM Logs
SELECT * FROM NotificationEmails

---------------------------------------------------------------------------------------------------
-- 3(16) TASK Deposit Money -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(18,4))
AS 
BEGIN TRANSACTION
    UPDATE Accounts 
       SET Balance += @moneyAmount
     WHERE Id = @accountId

IF (@moneyAmount < 0)
  BEGIN
      ROLLBACK
  	  RAISERROR('Positive amount value required', 16, 1)
  	  RETURN
  END
COMMIT 
GO

EXEC usp_DepositMoney 1, 10

---------------------------------------------------------------------------------------------------
-- 4(17) TASK Withdraw Money Procedure ------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4)) 
AS
BEGIN TRANSACTION
    UPDATE Accounts
	   SET Balance -= @moneyAmount
     WHERE Id = @accountId

IF(@moneyAmount < 0)
  BEGIN 
     ROLLBACK
  	 RAISERROR('Positive amount value required', 16, 1)
  	 RETURN
  END
COMMIT 
GO   

EXEC usp_WithdrawMoney 5, 25

---------------------------------------------------------------------------------------------------
-- 5(18) TASK Money Transfer ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Bank

CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4)) 
AS
BEGIN TRANSACTION
IF(@amount < 0)  
  BEGIN
  ROLLBACK
  RAISERROR('Positive amount value required', 16, 1)
  RETURN
  END
ELSE IF(NOT EXISTS(SELECT Id FROM dbo.Accounts WHERE Id = @senderId)
     OR NOT EXISTS(SELECT Id FROM dbo.Accounts WHERE Id = @receiverId))
  BEGIN
  ROLLBACK
  RAISERROR('Missing such accountId', 16, 1)
  RETURN
  END

DECLARE @senderBalance DECIMAL(18,4)
   	SET @senderBalance = (SELECT Balance 
   	                        FROM dbo.Accounts 
   						   WHERE Id = @senderId)     

IF(@senderBalance < @amount)
  BEGIN
  ROLLBACK
  RAISERROR('Insufficient Availability', 16, 1)
  RETURN
  END
   
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId,@amount

COMMIT

 --- Option 2 ---
    
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4)) 
AS
BEGIN TRANSACTION
IF(@amount < 0)  
  BEGIN
  ROLLBACK
  RAISERROR('Positive amount value required', 16, 1)
  RETURN
  END

DECLARE @senderBalance DECIMAL(18,4)
   	SET @senderBalance = (SELECT Balance 
   	                        FROM dbo.Accounts 
   						   WHERE Id = @senderId)     

IF(@senderBalance < @amount)
  BEGIN
  ROLLBACK
  RAISERROR('Insufficient Availability', 16, 1)
  RETURN
  END

EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId,@amount

COMMIT

---------------------------------------------------------------------------------------------------
-- 6(20) TASK Massive Shopping --------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Diablo

DECLARE @userName   VARCHAR(50) = 'Stamat'
DECLARE @gameName   VARCHAR(50) = 'Safflower'
DECLARE @userNameId INT = (SELECT [Id] FROM [Users] WHERE [Username] = @userName) /* 9 */
DECLARE @gameId     INT = (SELECT [Id] FROM [Games] WHERE [Name] =  @gameName) /* 87 */
DECLARE @userGameId INT = (SELECT [Id] FROM [UsersGames] WHERE [UserId] =  @userNameId AND [GameId] = @gameId) /* 110 */
DECLARE @cash       DECIMAL(18,4) = (SELECT [Cash] FROM [UsersGames] WHERE [Id] =  @userGameId) /* 6266,00 */
DECLARE @itemsSumByLevelRange DECIMAL(18,4)
DECLARE @startRange INT
DECLARE @endRange   INT 

BEGIN TRANSACTION
  SET @startRange = 11
  SET @endRange = 12
  SET @itemsSumByLevelRange = (SELECT SUM([Price]) FROM [Items] WHERE [MinLevel] BETWEEN @startRange AND @endRange) /* 4777,00 */
  
  IF(@cash >= @itemsSumByLevelRange)
	BEGIN 
	    INSERT INTO [UserGameItems]
		     SELECT i.[Id]
			        ,@userGameId
			   FROM [Items]  AS i
              WHERE i.[Id] IN (SELECT [Id]
			                     FROM [Items]
								WHERE [MinLevel] BETWEEN @startRange AND @endRange)
         UPDATE [UsersGames]
		    SET [Cash] -= @itemsSumByLevelRange
          WHERE [Id] = @userGameId

		COMMIT
	END
  ELSE
    BEGIN
	ROLLBACK
	END

SET @cash = (SELECT [Cash] FROM [UsersGames] WHERE [Id] =  @userGameId)

BEGIN TRANSACTION 
  SET @startRange = 19
  SET @endRange = 21
  SET @itemsSumByLevelRange = (SELECT SUM([Price]) FROM [Items] WHERE [MinLevel] BETWEEN @startRange AND @endRange)  /* 7946,00 */
  
  IF(@cash >= @itemsSumByLevelRange)
	BEGIN 
	    INSERT INTO [UserGameItems]
		     SELECT i.[Id]
			        ,@userGameId
			   FROM [Items]  AS i
              WHERE i.[Id] IN (SELECT [Id]
			                     FROM [Items]
								WHERE [MinLevel] BETWEEN @startRange AND @endRange)
         UPDATE [UsersGames]
		    SET [Cash] -= @itemsSumByLevelRange
          WHERE [Id] = @userGameId

		COMMIT
	END
  ELSE
    BEGIN
	ROLLBACK
	END

SELECT i.[Name]
  FROM [Items]  AS i
  JOIN [UserGameItems] AS ugi  ON i.[Id] = ugi.[ItemId]
 WHERE ugi.[UserGameId] = @userGameId

---------------------------------------------------------------------------------------------------
-- 7(21) TASK Employees with Three Projects -------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION 	   
   INSERT INTO EmployeesProjects
        VALUES (@emloyeeId, @projectID)

		DECLARE @projectsCount INT
       SET @projectsCount = (SELECT COUNT(ProjectID)
   	                           FROM EmployeesProjects
   	                          WHERE EmployeeID = @emloyeeId) 
   
   IF(@projectsCount > 3)
     BEGIN  
	    ROLLBACK
        RAISERROR('The employee has too many projects!', 16, 1) 		
        RETURN	
     END	  
COMMIT

---------------------------------------------------------------------------------------------------
-- 8(22) TASK  Delete Employees -------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

CREATE TABLE Deleted_Employees(
	EmployeeId    INT PRIMARY KEY NOT NULL
	,FirstName    VARCHAR(50)     NOT NULL
	,LastName     VARCHAR(50)     NOT NULL
	,MiddleName   VARCHAR(50) 
	,JobTitle     VARCHAR(50)     NOT NULL
	,DepartmentId INT             NOT NULL
	,Salary       MONEY           NOT NULL
)
GO

CREATE TRIGGER tr_AddDeletedEmployees
ON Employees FOR DELETE
AS 
  INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary )
       SELECT d.FirstName,d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary
         FROM deleted AS d

