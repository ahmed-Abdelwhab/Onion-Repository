﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain;
using Entites.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Infrastructure.Extensions;

namespace Repository.Infrastructure
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId),
trackChanges)
.FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
.Search(employeeParameters.SearchTerm)
.Sort(employeeParameters.OrderBy)
.ToListAsync();
            return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.PageNumber,
            employeeParameters.PageSize);
        }

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
