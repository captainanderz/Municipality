using System;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using DanskeBankMunicipality.Business.Enums;

namespace DanskeBankMunicipality.Business.Models
{
    public class MunicipalityDto
    {
        public string Name { get; set; }
        public MunicipalitySchedules Schedule { get; set; }
        public double TaxRate { get; set; }
        public DateTime Date { get; set; }

        public bool Validate(MunicipalityDto municipality)
        {
            return municipality.GetType().GetProperties().All(p => p.GetValue(municipality) != null);
        }
    }

    public sealed class MunicipalityDtoMap : ClassMap<MunicipalityDto>
    {
        public MunicipalityDtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}