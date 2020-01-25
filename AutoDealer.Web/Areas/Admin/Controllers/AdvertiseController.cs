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

        public ActionResult ListAdvertise(AdminAdvertiseDto filter)
        {
            filter.TakeEntity = 10;
            var car = unitOfWork.CarServices.GetCarsByFilter(filter);

            return View(car);
        }
    }
}