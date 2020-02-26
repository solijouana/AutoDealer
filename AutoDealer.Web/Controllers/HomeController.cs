using System.Web.Mvc;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView();
        }

        public ActionResult Search()
        {
            ViewBag.ManufacturerId = new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID",
                "ManufacturerName");
            return PartialView();
        }

        public ActionResult LastCars()
        {
            var lastCars = unitOfWork.CarServices.GetLastCars();
            ViewBag.Images = unitOfWork.Car_GalleryServices.GetCarGalleriesByCarsFilter(lastCars);
            return PartialView(lastCars);
        }

        public ActionResult Banner()
        {
            return PartialView();
        }

        public ActionResult RecentBlog()
        {
            return PartialView();
        }

        public ActionResult ViewBox()
        {
            return PartialView();
        }

        public ActionResult CarNews()
        {
            return PartialView();
        }

    }
}