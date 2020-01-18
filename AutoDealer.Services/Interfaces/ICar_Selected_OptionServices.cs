using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICar_Selected_OptionServices:IDisposable
    {
        IEnumerable<Car_Selected_Option> GetAllCarOptions();
        void InsertSelectedOptions(List<int> carSelectedOptions,int carId);
    }
}
