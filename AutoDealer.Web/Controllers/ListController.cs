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
       
        [Route("Car/{manufacturerId}/{modelId}")]
        public ActionResult Car(int manufacturerId, int modelId)
        {
            ViewBag.ManufacturerName = unitOfWork.CarServices.GetManufacturerNameById(manufacturerId);
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
            return PartialView(unitOfWork.CarServices.GetCatalogCarsByFilter(filterCatalog));
        }
    }
}   