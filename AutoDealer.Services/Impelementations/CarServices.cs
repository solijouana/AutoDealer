using System;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class CarServices : ICarServices
    {
        private IRepository<Car> _carRepository;

        public CarServices(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public void CreateCar(Car newCar)
        {
            _carRepository.Insert(newCar);
            _carRepository.Save();
        }

        public void EditCar(Car editedCar)
        {
            _carRepository.Update(editedCar);
            _carRepository.Save();
        }

        public void DeleteCar(Car car)
        {
            EditCar(car);
        }

        public async void DeleteCar(int carId)
        {
            var car = await GetCarById(carId);
            car.IsDelete = true;
            EditCar(car);
        }

        public async Task<Car> GetCarById(int carId)
        {
            return await _carRepository.GetById(carId);
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }
    }
}
