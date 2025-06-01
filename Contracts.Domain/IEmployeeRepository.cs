using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites.Domain.Models;

namespace Contracts.Domain
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);


    }
}
