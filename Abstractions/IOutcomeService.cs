using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;

namespace CapitalShipsAPI.Abstractions
{
    public interface IOutcomeService
    {
        List<OutcomeModel> GetOutcomes();
        void AddOutcomeModel(OutcomeModel model);
        void DeleteOutcomeModel(string Name);    
    }
}