using System;
using System.Collections.Generic;
using DanskeBankMunicipality.Business.Models;

namespace DanskeBankMunicipality.Services
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