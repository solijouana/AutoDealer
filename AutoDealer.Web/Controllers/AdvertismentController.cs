using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoDealer.Data.Vehicle;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class AdvertismentController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public AdvertismentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Car> GetAllCars()
        {
            return _unitOfWork.CarServices.GetAllCars().ToList();
        }
    }
}
