using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
   public class ManufacturerServices:IManufacturerServices
   {
       private IRepository<Manufacturer> _manuRepository;

       public ManufacturerServices(IRepository<Manufacturer> manuRepository)
       {
           _manuRepository = manuRepository;
       }

        public void CreateManufacturer(Manufacturer newManufacturer)
        {
            _manuRepository.Insert(newManufacturer);
            _manuRepository.Save();
        }

        public void EditManufacturer(Manufacturer editedManufacturer)
        {
            _manuRepository.Update(editedManufacturer);
            _manuRepository.Save();
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            manufacturer.IsDelete = true;
            EditManufacturer(manufacturer);
        }

        public async void DeleteManufacturer(int manufacturerId)
        {
            var manufacturer =await GetManufacturerById(manufacturerId);
            if (manufacturer != null)
            {
                DeleteManufacturer(manufacturer);
            }
        }

        public async Task<Manufacturer> GetManufacturerById(int manufacturerId)
        {
            return await _manuRepository.GetById(manufacturerId);
        }
        public void Dispose()
        {
            _manuRepository?.Dispose();
        }

    }
}
