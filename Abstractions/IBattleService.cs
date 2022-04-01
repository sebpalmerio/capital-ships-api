using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;

namespace CapitalShipsAPI.Abstractions
{
    public interface IBattleService
    {
        List<BattleModel> GetBattles();
        void AddBattleModel(BattleModel model);
        void UpdateBattleModel(string Name, string NewName);
        void DeleteBattleModel(string Name);   
    }
}