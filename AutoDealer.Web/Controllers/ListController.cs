using System.Web.Mvc;
using AutoDealer.Services.DTO.Advertise;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class ListController : Controller
    {
        private IUnitOfWork unitOfWork;
        public ListController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
       
        public ActionResult Car(int manufacturerId, int modelId)
        {
            ViewBag.ManufacturerName = unitOfWork.ManufacturerServices.GetManufacturerNameById(manufacturerId);
            ViewBag.ManufacturerId = new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID", "ManufacturerName");
            return View(unitOfWork.CarServices.GetCatalogCarsByFilter(new AdvertiseCatalogDto
            {
                ManufacturerId = manufacturerId,
                ModelId = modelId,
                TakeEntity = 1
            }));
        }
        public ActionResult ListCatalog(AdvertiseCatalogDto filterCatalog)
        {
            var cars = unitOfWork.CarServices.GetCatalogCarsByFilter(filterCatalog);
            ViewBag.Images = unitOfWork.Car_GalleryServices.GetCarGalleriesByCarsFilter(cars.Cars);

            return PartialView(cars);
        }
    }
}   