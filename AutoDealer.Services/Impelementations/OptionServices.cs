﻿using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class OptionServices : IOptionServices
    {
        private IRepository<Option> _optionRepository;

        public OptionServices(IRepository<Option> optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public IEnumerable<Option> GetAllOptions()
        {
            return _optionRepository.Get(null).ToList();
        }

        public void CreateOption(Option newOption)
        {
            _optionRepository.Insert(newOption);
            _optionRepository.Save();
        }

        public void EditOption(Option editedOption)
        {
            _optionRepository.Update(editedOption);
            _optionRepository.Save();
        }

        public void DeleteOption(Option option)
        {
            option.IsDelete = true;
            EditOption(option);
        }

        public void DeleteOption(int optionId)
        {
            var option = GetOptionById(optionId);

            if (option != null)
                DeleteOption(option);
        }

        public void DeleteHardOption(Option option)
        {
            _optionRepository.Delete(option);
            _optionRepository.Save();
        }

        public Option GetOptionById(int optionId)
        {
           return _optionRepository.GetById(optionId);
        }

        public void Dispose()
        {
            _optionRepository?.Dispose();
        }
    }
}
