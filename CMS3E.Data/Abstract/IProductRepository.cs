using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Entity;

namespace CMS.Data.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int Id);
        IQueryable<Product> GetAll();
        void AddProduct(Product entity);
        void UpdateProduct(Product entity);
        void DeleteProduct(int Id);
        void SaveProduct(Product entity);
    }
}
