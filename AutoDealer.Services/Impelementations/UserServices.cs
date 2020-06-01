using System.Collections.Generic;
using System.Linq;
using AutoDealer.Repository.DataTransactions;
using AutoDealer.Services.DTO.User;
using AutoDealer.Services.Interfaces;

namespace AutoDealer.Services.Impelementations
{
    public class UserServices:IUserServices
    {
        private IRepository<User> _usRepository;

        public UserServices(IRepository<User> usRepository)
        {
            _usRepository = usRepository;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _usRepository.Get(null).ToList();
        }

        public void AddUser(User user)
        {
           _usRepository.Insert(user);
            _usRepository.Save();
        }

        public void EditUser(User user)
        {
            _usRepository.Update(user);
            _usRepository.Save();
        }

        public void DeleteUser(int userId)
        {
            var user=_usRepository.GetById(userId);
            user.IsDelete = true;
            EditUser(user);
        }

        public User GetUserById(int userId)
        {
           return _usRepository.GetById(userId);
        }
        public void Dispose()
        {
            _usRepository?.Dispose();
        }
    }
}
