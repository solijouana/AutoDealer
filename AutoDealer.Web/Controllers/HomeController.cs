using System.Web.Mvc;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView();
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        public ActionResult LastCars()
        {
            return PartialView(unitOfWork.CarServices.GetLastCars());
        }

        public ActionResult Banner()
        {
            return PartialView();
        }

        public ActionResult RecentBlog()
        {
            return PartialView();
        }

        public ActionResult ViewBox()
        {
            return PartialView();
        }

        public ActionResult CarNews()
        {
            return PartialView();
        }

    }
}