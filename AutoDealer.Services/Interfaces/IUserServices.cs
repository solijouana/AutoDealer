using System;
using System.Collections.Generic;
using AutoDealer.Services.DTO.User;

namespace AutoDealer.Services.Interfaces
{
    public interface IUserServices:IDisposable
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
    }
}
