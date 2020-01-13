using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoDealer.Data.Vehicle;
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
   
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID", "ManufacturerName");
            ViewBag.Option_Category = unitOfWork.Option_CategoryServices.GetAllOption_Category();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car newCar, List<int> optionId)
        {
            if (ModelState.IsValid)
            {
                newCar.CreateTime=DateTime.Now;
                newCar.Specific = false;
                unitOfWork.CarServices.CreateCar(newCar);
                return RedirectToRoute("/");
            }
            ViewBag.ManufacturerId = new SelectList(unitOfWork.ManufacturerServices.GetAllManufacturers(), "ID", "ManufacturerName");
            ViewBag.Option_Category = unitOfWork.Option_CategoryServices.GetAllOption_Category();
            return View(newCar);
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