/***** Indices and Data Aggregation *****/


---------------------------------------------------------------------------------------------------
-- 1 TASK Records’ Count --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Gringotts]

SELECT COUNT(*) AS [Count]
  FROM [WizzardDeposits] 

---------------------------------------------------------------------------------------------------
-- 2 TASK Longest Magic Wand ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE [Gringotts]

SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
  FROM [WizzardDeposits]

---------------------------------------------------------------------------------------------------
-- 3 TASK Longest Magic Wand per Deposit Groups ---------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,MAX(MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits      
GROUP BY DepositGroup

---------------------------------------------------------------------------------------------------
-- 4 TASK Smallest Deposit Group per Magic Wand Size ----------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT TOP(2)
         DepositGroup         
    FROM WizzardDeposits  
GROUP BY DepositGroup 
ORDER BY AVG(MagicWandSize)

---------------------------------------------------------------------------------------------------
-- 5 TASK Deposits Sum ----------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits      
GROUP BY DepositGroup

---------------------------------------------------------------------------------------------------
-- 6 TASK Deposits Sum for Ollivander Family ------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits     
   WHERE MagicWandCreator IN ('Ollivander family')
GROUP BY DepositGroup
 
---------------------------------------------------------------------------------------------------
-- 7 TASK Deposits Filter -------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits     
   WHERE MagicWandCreator IN ('Ollivander family')
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

---------------------------------------------------------------------------------------------------
-- 8 TASK Deposit Charge --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,MagicWandCreator
		 ,MIN(DepositCharge) AS [MinDepositCharge]
    FROM WizzardDeposits     
GROUP BY DepositGroup
         ,MagicWandCreator
ORDER BY MagicWandCreator
         ,DepositGroup 

---------------------------------------------------------------------------------------------------
-- 9 TASK Age Groups ------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT  AgeByGroup         AS [AgeGroup]
          ,COUNT(AgeByGroup) AS [WizardCount]
    FROM 
          (SELECT *
                  ,CASE
					    WHEN Age BETWEEN 0  AND 10 THEN '[0-10]'
						WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
						WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
						WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
						WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
						WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
						ELSE '[61+]'
                   END  AS AgeByGroup
             FROM WizzardDeposits
	      ) AS AgeFilter
GROUP BY AgeByGroup

 --- Option 2 ---

  SELECT CASE
		     WHEN Age BETWEEN 0  AND 10 THEN '[0-10]'
		     WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		     WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		     WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		     WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		     WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		     ELSE '[61+]'
         END
		 AS AgeGroup
	     ,COUNT(Id)
    FROM WizzardDeposits
GROUP BY CASE
		     WHEN Age BETWEEN 0  AND 10 THEN '[0-10]'
		     WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		     WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		     WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		     WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		     WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		     ELSE '[61+]'
         END

---------------------------------------------------------------------------------------------------
-- 10 TASK First Letter ---------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT LEFT(FirstName, 1) AS [FirstLetter]
    FROM WizzardDeposits
   WHERE DepositGroup IN ('Troll Chest')
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

---------------------------------------------------------------------------------------------------
-- 11 TASK Average Interest -----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

  SELECT DepositGroup
         ,IsDepositExpired
		 ,AVG(DepositInterest) AS [AverageInterest]
    FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup
         ,IsDepositExpired
ORDER BY DepositGroup DESC
         ,IsDepositExpired ASC

---------------------------------------------------------------------------------------------------
-- 12 TASK Rich Wizard, Poor Wizard ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE Gringotts

SELECT SUM([Difference]) AS [SumDifference]
  FROM (
	     SELECT FirstName                                                 AS [Host Wizard]
	            ,DepositAmount                                            AS [Host Wizard Deposit]
	     	    ,LEAD(FirstName) OVER (ORDER BY Id)                       AS [Guest Wizard]
	     	    ,LEAD(DepositAmount) OVER (ORDER BY Id)                   AS [Guest Wizard Deposit]
	     	    ,(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) AS [Difference]
	       FROM WizzardDeposits
       ) AS Result

 --- Option 2 ---
WITH DepositsDifference_CTE 
     --([Host Wizard], [Host Wizard Deposit], [Guest Wizard], [Guest Wizard Deposit], [Difference])
  AS
     (
	  SELECT FirstName                                                 AS [Host Wizard]
	         ,DepositAmount                                            AS [Host Wizard Deposit]
	  	     ,LEAD(FirstName) OVER (ORDER BY Id)                       AS [Guest Wizard]
	  	     ,LEAD(DepositAmount) OVER (ORDER BY Id)                   AS [Guest Wizard Deposit]
	  	     ,(DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id)) AS [Difference]
	    FROM WizzardDeposits
     )

