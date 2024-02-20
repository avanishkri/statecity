using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Domain.Entities;

namespace CountryStateCity.Application.Mapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
