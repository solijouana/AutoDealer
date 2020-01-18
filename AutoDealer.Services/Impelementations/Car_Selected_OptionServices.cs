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

        public void InsertSelectedOptions(List<int> carSelectedOptions, int carId)
        {
            if (carSelectedOptions != null && carSelectedOptions.Any())
            {
                foreach (var carSelectedOption in carSelectedOptions)
                {
                    _carOptionRepository.Insert(new Car_Selected_Option()
                    {
                        CarID = carId,
                        OptionID = carSelectedOption
                    });
                }

                _carOptionRepository.Save();
            }
        }

        public void Dispose()
        {
            _carOptionRepository?.Dispose();
        }
    }
}
