using System;
using System.Linq;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Services;

namespace CapitalShipsAPI.Abstractions
{
    public interface IShipService
    {
        List<ShipModel> GetShips();
        void AddShipModel(ShipModel model);
        void UpdateShipModel(string Name, string NewName);
        void DeleteShipModel(string Name);    
    }
}