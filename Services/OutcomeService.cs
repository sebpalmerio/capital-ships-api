using System;
using System.Linq;
using CapitalShipsAPI.Models.Queries;
using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Abstractions;

namespace CapitalShipsAPI.Services
{
    public class OutcomeService : IOutcomeService
    {
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

        public void AddOutcomeModel(OutcomeModel model)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO Outcomes (shipName, battleName, result)
                    VALUES ($shipName, $battleName, $result)
                ";

                command.Parameters.AddWithValue("$shipName", model.ShipName);
                command.Parameters.AddWithValue("$battleName", model.BattleName);
                command.Parameters.AddWithValue("$result", model.Result);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteOutcomeModel(string Name)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM Outcomes
                    WHERE name LIKE $name
                ";

                command.Parameters.AddWithValue("$name", Name);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}