using System;
using System.Linq;
using CapitalShipsAPI.Models.Queries;
using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Abstractions;

namespace CapitalShipsAPI.Services
{
    public class ClassService : IClassService
    {
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

        public void AddClassModel(ClassModel model)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO Classes (className, type, country, numGun, bore, displacement)
                    VALUES ($className, $type, $country, $numGun, $bore, $displacement)
                ";

                command.Parameters.AddWithValue("$ClassName", model.ClassName);
                command.Parameters.AddWithValue("$type", model.Type);
                command.Parameters.AddWithValue("$country", model.Country);
                command.Parameters.AddWithValue("$numGun", model.NumGun);
                command.Parameters.AddWithValue("$bore", model.Bore);
                command.Parameters.AddWithValue("$displacement", model.Displacement);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteClassModel(string Name)
        {
            using (var connection = new SqliteConnection("Data Source=Capital_Ships.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM Ships
                    WHERE class LIKE $name
                ";
                command.Parameters.AddWithValue("$name", Name);
                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    DELETE FROM Classes
                    WHERE className LIKE $name
                ";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}