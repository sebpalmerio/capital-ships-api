using System;
using System.Linq;
using CapitalShipsAPI.Models.Tables;
using CapitalShipsAPI.Models.Queries;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CapitalShipsAPI.Services;

namespace CapitalShipsAPI.Abstractions
{
    public interface IClassService
    {
        List<ClassModel> GetClasses();
        void AddClassModel(ClassModel model);
        void UpdateClassModel(string Name, string NewName);
        void DeleteClassModel(string Name);       
    }
}