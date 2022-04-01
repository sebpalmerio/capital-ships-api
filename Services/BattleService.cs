using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Abstractions;

namespace CapitalShipsAPI.Services
{
    public class BattleService : IBattleService
    {
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

        public void AddBattleModel(BattleModel model)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO Battles (name, date)
                    VALUES ($name, $date)
                ";

                command.Parameters.AddWithValue("$name", model.Name);
                command.Parameters.AddWithValue("$date", model.Date);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void UpdateBattleModel(string Name, string NewName)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    UPDATE Outcomes
                    SET battleName = $newName
                    WHERE battleName LIKE $name
                ";
                command.Parameters.AddWithValue("$name", Name);
                command.Parameters.AddWithValue("$newName", NewName);
                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    UPDATE Battles
                    SET battleName = $newName
                    WHERE battleName = $name
                ";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }        

        public void DeleteBattleModel(string Name)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM Outcomes
                    WHERE battleName LIKE $name
                ";
                command.Parameters.AddWithValue("$name", Name);
                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    DELETE FROM Battles
                    WHERE name LIKE $name
                ";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}