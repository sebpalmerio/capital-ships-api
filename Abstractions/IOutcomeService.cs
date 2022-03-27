using System;
using System.Linq;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Services;

namespace CapitalShipsAPI.Abstractions
{
    public interface IOutcomeService
    {
        List<OutcomeModel> GetOutcomes();
        void AddOutcomeModel(OutcomeModel model);
        public void DeleteOutcomeModel(string Name);    
    }
}