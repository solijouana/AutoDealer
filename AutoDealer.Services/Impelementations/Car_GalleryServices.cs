using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class Car_GalleryServices:ICar_GalleryServices
    {
        private IRepository<Car_Gallery> _carGalleryRepository;

        public Car_GalleryServices(IRepository<Car_Gallery> carGalleryRepository)
        {
            _carGalleryRepository = carGalleryRepository;
        }
        public IEnumerable<Car_Gallery> CarGalleries()
        {
            return _carGalleryRepository.Get(null).ToList();
        }

        public void CreateCar_Gallery(Car_Gallery newCar_Gallery)
        {
            _carGalleryRepository.Insert(newCar_Gallery);
            _carGalleryRepository.Save();
        }

        public void InsertMultiImage(List<string> carGalleries,int carId)
        {
            if (carGalleries != null && carGalleries.Any())
            {
                foreach (var carGallery in carGalleries)
                {
                    _carGalleryRepository.Insert(new Car_Gallery()
                    {
                        CarId = carId,
                        ImageName = carGallery
                    });
                }
            }
        }

        public void EditCar_Gallery(Car_Gallery editedCar_Gallery)
        {
            _carGalleryRepository.Update(editedCar_Gallery);
            _carGalleryRepository.Save();
        }

        public void DeleteCar_Gallery(Car_Gallery car_Gallery)
        {
            _carGalleryRepository.Update(car_Gallery);
            _carGalleryRepository.Save();
        }

        public void DeleteCar_Gallery(int carId)
        {
            var car_Gallery = _carGalleryRepository.GetById(carId);
            if (car_Gallery != null)
            {
                DeleteCar_Gallery(car_Gallery);
            }
        }

        public Car_Gallery GetCar_GalleryById(int car_GalleryId)
        {
            return _carGalleryRepository.GetById(car_GalleryId);
        }

        public List<Car_Gallery> GetCarGalleriesByCarsFilter(IEnumerable<Car> cars)
        {
            List<Car_Gallery>Images=new List<Car_Gallery>();
            foreach (var car in cars)
            {
                var images = _carGalleryRepository.Get(g => g.CarId == car.ID).OrderByDescending(g => g.ID).Take(1).ToList();
                Images.AddRange(images);
            }

            return Images;
        }

        public Car_Gallery GetCarGalleryByCarId(int carId)
        {
            var carGallery = _carGalleryRepository.Get(g => g.CarId == carId).FirstOrDefault();
            if (carGallery != null)
            {
                return carGallery;
            }

            return null;
        }

        public void Dispose()
        {
            _carGalleryRepository?.Dispose();
        }
    }
}
