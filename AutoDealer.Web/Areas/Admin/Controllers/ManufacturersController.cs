using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoDealer.Data.Vehicle;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Areas.Admin.Controllers
{
    public class ManufacturersController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ManufacturersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(unitOfWork.ManufacturerServices.GetAllManufacturers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ManufacturerServices.CreateManufacturer(manufacturer);
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: Admin/Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = unitOfWork.ManufacturerServices.GetManufacturerById(id.Value);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ManufacturerName,IsDelete")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ManufacturerServices.EditManufacturer(manufacturer);


                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Admin/Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unitOfWork.ManufacturerServices.DeleteManufacturer(id.Value);


            return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnManufacturer(int id)
        {
            int statusCode = unitOfWork.ManufacturerServices.ReturnManufacturer(id);

            if (statusCode == 200)
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);

        }

        #region Model

        public ActionResult CreateModel(int? manufacturerId)
        {
            return View(new Model()
            {
                ManufacturerId = manufacturerId.Value
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModel(Model model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ModelServices.CreateModel(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult EditModel(int id)
        {
            var model = unitOfWork.ModelServices.GetModelById(id);

            if (model == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditModel(Model model)
        {
            unitOfWork.ModelServices.EditModel(model);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteModel(int id)
        {
            var model = unitOfWork.ModelServices.GetModelById(id);
            if (model != null)
            {
                unitOfWork.ModelServices.DeleteHardModel(model);

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);

        }

        #endregion
        #region SubModel

        public ActionResult CreateSubModel(int? modelId)
        {
            return View(new SubModel()
            {
                ModelID = modelId.Value
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubModel(SubModel subModel)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SubModelServices.CreateSubModel(subModel);
                return RedirectToAction("Index");
            }

            return View(subModel);
        }

        public ActionResult EditSubModel(int id)
        {
            var subModel = unitOfWork.SubModelServices.GetSubModelById(id);

            if (subModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(subModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubModel(SubModel subModel)
        {
            unitOfWork.SubModelServices.EditSubModel(subModel);

            return RedirectToAction("Index");
        }   

        public ActionResult DeleteSubModel(int id)
        {
            var subModel = unitOfWork.SubModelServices.GetSubModelById(id);
            if (subModel != null)
            {
                unitOfWork.SubModelServices.DeleteSubModel(subModel);

                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);

        }

        #endregion



    }
}
