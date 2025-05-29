using AutoMapper;
using Entites.Domain.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress", opt =>
                opt.MapFrom(src => string.Join(' ', src.Address, src.Country)));
        }
    }
}
