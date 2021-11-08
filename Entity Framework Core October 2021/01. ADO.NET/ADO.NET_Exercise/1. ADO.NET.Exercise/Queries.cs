namespace ADO.NET.Exercise
{
    public static class Queries
    {
        public const string CREATE_MINIONSDB = @"CREATE DATABASE MinionsDB";

        public const string CREATE_MINIONS_TABLES = @"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))

CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))

CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))

CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))

CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))

CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

       
        public const string INSERT_DATA_INTO_TABLES = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)

INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)

INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)

INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

        
        public  const string GET_VILLAINS_NAMES = @"SELECT v.Name
                                                           ,COUNT(mv.VillainId) AS MinionsCount  
                                                      FROM Villains AS v 
                                                      JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                  GROUP BY v.Id, v.Name 
                                                    HAVING COUNT(mv.VillainId) > 3 
                                                  ORDER BY COUNT(mv.VillainId)";

        public const string GET_VILLAIN_NAME_BY_ID = @"SELECT Name 
                                                         FROM Villains 
                                                        WHERE Id = @Id";

        public const string GET_MINIONS_NAMES_BY_VILLAIN_ID = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                                       m.Name, 
                                                                       m.Age
                                                                  FROM MinionsVillains AS mv
                                                                  JOIN Minions As m ON mv.MinionId = m.Id
                                                                 WHERE mv.VillainId = @Id
                                                              ORDER BY m.Name";

        public const string GET_VILLAIN_ID_BY_NAME = @"SELECT Id 
                                                         FROM Villains 
                                                        WHERE Name = @Name";

        public const string GET_MINION_ID_BY_NAME = @"SELECT Id 
                                                        FROM Minions 
                                                       WHERE Name = @Name";

        public const string GET_TOWN_ID_BY_NAME = @"SELECT Id 
                                                      FROM Towns 
                                                     WHERE Name = @townName";

        public const string INSERT_MINION_BY_AGE_NAME_TOWNID = @"INSERT INTO Minions (Name, Age, TownId) 
                                                                      VALUES (@name, @age, @townId)";

        public const string INSERT_VILLAINS_BY_NAME_EVIL = @"INSERT INTO Villains (Name, EvilnessFactorId)  
                                                                  VALUES (@villainName, 4)";

        public const string INSERT_TOWN = @"INSERT INTO Towns (Name) 
                                                 VALUES (@townName)";

        public const string MAP_MINNION_VILLAIN_BY_IDs = @"INSERT INTO MinionsVillains (MinionId, VillainId) 
                                                                VALUES (@minionId, @villainId)";

        public const string CHANGE_TOWN_NAME_CASING = @"UPDATE Towns
                                                           SET Name = UPPER(Name)
                                                         WHERE CountryCode = (SELECT c.Id 
                                                                                FROM Countries AS c 
                                                                                WHERE c.Name = @countryName)";         

        public const string GET_TOWNS_BY_COUNTRYNAME = @"SELECT t.Name 
                                                           FROM Towns as t
                                                           JOIN Countries AS c ON c.Id = t.CountryCode
                                                          WHERE c.Name = @countryName";

        public const string REMOVE_VILLAIN_BY_ID_FROM_MAPPING = @"DELETE FROM MinionsVillains 
                                                                        WHERE VillainId = @villainId";
        
        public const string REMOVE_VILLAIN_BY_ID = @"DELETE FROM Villains
                                                           WHERE Id = @villainId";

        public const string PRINT_ALL_MINION_NAMES = @"SELECT Name 
                                                         FROM Minions";

        public const string INCREASE_MINION_AGE = @" UPDATE Minions
                                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                      WHERE Id = @minionId";

        public const string GET_MINIONS_NAME_AGE = @"SELECT Name, Age 
                                                          FROM Minions";

        public const string INCREASE_AGE_STORED_PROCEDURE = @"EXEC usp_GetOlder @id";

        public const string GET_MINION_NAME_AGE_BY_ID = @"SELECT Name, Age 
                                                            FROM Minions 
                                                           WHERE Id = @Id";

    }
}
