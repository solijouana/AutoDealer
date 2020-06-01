using System;
using System.Collections.Generic;
using AutoDealer.Services.DTO.WebLog;

namespace AutoDealer.Services.Interfaces
{
    public interface IBlogServices:IDisposable
    {
        IEnumerable<Blog> GetAllBlogs();
        void AddBlog(Blog blog);
        void EditBlog(Blog blog);
        void DeleteBlog(int blogId);
        Blog GetBlogById(int blogId);
        void ReturnBlog(int blogId);
    }
}
