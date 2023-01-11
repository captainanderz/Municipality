using Microsoft.EntityFrameworkCore;
using MunicipalityProject.Business.Models;

namespace MunicipalityProject.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Municipality> Municipalities { get; set; }
    }
}