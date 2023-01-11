using AutoMapper;
using MunicipalityProject.Business.Models;

namespace MunicipalityProject.Business
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Municipality, MunicipalityDto>();
            CreateMap<MunicipalityDto, Municipality>();
        }
    }
}