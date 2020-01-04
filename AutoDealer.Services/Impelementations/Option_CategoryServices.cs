
using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class Option_CategoryServices:IOption_CategoryServices
    {
        private IRepository<Option_Category> _option_categoryRepository;

        public Option_CategoryServices(IRepository<Option_Category> optionCategoryRepository)
        {
            _option_categoryRepository = optionCategoryRepository;
        }

        public IEnumerable<Option_Category> GetAllOption_Category()
        {
            return _option_categoryRepository.Get(null).ToList();
        }

        public void CreateOption_Category(Option_Category newOpt_Category)
        {
            _option_categoryRepository.Insert(newOpt_Category);
            _option_categoryRepository.Save();
        }

        public void EditOption_Category(Option_Category editedOpt_Category)
        {
           _option_categoryRepository.Update(editedOpt_Category);
            _option_categoryRepository.Save();
        }

        public void DeleteOption_Category(Option_Category opt_Category)
        {
            opt_Category.IsDelete = true;
            EditOption_Category(opt_Category);
        }

        public void DeleteOption_Category(int opt_CategoryId)
        {
            var opt_category = GetOption_CategoryById(opt_CategoryId);

            if (opt_category!=null)
                DeleteOption_Category(opt_category);
        }

        public void ReturnOption_Category(Option_Category opt_Category)
        {
            opt_Category.IsDelete = false;
            EditOption_Category(opt_Category);
        }

        public Option_Category GetOption_CategoryById(int opt_CategoryId)
        {
            return _option_categoryRepository.GetById(opt_CategoryId);
        }

        public void Dispose()
        {
            _option_categoryRepository?.Dispose();
        }
    }
}
