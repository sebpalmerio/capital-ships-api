using System;
using System.Linq;
using CapitalShipsAPI.Models.Queries;
using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Abstractions;

namespace CapitalShipsAPI.Services
{
    public class ShipService : IShipService
    {
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

        public void AddShipModel(ShipModel model)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO Ships (name, class, launched)
                    VALUES ($name, $class, $launched)
                ";

                command.Parameters.AddWithValue("$name", model.Name);
                command.Parameters.AddWithValue("$class", model.Class);
                command.Parameters.AddWithValue("$launched", model.Launched);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateShipModel(string Name, string NewName)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE Outcomes
                    SET shipName = $newName
                    WHERE shipName LIKE $name
                ";
                command.Parameters.AddWithValue("$name", Name);
                command.Parameters.AddWithValue("$newName", NewName);
                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    UPDATE Ships
                    SET name = $newName
                    WHERE name = $name
                ";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteShipModel(string Name)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM Outcomes
                    WHERE shipName LIKE $name
                ";                
                command.Parameters.AddWithValue("$name", Name);
                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    DELETE FROM Ships
                    WHERE name LIKE $name
                ";                
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}