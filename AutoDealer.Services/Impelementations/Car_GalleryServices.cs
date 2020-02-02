﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class Car_GalleryServices:ICar_GalleryServices
    {
        private IRepository<Car_Gallery> _carRepository;

        public Car_GalleryServices(IRepository<Car_Gallery> carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car_Gallery> CarGalleries()
        {
            return _carRepository.Get(null).ToList();
        }

        public void CreateCar_Gallery(Car_Gallery newCar_Gallery)
        {
            _carRepository.Insert(newCar_Gallery);
            _carRepository.Save();
        }

        public void InsertMultiImage(List<string> carGalleries,int carId)
        {
            if (carGalleries != null && carGalleries.Any())
            {
                foreach (var carGallery in carGalleries)
                {
                    _carRepository.Insert(new Car_Gallery()
                    {
                        CarId = carId,
                        ImageName = carGallery
                    });
                }
            }
        }

        public void EditCar_Gallery(Car_Gallery editedCar_Gallery)
        {
            _carRepository.Update(editedCar_Gallery);
            _carRepository.Save();
        }

        public void DeleteCar_Gallery(Car_Gallery car_Gallery)
        {
            _carRepository.Update(car_Gallery);
            _carRepository.Save();
        }

        public void DeleteCar_Gallery(int carId)
        {
            var car_Gallery =_carRepository.GetById(carId);
            if (car_Gallery != null)
            {
                DeleteCar_Gallery(car_Gallery);
            }
        }

        public Car_Gallery GetCar_GalleryById(int car_GalleryId)
        {
            return _carRepository.GetById(car_GalleryId);
        }

        public List<Car_Gallery> GetCarGalleriesByCarsFilter(List<Car> cars)
        {
            List<Car_Gallery>Images=new List<Car_Gallery>();
            foreach (var car in cars)
            {
                var images = _carRepository.Get(g => g.CarId == car.ID).OrderByDescending(g => g.ID).Take(1).ToList();
                Images.AddRange(images);
            }

            return Images;
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }
    }
}
