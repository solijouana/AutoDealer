using System.Reflection.Emit;
using System.Threading.Tasks;
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
       public void CreateCar_Gallery(Car_Gallery newCar_Gallery)
        {
            _carRepository.Insert(newCar_Gallery);
            _carRepository.Save();
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

        public async void DeleteCar_Gallery(int carId)
        {
            var car_Gallery =await _carRepository.GetById(carId);
            if (car_Gallery != null)
            {
                DeleteCar_Gallery(car_Gallery);
            }
        }

        public async Task<Car_Gallery> GetCar_GalleryById(int car_GalleryId)
        {
            return await _carRepository.GetById(car_GalleryId);
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }
    }
}
