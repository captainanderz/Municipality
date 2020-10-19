using System;
using System.Collections.Generic;
using System.Linq;
using DanskeBankMunicipality.Business.Enums;
using DanskeBankMunicipality.Business.Extensions;
using DanskeBankMunicipality.Business.Models;
using DanskeBankMunicipality.Contexts;

namespace DanskeBankMunicipality.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly ApplicationDbContext _context;

        public MunicipalityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Municipality> GetAll()
        {
            return _context.Municipalities.ToList();
        }

        public Municipality GetSpecificMunicipality(string name, DateTime date)
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

        public Municipality AddMunicipality(Municipality municipality)
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

        public Municipality DeleteMunicipality(Municipality municipality)
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

        public List<Municipality> AddMunicipality(IEnumerable<Municipality> municipalities)
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