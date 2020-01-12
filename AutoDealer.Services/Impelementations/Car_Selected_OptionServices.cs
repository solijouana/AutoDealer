using System.Collections.Generic;
using System.Linq;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class Car_Selected_OptionServices : ICar_Selected_OptionServices
    {
        private IRepository<Car_Selected_Option> _carOptionRepository;

        public Car_Selected_OptionServices(IRepository<Car_Selected_Option> carOptionRepository)
        {
            _carOptionRepository = carOptionRepository;
        }

        public IEnumerable<Car_Selected_Option> GetAllCarOptions()
        {
            return _carOptionRepository.Get(null).ToList();
        }

        public void CreateCarOption(Car_Selected_Option newCarOption)
        {
            _carOptionRepository.Insert(newCarOption);
            _carOptionRepository.Save();
        }

        public void EditCarOption(Car_Selected_Option editedCarOption)
        {
            _carOptionRepository.Update(editedCarOption);
            _carOptionRepository.Save();
        }

        public void DeleteCarOption(Car_Selected_Option carOption)
        {
            _carOptionRepository.Delete(carOption);
            _carOptionRepository.Save();
        }

        public void DeleteCarOption(int carOptionId)
        {
            _carOptionRepository.Delete(carOptionId);
            _carOptionRepository.Save();
        }

        public Car_Selected_Option GetCarOptionById(int carOptionId)
        {
            return _carOptionRepository.GetById(carOptionId);
        }
        public void Dispose()
        {
            _carOptionRepository?.Dispose();
        }
    }
}
