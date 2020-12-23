using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDappWebAPIVersion.Models
{
    public interface IEmployee
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        //void DeleteEmployee(Guid id);

        void DeleteEmployee(Employee employee);

        void UpdateEmployee(Employee employee);
    }
}
