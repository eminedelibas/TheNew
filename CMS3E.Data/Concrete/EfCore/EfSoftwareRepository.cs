using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Data.Abstract;
using CMS.Entity;

namespace CMS.Data.Concrete.EfCore
{
    public class EfSoftwareRepository:ISoftwareRepository
    {
        private readonly Website3EContext _context;

        public EfSoftwareRepository(Website3EContext context)
        {
            _context = context;
        }
        public Software GetById(int Id)
        {
            return _context.Softwares.FirstOrDefault(p => p.Id == Id);
        }

        public IQueryable<Software> GetAll()
        {
            return _context.Softwares;
        }

        public void AddSoftware(Software entity)
        {
            _context.Softwares.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateSoftware(Software entity)
        {
            _context.SaveChanges();
        }

        public void DeleteSoftware(int Id)
        {
            var software = _context.Softwares.FirstOrDefault(p => p.Id == Id);
            if (software != null)
            {
                _context.Softwares.Remove(software);
                _context.SaveChanges();
            }
        }

        public void SaveSoftware(Software entity)
        {
            _context.SaveChanges();
        }
    }
}
