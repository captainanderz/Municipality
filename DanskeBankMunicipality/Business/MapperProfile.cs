using AutoMapper;
using DanskeBankMunicipality.Business.Models;

namespace DanskeBankMunicipality.Business
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Municipality, MunicipalityDto>().ReverseMap();
            //CreateMap<MunicipalityDto, Municipality>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}