using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Domain.Entities;

namespace CountryStateCity.Application.Mapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
