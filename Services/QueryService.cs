using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Abstractions;

namespace CapitalShipsAPI.Services
{
    public class QueryService : IQueryService
    {    
        // selects the name of the heaviest ship that was sunk in battle, the battle in which it fought, and the date
        public MaxSunkDisplacementModel MaxSunkDisplacement()
        {
            MaxSunkDisplacementModel model = new MaxSunkDisplacementModel();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT O.shipName, O.battleName, B.date
                    FROM Classes AS C, Ships AS S, Outcomes AS O, Battles AS B
                    WHERE (O.result = 'sunk') AND (S.name = O.shipName) AND (C.className = S.class) AND
                          (O.battleName = B.name) AND
                          (C.displacement IN (SELECT MAX(C.displacement)
                                              FROM Classes AS C, Ships AS S, Outcomes AS O, Battles AS B
                                              WHERE (O.result = 'sunk') AND (S.name = O.shipName) AND
                                                    (C.className = S.class) AND (O.battleName = B.name)));
                ";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    model.ShipName = reader["shipName"].ToString();
                    model.BattleName = reader["battleName"].ToString();
                    model.Date = reader["date"].ToString();
                }
                connection.Close();
            }
            return model;
        }

        
        public GuadalcanalSumModel GuadalcanalSums()
        {
            GuadalcanalSumModel model = new GuadalcanalSumModel();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM (SELECT SUM(numGun) AS USGunSum
                          FROM (SELECT *
                                FROM Outcomes, Ships, Classes
                                WHERE (battleName = 'Guadalcanal') AND (shipName = name) AND
                                      (class = className))
                                GROUP BY country
                                HAVING country='USA'),
                               (SELECT SUM(numGun) AS JapanGunSum
                                FROM (SELECT *
                                      FROM Outcomes, Ships, Classes
                                      WHERE (battleName = 'Guadalcanal') AND (shipName = name) AND
                                            (class = className))
                                      GROUP BY country
                                      HAVING country='Japan');
                ";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    model.USGunSum = reader["USGunSum"].ToString();
                    model.JapanGunSum = reader["JapanGunSum"].ToString();
                }
                connection.Close();
            }
            return model;
        }

        // selects the name of the heaviest ship that was sunk in battle, the battle in which it fought, and the date
        public List<string> ClassesInEveryBattle()
        {
            List<string> classNames = new List<string>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT class
                    FROM (SELECT class, COUNT(DISTINCT battleName) AS BattlesFought
                          FROM (SELECT *
                                FROM Outcomes AS O, Ships AS S
                                WHERE O.shipName = S.name)
                          GROUP BY class)
                          WHERE BattlesFought IN (SELECT COUNT(name) AS TotalBattles
                                       FROM Battles);
                ";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    classNames.Add(reader["class"].ToString());
                }
                connection.Close();
            }
            return classNames;
        }
    }
}