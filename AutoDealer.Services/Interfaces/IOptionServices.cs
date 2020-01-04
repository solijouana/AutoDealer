using System;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IOptionServices:IDisposable
    {
        void CreateOption(Option newOption);
        void EditOption(Option editedOption);
        void DeleteOption(Option option);
        void DeleteOption(int optionId);
        Option GetOptionById(int optionId);
    }
}
    