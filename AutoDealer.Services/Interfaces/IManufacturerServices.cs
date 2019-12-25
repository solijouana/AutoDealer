using System;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IManufacturerServices:IDisposable
    {
        void CreateManufacturer(Manufacturer newManufacturer);
        void EditManufacturer(Manufacturer editedManufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(int manufacturerId);
        Task<Manufacturer> GetManufacturerById(int manufacturerId);
    }
}
