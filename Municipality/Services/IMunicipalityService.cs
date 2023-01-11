namespace MunicipalityProject.Services
{
    public interface IMunicipalityService
    {
        List<Business.Models.Municipality> GetAll();
        Business.Models.Municipality GetSpecificMunicipality(string name, DateTime date);
        Business.Models.Municipality AddMunicipality(Business.Models.Municipality municipality);
        Business.Models.Municipality DeleteMunicipality(Business.Models.Municipality municipality);
        List<Business.Models.Municipality> AddMunicipality(IEnumerable<Business.Models.Municipality> municipality);
    }
}