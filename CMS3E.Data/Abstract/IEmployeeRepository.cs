using System.Linq;
using CMS.Entity;

namespace CMS.Data.Abstract
{
    public interface IEmployeeRepository
    {
        Employee GetById(int Id);
        IQueryable<Employee> GetAll();
        void AddEmployee(Employee entity);
        void UpdateEmployee(Employee entity);
        void DeleteEmployee(int Id);
        void SaveEmployee(Employee entity);
    }
}
