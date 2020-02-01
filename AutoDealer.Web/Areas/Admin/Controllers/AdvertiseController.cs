using System.Web.Mvc;
using AutoDealer.Services.DTO.Advertise;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Areas.Admin.Controllers
{
    public class AdvertiseController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AdvertiseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult ListAdvertise(AdminAdvertiseDto filter,int? takeEntity)
        {
            if (takeEntity==null||takeEntity == 0)
            {
                filter.TakeEntity = 10;
            }
            else
            {
                filter.TakeEntity = (int)takeEntity;
            }
            var car = unitOfWork.CarServices.GetCarsByFilter(filter);

            return PartialView(car);
        }
    }
}