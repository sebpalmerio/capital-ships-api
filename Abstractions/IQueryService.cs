using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;

namespace CapitalShipsAPI.Abstractions
{
    public interface IQueryService
    {
        List<QueryModel> Query();
        MaxSunkDisplacementModel MaxSunkDisplacement();  
    }
}