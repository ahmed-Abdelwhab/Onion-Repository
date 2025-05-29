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

        public CompanyService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
           
            
                var companies = _repository.Company.GetAllCompanies(trackChanges);
              var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            
            return companiesDto;
            
            
        }
    }
  
}
