using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IOptionServices:IDisposable
    {
        IEnumerable<Option> GetAllOptions();
        void CreateOption(Option newOption);
        void EditOption(Option editedOption);
        void DeleteOption(Option option);
        void DeleteOption(int optionId);
        void DeleteHardOption(Option option);
        Option GetOptionById(int optionId);
    }
}
    