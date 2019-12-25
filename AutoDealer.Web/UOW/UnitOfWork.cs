using AutoDealer.Data.Vehicle;
using AutoDealer.Repository.ApplicationContext;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.Impelementations;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Web.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private AutoDealerContext _context;

        public UnitOfWork(AutoDealerContext autoDealerContext)
        {
            _context = autoDealerContext;
        }

        private ICarServices _carServices;
        public ICarServices CarServices
        {
            get
            {
                if (_carServices == null)
                {
                    _carServices = new CarServices(new Repository<Car>(_context));
                }

                return _carServices;
            }
        }

        private ICar_GalleryServices _car_GalleryServices;

        public ICar_GalleryServices Car_GalleryServices
        {
            get
            {
                if (_car_GalleryServices == null)
                {
                    _car_GalleryServices = new Car_GalleryServices(new Repository<Car_Gallery>(_context));
                }

                return _car_GalleryServices;
            }
        }

        private IManufacturerServices _manufacturerServices;

        public IManufacturerServices ManufacturerServices
        {
            get
            {
                if (_manufacturerServices == null)
                {
                    _manufacturerServices=new ManufacturerServices(new Repository<Manufacturer>(_context));
                }

                return _manufacturerServices;
            }
        }

        private IModelServices _modelServices;

        public IModelServices ModelServices
        {
            get
            {
                if (_modelServices == null)
                {
                    _modelServices=new ModelServices(new Repository<Model>(_context));
                }

                return _modelServices;
            }
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}