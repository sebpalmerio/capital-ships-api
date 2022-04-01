using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;

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