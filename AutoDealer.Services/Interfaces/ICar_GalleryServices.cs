using System;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface ICar_GalleryServices : IDisposable
    {
        void CreateCar_Gallery(Car_Gallery newCar_Gallery);
        void EditCar_Gallery(Car_Gallery editedCar_Gallery);
        void DeleteCar_Gallery(Car_Gallery car_Gallery);
        void DeleteCar_Gallery(int carId);
        Task<Car_Gallery> GetCar_GalleryById(int car_GalleryId);
    }
}
