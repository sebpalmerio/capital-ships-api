using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ShipsAPI.Models.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShipsAPI.Services;

namespace ShipsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // ShipService ships = new ShipService();
            // // // MaxSunkDisplacementModel model = ships.MaxSunkDisplacement();
            // // // Console.WriteLine($"{model.BattleName}, {model.ShipName}, {model.Date}");
            // // List<QueryModel> models = ships.Query();
            // // foreach (QueryModel model in models)
            // // {
            // //     Console.WriteLine($"{model.BattleName}");
            // // }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
