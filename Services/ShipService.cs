using System;
using System.Linq;
using ShipsAPI.Models.Queries;
using ShipsAPI.Models.Tables;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ShipsAPI.Abstractions;

namespace ShipsAPI.Services
{
    public class ShipService : IShipService
    {
        public ShipService()
        {
        }

        public List<ShipModel> GetShips()
        {
            List<ShipModel> models = new List<ShipModel>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM Ships
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ShipModel model = new ShipModel();
                        model.Name = reader["name"].ToString();
                        model.Class = reader["class"].ToString();
                        model.Launched = Convert.ToInt32(reader["launched"]);
                        models.Add(model);
                    }
                }
                connection.Close();
            }
            return models;
        }

        public List<BattleModel> GetBattles()
        {
            List<BattleModel> models = new List<BattleModel>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM Battles
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BattleModel model = new BattleModel();
                        model.Name = reader["name"].ToString();
                        model.Date = reader["date"].ToString();
                        models.Add(model);
                    }
                }
                connection.Close();
            }
            return models;
        }

        public List<OutcomeModel> GetOutcomes()
        {
            List<OutcomeModel> models = new List<OutcomeModel>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM Outcomes
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OutcomeModel model = new OutcomeModel();
                        model.ShipName = reader["shipName"].ToString();
                        model.BattleName = reader["battleName"].ToString();
                        model.Result = reader["result"].ToString();
                        models.Add(model);
                    }
                }
                connection.Close();
            }
            return models;
        }

        public List<ClassModel> GetClasses()
        {
            List<ClassModel> models = new List<ClassModel>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT *
                    FROM Classes
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassModel model = new ClassModel();
                        model.ClassName = reader["className"].ToString();
                        model.Type = reader["type"].ToString();
                        model.Country = reader["country"].ToString();
                        model.NumGun = Convert.ToInt32(reader["numGun"]);
                        model.Bore = Convert.ToInt32(reader["bore"]);
                        models.Add(model);
                    }
                }
                connection.Close();
            }
            return models;
        }            

        public List<QueryModel> Query()
        {
            List<QueryModel> models = new List<QueryModel>();
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT name
                    FROM Battles
                ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QueryModel model = new QueryModel();
                        model.BattleName = reader["name"].ToString();
                        models.Add(model);
                    }
                }
                connection.Close();
            }
            return models;
        }
        
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
    }
}