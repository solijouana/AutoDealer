using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoDealer.Data.Vehicle;

namespace AutoDealer.Services.Interfaces
{
    public interface IManufacturerServices:IDisposable
    {
        IEnumerable<Manufacturer> GetAllManufacturers();
        void CreateManufacturer(Manufacturer newManufacturer);
        void EditManufacturer(Manufacturer editedManufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(int manufacturerId);
        Manufacturer GetManufacturerById(int manufacturerId);
        int ReturnManufacturer(int id);
    }
}
