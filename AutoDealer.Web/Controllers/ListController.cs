using System.Collections.Generic;
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
            List<SelectListItem>listItems=new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "0",
                    Text = @"مدل را انتخاب کنید"
                }
            };

            var manufacturer= new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID", "ManufacturerName");
            listItems.AddRange(manufacturer);
            ViewBag.ManufacturerId = listItems;
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