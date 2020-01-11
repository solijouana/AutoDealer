using System.Linq;
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
            ViewBag.ManufacturersID = new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID", "ManufacturerName");
            ViewBag.Options = unitOfWork.Option_CategoryServices.GetAllOption_Category();
            return View();
        }

        [HttpPost]
        public ActionResult ReloadModelList(int stateid)    
        {
            var model = unitOfWork.ModelServices.GetListModelByManufacturerId(stateid);
            SelectList obgModeList = new SelectList(model, "ID", "ModelTitle", 0);
            return Json(obgModeList);
        }
    }
}