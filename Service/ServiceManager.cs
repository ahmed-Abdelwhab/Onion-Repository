﻿using AutoMapper;
using Contracts.Domain;
using Entites.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager logger, IDataShaper<EmployeeDto> dataShaper, UserManager<User> userManager,
 IConfiguration configuration) 
        {
            _companyService = new Lazy<ICompanyService>(() =>
            new CompanyService(repositoryManager, mapper , logger));
            _employeeService = new Lazy<IEmployeeService>(() =>
           new EmployeeService(repositoryManager, logger, mapper, dataShaper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
   new AuthenticationService(logger, mapper, userManager,
configuration));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IAuthenticationService AuthenticationService =>
_authenticationService.Value;
    }

}