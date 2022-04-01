using CapitalShipsAPI.Models.Tables;
using System.Collections.Generic;

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