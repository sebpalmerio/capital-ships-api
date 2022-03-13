using System;
using System.Linq;
using ShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ShipsAPI.Services;

namespace ShipsAPI.Abstractions
{
    public interface IShipsService
    {
        IEnumerable<QueryModel> Query();
        MaxSunkDisplacementModel MaxSunkDisplacement();
    }
}