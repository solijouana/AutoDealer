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

    }
}
