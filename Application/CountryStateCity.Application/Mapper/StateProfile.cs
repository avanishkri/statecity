using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Domain.Entities;

namespace CountryStateCity.Application.Mapper
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDto>();
        }
    }
}
