using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUDappWebAPIVersion.Models
{
    public class EmployeeRepo : IEmployee
    {
        private EmployeeDBContext _objEmlployeeDBContext;
        public EmployeeRepo(EmployeeDBContext employeeDBContextAccessLayer)
        {
            this._objEmlployeeDBContext = employeeDBContextAccessLayer;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            this._objEmlployeeDBContext.Add(employee);
            _objEmlployeeDBContext.SaveChanges();
            return employee;
        }

        //public void DeleteEmployee(Guid id)
        //{
        //    var employee = _objEmlployeeDBContext.Employees.Find(id);
        //    if (employee != null)
        //    {
        //        _objEmlployeeDBContext.Employees.Remove(employee);
        //        _objEmlployeeDBContext.SaveChanges();
        //    }
        //    //return employee;

        //}

        public void DeleteEmployee(Employee employee)
        {
            _objEmlployeeDBContext.Employees.Remove(employee);
            _objEmlployeeDBContext.SaveChanges();
           
        }

        

        public Employee GetEmployee(Guid id)
        {
            return (_objEmlployeeDBContext.Employees.FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this._objEmlployeeDBContext.Employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            this._objEmlployeeDBContext.Employees.Update(employee);
            this._objEmlployeeDBContext.SaveChanges();
        }
    }
}
