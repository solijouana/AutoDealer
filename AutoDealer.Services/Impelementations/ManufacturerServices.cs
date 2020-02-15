using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class ManufacturerServices : IManufacturerServices
    {
        private IRepository<Manufacturer> _manuRepository;

        public ManufacturerServices(IRepository<Manufacturer> manuRepository)
        {
            _manuRepository = manuRepository;
        }


        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return _manuRepository.Get(null).ToList();
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

        public void DeleteManufacturer(int manufacturerId)
        {
            var manufacturer = GetManufacturerById(manufacturerId);
            DeleteManufacturer(manufacturer);
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _manuRepository.GetById(manufacturerId);
        }

        public int ReturnManufacturer(int id)
        {
            var manufacturer = _manuRepository.GetById(id);
            if (manufacturer != null)
            {
                manufacturer.IsDelete = false;
                EditManufacturer(manufacturer);
                return (int)HttpStatusCode.OK;
            }

            return (int)HttpStatusCode.NotFound;

        }

        public string GetManufacturerNameById(int manufacturerId)
        {
            return _manuRepository.GetById(manufacturerId).ManufacturerName;
        }

        public void Dispose()
        {
            _manuRepository?.Dispose();
        }

    }
}
