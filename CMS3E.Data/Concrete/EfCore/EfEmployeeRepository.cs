using System.Linq;
using CMS.Data.Abstract;
using CMS.Entity;

namespace CMS.Data.Concrete.EfCore
{
    public class EfEmployeeRepository : IEmployeeRepository
    {
        private readonly Website3EContext _context;
        public EfEmployeeRepository(Website3EContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if(employee!=null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int Id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == Id);
        }

        public void SaveEmployee(Employee entity)
        {
            
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee entity)
        {
           
            _context.SaveChanges();
        }
    }
}
