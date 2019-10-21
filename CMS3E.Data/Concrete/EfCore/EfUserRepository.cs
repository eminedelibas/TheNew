using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Data.Abstract;
using CMS.Entity;

namespace CMS.Data.Concrete.EfCore
{
    public class EfUserRepository:IUserRepository
    {
        private readonly Website3EContext _context;
        public EfUserRepository(Website3EContext context)
        {
            _context = context;
        }
        public User GetById(int Id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == Id);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public void AddUser(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateUser(User entity)
        {
            _context.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void SaveUser(User entity)
        {
            _context.SaveChanges();
        }
    }
}
