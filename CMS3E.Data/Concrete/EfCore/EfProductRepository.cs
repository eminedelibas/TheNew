using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Data.Abstract;
using CMS.Entity;

namespace CMS.Data.Concrete.EfCore
{
    public class EfProductRepository:IProductRepository
    {
        private readonly Website3EContext _context;

        public EfProductRepository(Website3EContext context)
        {
            _context = context;
        }
        public Product GetById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public void AddProduct(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product entity)
        {
            _context.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void SaveProduct(Product entity)
        {
            _context.SaveChanges();
        }
    }
}
