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


        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}