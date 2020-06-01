using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoDealer.Services.DTO.WebLog;
using AutoDealer.Utilities.ImageTools;
using AutoDealer.Web.UOW;

namespace AutoDealer.Web.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private IUnitOfWork unitOfWork;
        public Task task;
        public BlogController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View(unitOfWork.BlogServices.GetAllBlogs());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase imgUp)
        {

            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    string imageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    string imagePath = ImagePath.BlogImageServerPath;
                    string thumbPath = ImagePath.BlogThumbImageServerPath;
                    blog.ImageName = imageName;
                    task = Task.Run(() => { imgUp.AddImageToServer(imageName, imagePath, null, null, thumbPath); });
                }

                blog.CreateDate = DateTime.Now;
                blog.IsDelete = false;
                blog.UserId = 1;
                unitOfWork.BlogServices.AddBlog(blog);

                if (task!=null)
                    Task.WaitAny(task);

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        public ActionResult Edit(int id)
        {
            var blog = unitOfWork.BlogServices.GetBlogById(id);
            if (blog == null)
                return HttpNotFound();

            return View(blog);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (blog.ImageName != "no-photo")
                    {
                        string imageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                        string imagePath = ImagePath.BlogImageServerPath;
                        string thumbPath = ImagePath.BlogThumbImageServerPath;
                        imgUp.AddImageToServer(imageName, imagePath, null, null, thumbPath, blog.ImageName);
                        blog.ImageName = imageName;
                    }
                    else
                    {
                        string imageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                        string imagePath = ImagePath.BlogImageServerPath;
                        string thumbPath = ImagePath.BlogThumbImageServerPath;
                        blog.ImageName = imageName;
                        imgUp.AddImageToServer(imageName, imagePath, null, null, thumbPath);
                    }
                }

                blog.IsDelete = false;
                unitOfWork.BlogServices.EditBlog(blog);

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        public ActionResult DeleteBlog(int id)
        {
            var blog = unitOfWork.BlogServices.GetBlogById(id);
            if (blog != null)
            {
                unitOfWork.BlogServices.DeleteBlog(blog.ID);
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReturnBlog(int id)
        {
            var blog = unitOfWork.BlogServices.GetBlogById(id);
            if (blog != null)
            {
                unitOfWork.BlogServices.ReturnBlog(blog.ID);
                return Json(new { status = "Done" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "NotFound" }, JsonRequestBehavior.AllowGet);
        }
    }
}