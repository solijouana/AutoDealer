using System.Web.Mvc;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class AdvertiseController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AdvertiseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        
        [Route("CreateAdv")]
        public ActionResult Create()
        {
            ViewBag.ManufacturersID=new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(),"ID","ManufacturerName");
            return View();
        }
    }
}