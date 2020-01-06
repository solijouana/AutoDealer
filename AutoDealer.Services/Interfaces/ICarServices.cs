using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICarServices : IDisposable
    {
        IEnumerable<Car> GetAllCars();
        void CreateCar(Car newCar);
        void EditCar(Car editedCar);
        void DeleteCar(Car car);
        void DeleteCar(int carId);
        Car GetCarById(int carId);
    }
}
