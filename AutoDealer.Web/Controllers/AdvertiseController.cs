using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoDealer.Data.Vehicle;
using AutoDealer.Utilities.Convertors;
using AutoDealer.Utilities.ImageTools;
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
        public ActionResult Create(Car newCar, List<int> optionId, List<HttpPostedFileBase> imgUp)
        {
            if (ModelState.IsValid)
            {
                if (newCar.SubModelId == 0)
                {
                    return Redirect("/Advertise/Create?requierd=true");
                }

                List<string> fileNames = new List<string>();
                int count = 0;
                if (imgUp.Any())
                {
                    foreach (var image in imgUp)
                    {
                        if (image != null)
                        {
                            fileNames.Add(Guid.NewGuid() + image.FileName);
                            string imagePath = Server.MapPath("/Images/Cars/");
                            string thumbPath = Server.MapPath("/Images/Cars/Thumb/");
                            image.AddImageToServer(fileNames[count], imagePath, null, null, thumbPath);
                            count++;
                        }
                    }
                }

                newCar.CreateTime = DateTime.Now;
                newCar.Specific = false;
                unitOfWork.CarServices.CreateCar(newCar);
                unitOfWork.Car_GalleryServices.InsertMultiImage(fileNames, newCar.ID);
                unitOfWork.Car_Selected_Option.InsertSelectedOptions(optionId, newCar.ID);

                return RedirectToAction("Index", "Home");
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
            SelectList obgSubModelList = new SelectList(subModel, "ID", "SubModelTitle", 0);

            return Json(obgSubModelList);
        }
    }
}