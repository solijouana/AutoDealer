using System.Collections.Generic;
using System.Linq;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.DTO.WebLog;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class BlogServices : IBlogServices
    {
        private IRepository<Blog> _blogRepository;

        public BlogServices(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _blogRepository.Get(null).ToList();
        }

        public void AddBlog(Blog blog)
        {
            _blogRepository.Insert(blog);
            _blogRepository.Save();
        }

        public void EditBlog(Blog blog)
        {
            _blogRepository.Update(blog);
            _blogRepository.Save();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = _blogRepository.GetById(blogId);
            blog.IsDelete = true;
            EditBlog(blog);
        }

        public Blog GetBlogById(int blogId)
        {
            return _blogRepository.GetById(blogId);
        }

        public void ReturnBlog(int blogId)
        {
            var blog = GetBlogById(blogId);
            blog.IsDelete = false;
            EditBlog(blog);
        }

        public void Dispose()
        {
            _blogRepository?.Dispose();
        }
    }
}
