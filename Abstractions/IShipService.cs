using System;
using System.Linq;
using ShipsAPI.Models.Tables;
using ShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ShipsAPI.Services;

namespace ShipsAPI.Abstractions
{
    public interface IShipService
    {
        List<ShipModel> GetShips();
        List<BattleModel> GetBattles();
        List<OutcomeModel> GetOutcomes();
        List<ClassModel> GetClasses();
        List<QueryModel> Query();
        MaxSunkDisplacementModel MaxSunkDisplacement();
        void AddShipModel(ShipModel model);
        void AddBattleModel(BattleModel model);
        void AddOutcomeModel(OutcomeModel model);
        void AddClassModel(ClassModel model);
    }
}