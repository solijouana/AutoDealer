using AutoDealer.Services.Interfaces;
using System.Web.Mvc;
using AutoDealer.Data.Vehicle;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Areas.Admin.Controllers
{
    public class ModelsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ModelsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListModel()
        {
            return PartialView(unitOfWork.ModelServices.GetAllModels());
        }

        public ActionResult Create(int? id)
        {
            return PartialView(new Model
            {
                ParentID = id
            });
        }

        [HttpPost]
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ModelServices.CreateModel(model);
                return PartialView("ListModel");
            }

            return View(model);
        }
    }
}