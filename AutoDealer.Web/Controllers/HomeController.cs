using System.Linq;
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
            return PartialView(unitOfWork.CarServices.GetSliders());
        }

        public ActionResult Search()
        {
            var manufacturer= new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID",
                "ManufacturerName");
            ViewBag.ManufacturerId = manufacturer;

            var models=new SelectList(unitOfWork.ModelServices.GetListModelByManufacturerId(int.Parse(manufacturer.First().Value)),"ID","ModelTitle");
            ViewBag.ModelId = models;

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