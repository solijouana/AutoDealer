using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICar_Selected_OptionServices:IDisposable
    {
        IEnumerable<Car_Selected_Option> GetAllCarOptions();
        void CreateCarOption(Car_Selected_Option newCarOption);
        void EditCarOption(Car_Selected_Option editedCarOption);
        void DeleteCarOption(Car_Selected_Option carOption);
        void DeleteCarOption(int carOptionId);
        Car_Selected_Option GetCarOptionById(int carOptionId);
    }
}
