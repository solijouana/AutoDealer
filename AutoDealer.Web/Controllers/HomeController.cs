using System.Web.Mvc;

namespace AutoDealer.Web.Controllers
{
    public class HomeController : Controller
    {
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
            return PartialView();
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