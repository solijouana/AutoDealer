using System;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICarServices : IDisposable
    {
        void CreateCar(Car newCar);
        void EditCar(Car editedCar);
        void DeleteCar(Car car);
        void DeleteCar(int carId);
        Task<Car> GetCarById(int carId);
    }
}
