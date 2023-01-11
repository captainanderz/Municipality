using MunicipalityProject.Business.Models;

namespace MunicipalityProject.Services
{
    public interface IMunicipalityService
    {
        List<Municipality> GetAll();
        Municipality GetSpecificMunicipality(string name, DateTime date);
        Municipality AddMunicipality(Municipality municipality);
        Municipality DeleteMunicipality(Municipality municipality);
        List<Municipality> AddMunicipality(IEnumerable<Municipality> municipality);
    }
}