using System;
using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.DTO.Advertise;
using AutoDealer.Services.DTO.Paging;
using AutoDealer.Services.Extensions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class CarServices : ICarServices
    {
        private IRepository<Car> _carRepository;
        private IRepository<Manufacturer> _manufacturerRepository;

        public CarServices(IRepository<Car> carRepository, IRepository<Manufacturer> manufacturerRepository)
        {
            _carRepository = carRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepository.Get(null).ToList();
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
            car.IsDelete = true;
            EditCar(car);
        }

        public void DeleteCar(int carId)
        {
            var car = GetCarById(carId);
            car.IsDelete = true;
            EditCar(car);
        }

        public Car GetCarById(int carId)
        {
            return _carRepository.GetById(carId);
        }

        public AdminAdvertiseDto GetCarsByFilter(AdminAdvertiseDto filter)
        {
            var query = _carRepository.Get(null).AsQueryable().SetCarsFilter(filter);
            var count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);
            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);
            var cars = query.OrderByDescending(q => q.ID).Paging(pager).ToList();

            return filter.SetCars(cars).SetPaggingItem(pager);
        }

        public IEnumerable<Car> GetLastCars()
        {
            return _carRepository.Get(c => c.IsActive).OrderByDescending(c => c.CreateTime).Take(20).ToList();
        }

        public AdvertiseCatalogDto GetCatalogCarsByFilter(AdvertiseCatalogDto filter)
        {
            var query = _carRepository
                .Get(null).AsQueryable().SetCatalogCarsFilter(filter);
            var count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);
            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);
            filter.TotalCars = query.Count();
            var catalogCars = query.OrderByDescending(c => c.CreateTime).Paging(pager).ToList();
            return filter.SetCar(catalogCars).SetPagging(pager);
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }
    }
}
