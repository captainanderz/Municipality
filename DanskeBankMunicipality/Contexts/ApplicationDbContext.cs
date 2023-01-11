using DanskeBankMunicipality.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DanskeBankMunicipality.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Municipality> Municipalities { get; set; }
    }
}