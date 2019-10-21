using CMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Data.Abstract
{
    public interface IUserRepository
    {
        User GetById(int Id);
        IQueryable<User> GetAll();
        void AddUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(int Id);
        void SaveUser(User entity);
    }
}