SELECT SUM([Difference]) AS [SumDifference]
  FROM DepositsDifference_CTE

---------
SELECT SUM([Difference]) AS [SumDifference]
  FROM
       (SELECT w1.FirstName                           AS [Host Wizard]
               ,w1.DepositAmount					  AS [Host Wizard Deposit]
	           ,w2.FirstName						  AS [Guest Wizard]
	           ,w2.DepositAmount					  AS [Guest Wizard Deposit]
	           ,(w1.DepositAmount - w2.DepositAmount) AS [Difference]
          FROM WizzardDeposits AS w1
          JOIN WizzardDeposits AS w2  ON w1.Id + 1 = w2.Id /* игнорираме последният */
	   ) AS DepositsDifference

---------------------------------------------------------------------------------------------------
-- 13 TASK Departments Total Salaries -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT DepartmentID
         ,SUM(Salary)  AS [TotalSalary]
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID  

---------------------------------------------------------------------------------------------------
-- 14 TASK Employees Minimum Salaries -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT DepartmentID
         ,MIN(Salary)  AS [MinimumSalary]
    FROM Employees
   WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

---------------------------------------------------------------------------------------------------
-- 15 TASK Employees Average Salaries -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT *
  INTO NewTable
  FROM Employees
 WHERE Salary > 30000

DELETE FROM NewTable
      WHERE ManagerID = 42

UPDATE NewTable
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT DepartmentID
         ,AVG(Salary) AS [AverageSalary]
    FROM NewTable
GROUP BY DepartmentID

---------------------------------------------------------------------------------------------------
-- 16 TASK Employees Maximum Salaries -------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

  SELECT DepartmentID
         ,MAX(Salary)
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

---------------------------------------------------------------------------------------------------
-- 17 TASK Employees Count Salaries ---------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

SELECT COUNT(Salary) AS [Count]        
  FROM Employees
 WHERE ManagerID IS NULL

---------------------------------------------------------------------------------------------------
-- 18 TASK 3rd Highest Salary ---------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

 SELECT DepartmentID
        ,Result.Salary AS [ThirdHighestSalary]
   FROM
         (   SELECT DepartmentID
                    ,Salary
		            ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
               FROM Employees  
           GROUP BY DepartmentID, Salary
         ) AS Result
   WHERE Rank = 3
ORDER BY DepartmentID

 --- Option 2 ---
WITH SalaryByDepartment_CTE (DepartmentID, Salary, Rank)
  AS 
    (   SELECT DepartmentID
               ,Salary
	           ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
          FROM Employees  
      GROUP BY DepartmentID, Salary
    )

  SELECT DepartmentID
          ,Salary   AS [ThirdHighestSalary]
    FROM  SalaryByDepartment_CTE
   WHERE Rank = 3
ORDER BY DepartmentID

 --- Option 3 ---
 SELECT DISTINCT DepartmentID
        ,Result.Salary AS [ThirdHighestSalary]
   FROM
         (SELECT DepartmentID
                 ,Salary
		         ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
            FROM Employees
         ) AS Result
   WHERE Rank = 3
ORDER BY DepartmentID

---------------------------------------------------------------------------------------------------
-- 19 TASK Salary Challenge  ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
USE SoftUni

   SELECT TOP(10)
          e.FirstName
          ,e.LastName
	      ,e.DepartmentID
     FROM Employees AS e
LEFT JOIN (   SELECT DepartmentID
                     ,AVG(Salary) AS [AvgSalary]
                FROM Employees
            GROUP BY DepartmentID
          ) AS DepAvgSalary
       ON e.DepartmentID = DepAvgSalary.DepartmentID
    WHERE Salary > AvgSalary 
 ORDER BY e.DepartmentID

 --- Option 3 ---
WITH DepAvgSalary_CTE (DepartmentID, AvgSalary)
  AS
     (   SELECT DepartmentID
                ,AVG(Salary) AS [AvgSalary]
           FROM Employees
       GROUP BY DepartmentID
     ) 

  
   SELECT TOP(10)
          e.FirstName
          ,e.LastName
	      ,e.DepartmentID
     FROM Employees         AS E
LEFT JOIN DepAvgSalary_CTE  AS d  ON e.DepartmentID = d.DepartmentID
    WHERE Salary > AvgSalary 
 ORDER BY  e.DepartmentID

---- OR -----
   SELECT TOP(10)
          e.FirstName
          ,e.LastName
	      ,e.DepartmentID
     FROM Employees AS e      
    WHERE Salary > (  SELECT AVG(Salary) AS [AvgSalary]
                        FROM Employees   AS s
                       WHERE e.DepartmentID = s.DepartmentID
                    GROUP BY DepartmentID
                   ) 
 ORDER BY e.DepartmentID
  