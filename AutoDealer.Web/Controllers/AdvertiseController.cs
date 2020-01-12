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
        public ActionResult ReloadModelList(int manufacturerId)    
        {
            var model = unitOfWork.ModelServices.GetListModelByManufacturerId(manufacturerId);
            SelectList obgModeList = new SelectList(model, "ID", "ModelTitle", 0);

            return Json(obgModeList);
        }

        [HttpPost]
        public ActionResult ReloadSubModelList(int modelId)
        {
            var subModel = unitOfWork.ModelServices.GetSubModelsListByModelId(modelId);
            SelectList obgSubModelList=new SelectList(subModel,"ID","SubModelTitle",0);

            return Json(obgSubModelList);
        }
    }
}