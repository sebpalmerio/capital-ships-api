using System;
using ShipsAPI.Models;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace ShipsAPI.Services
{
    public class ShipsService
    {
        public ShipsService()
        {
        }

        public void Query()
        {
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
                        var name = reader.GetString(0);
                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }

        }
    }
}