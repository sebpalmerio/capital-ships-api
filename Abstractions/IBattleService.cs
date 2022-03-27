using System;
using System.Linq;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Services;

namespace CapitalShipsAPI.Abstractions
{
    public interface IBattleService
    {
        List<BattleModel> GetBattles();
        void AddBattleModel(BattleModel model);
        public void DeleteBattleModel(string Name);   
    }
}