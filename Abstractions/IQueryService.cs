using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;

namespace CapitalShipsAPI.Abstractions
{
    public interface IQueryService
    {
        MaxSunkDisplacementModel MaxSunkDisplacement();
        GuadalcanalSumModel GuadalcanalSums();
        List<string> ClassesInEveryBattle();
    }
}