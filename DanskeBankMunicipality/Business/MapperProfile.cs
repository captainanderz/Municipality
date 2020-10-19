using DanskeBankMunicipality.Business.Models;

namespace DanskeBankMunicipality.Business
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Municipality, MunicipalityDto>();
            CreateMap<MunicipalityDto, Municipality>();
        }
    }
}