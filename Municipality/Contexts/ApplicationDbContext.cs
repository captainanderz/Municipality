using Microsoft.EntityFrameworkCore;

namespace MunicipalityProject.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Business.Models.Municipality> Municipalities { get; set; }
    }
}