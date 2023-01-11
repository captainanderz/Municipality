using MunicipalityProject.Business.Enums;
using MunicipalityProject.Business.Extensions;
using MunicipalityProject.Contexts;

namespace MunicipalityProject.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly ApplicationDbContext _context;

        public MunicipalityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Business.Models.Municipality> GetAll()
        {
            return _context.Municipalities.ToList();
        }

        public Business.Models.Municipality GetSpecificMunicipality(string name, DateTime date)
        {
            var municipalities = _context.Municipalities.Where(x => x.Name == name).ToList();

            var dailyTax = municipalities.FirstOrDefault(x => x.Schedule == MunicipalitySchedules.Daily && x.Date.Equals(date));
            if (dailyTax != null)
            {
                return dailyTax;
            }

            var weeklyTax = municipalities.FirstOrDefault(x => x.Schedule == MunicipalitySchedules.Weekly && x.Date.Equals(date.StartOfWeek(DayOfWeek.Monday)));
            if (weeklyTax != null)
            {
                return weeklyTax;
            }

            var monthlyTax = municipalities.FirstOrDefault(x => x.Schedule == MunicipalitySchedules.Monthly && x.Date.Equals(date.FirstDayOfMonth()));
            if (monthlyTax != null)
            {
                return monthlyTax;
            }

            return municipalities.FirstOrDefault(x => x.Schedule == MunicipalitySchedules.Yearly && x.Date.Equals(date.FirstDayOfYear()));
        }

        public Business.Models.Municipality AddMunicipality(Business.Models.Municipality municipality)
        {
            var match = _context.Municipalities.FirstOrDefault(x => x.Name == municipality.Name && x.Schedule == municipality.Schedule && x.Date == municipality.Date);
            if (match != null)
            {
                match.TaxRate = municipality.TaxRate;
            }
            else
            {
                _context.Municipalities.Add(municipality);
            }

            _context.SaveChanges();
            return municipality;
        }

        public Business.Models.Municipality DeleteMunicipality(Business.Models.Municipality municipality)
        {
            var match = _context.Municipalities.FirstOrDefault(x => x.Name == municipality.Name && x.Schedule == municipality.Schedule && x.Date == municipality.Date && x.TaxRate == municipality.TaxRate);
            if (match == null)
            {
                return null;
            }
            _context.Municipalities.Remove(match);
            _context.SaveChanges();
            return municipality;
        }

        public List<Business.Models.Municipality> AddMunicipality(IEnumerable<Business.Models.Municipality> municipalities)
        {
            foreach (var municipality in municipalities)
            {
                var match = _context.Municipalities.FirstOrDefault(x => x.Name == municipality.Name && x.Schedule == municipality.Schedule && x.Date == municipality.Date && x.TaxRate != municipality.TaxRate);
                if (match != null)
                {
                    match.TaxRate = municipality.TaxRate;
                }
            }

            var sortedMunicipalities = municipalities.Where(x => !_context.Municipalities.Any(y => y.Name == x.Name && y.Date == x.Date && y.Schedule == x.Schedule && y.TaxRate == x.TaxRate)).ToList();
            
            if (sortedMunicipalities.Any())
            {
                _context.Municipalities.AddRange(sortedMunicipalities);
            }

            _context.SaveChanges();
            return sortedMunicipalities;
        }
    }
}