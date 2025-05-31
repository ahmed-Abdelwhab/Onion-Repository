using AutoMapper;
using Contracts.Domain;
using Entites.Domain.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CompanyService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            _logger.LogInfo("GetAllCompanies method called from CompanyService.");

            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);

                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                return companiesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method { ex}"); 
           throw;
            }
        }

    }
    
}
