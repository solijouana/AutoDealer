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
            ViewBag.Images = unitOfWork.Car_GalleryServices.GetCarGalleriesByCarsFilter(car.Cars);

            return PartialView(car);
        }

        public ActionResult DeleteAdv(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                unitOfWork.CarServices.DeleteCar(car);
                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnAdv(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                car.IsDelete = false;
                unitOfWork.CarServices.EditCar(car);
                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActiveAdv(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                car.IsActive = true;
                unitOfWork.CarServices.EditCar(car);
                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeActiveAdv(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                car.IsActive = false;
                unitOfWork.CarServices.EditCar(car);
                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Specific(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                car.Specific = true;
                unitOfWork.CarServices.EditCar(car);
                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnSpecific(int id)
        {
            var car = unitOfWork.CarServices.GetCarById(id);
            if (car != null)
            {
                car.Specific = false;
                unitOfWork.CarServices.EditCar(car);
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }
    }
}