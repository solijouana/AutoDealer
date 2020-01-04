using System.Net;
using System.Web.Mvc;
using AutoDealer.Data.Vehicle;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Areas.Admin.Controllers
{
    public class Option_CategoryController : Controller
    {
        private IUnitOfWork unitOfWork;

        public Option_CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View(unitOfWork.Option_CategoryServices.GetAllOption_Category());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Option_Category optionCategory)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Option_CategoryServices.CreateOption_Category(optionCategory);

                return RedirectToAction("Index");
            }

            return View(optionCategory);
        }

        public ActionResult Edit(int id)
        {
            var category = unitOfWork.Option_CategoryServices.GetOption_CategoryById(id);

            if (category==null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Option_Category ediCategory)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Option_CategoryServices.EditOption_Category(ediCategory);
                return RedirectToAction("Index");
            }

            return View(ediCategory);
        }

        public ActionResult Delete(int id)
        {
            var category = unitOfWork.Option_CategoryServices.GetOption_CategoryById(id);

            if (category != null)
            {
                unitOfWork.Option_CategoryServices.DeleteOption_Category(category);

                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnCategory(int id)
        {
            var category = unitOfWork.Option_CategoryServices.GetOption_CategoryById(id);

            if (category != null)
            {
                unitOfWork.Option_CategoryServices.ReturnOption_Category(category);

                return Json(new {status = "Done"}, JsonRequestBehavior.AllowGet);
            }

            return Json(new {status = "NotFound"}, JsonRequestBehavior.AllowGet);
        }
    }
}