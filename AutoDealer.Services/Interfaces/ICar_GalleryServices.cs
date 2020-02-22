using System;
using System.Collections.Generic;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICar_GalleryServices : IDisposable
    {
        IEnumerable<Car_Gallery> CarGalleries();
        void CreateCar_Gallery(Car_Gallery newCar_Gallery);
        void InsertMultiImage(List<string> carGalleries,int carId);
        void EditCar_Gallery(Car_Gallery editedCar_Gallery);
        void DeleteCar_Gallery(Car_Gallery car_Gallery);
        void DeleteCar_Gallery(int carId);
        Car_Gallery GetCar_GalleryById(int car_GalleryId);
        List<Car_Gallery> GetCarGalleriesByCarsFilter(IEnumerable<Car>cars);

    }
}
