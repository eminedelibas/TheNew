using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Entity;

namespace CMS.Data.Abstract
{
    public interface ISoftwareRepository
    {
        Software GetById(int Id);
        IQueryable<Software> GetAll();
        void AddSoftware(Software entity);
        void UpdateSoftware(Software entity);
        void DeleteSoftware(int Id);
        void SaveSoftware(Software entity);
    }
}
