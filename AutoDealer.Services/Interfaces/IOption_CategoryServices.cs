
using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IOption_CategoryServices :IDisposable
    {
        IEnumerable<Option_Category> GetAllOption_Category();
        void CreateOption_Category(Option_Category newOpt_Category);
        void EditOption_Category(Option_Category editedOpt_Category);
        void DeleteOption_Category(Option_Category opt_Category);
        void DeleteOption_Category(int opt_CategoryId);
        void ReturnOption_Category(Option_Category opt_Category);
        Option_Category GetOption_CategoryById(int opt_CategoryId);
    }
}
