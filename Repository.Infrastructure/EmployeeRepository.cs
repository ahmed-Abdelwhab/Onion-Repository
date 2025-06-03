using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain;
using Entites.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Infrastructure
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && !e.IsDeleted, trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id) && !e.IsDeleted, trackChanges)
                .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public void SoftDeleteEmployee(Employee employee)
        {
            employee.IsDeleted = true;
            Update(employee);
        }
    }

}
