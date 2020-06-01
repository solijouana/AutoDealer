using System;
using System.Linq;
using System.Web.Mvc;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Controllers
{
    public class BlogController : Controller
    {
        private IUnitOfWork unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
           this.unitOfWork = unitOfWork;
        }
        public ActionResult Index(int pageId=1)
        {
            var blogs = unitOfWork.BlogServices.GetAllBlogs();
            ViewBag.pageCount = (int)Math.Ceiling((decimal)blogs.Count() /8);
            ViewBag.CurrentPage = pageId;
            int skip = (pageId - 1) * 8;
            return View(blogs.OrderByDescending(b=>b.CreateDate).Skip(skip).Take(8).ToList());
        }

        public ActionResult ShowBlog(int id)
        {
            var blog = unitOfWork.BlogServices.GetBlogById(id);
            if (blog == null)
                return HttpNotFound();

            return View(blog);
        }
    }
}