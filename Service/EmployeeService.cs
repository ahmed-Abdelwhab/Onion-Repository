using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Domain;
using Service.Contracts;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public EmployeeService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger )
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
    }
}

