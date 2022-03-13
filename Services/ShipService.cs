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