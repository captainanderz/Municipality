using DanskeBankMunicipality.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DanskeBankMunicipality.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Municipality> Municipalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Municipality>().HasKey(x => new
            //{
            //    x.Name,
            //    x.Schedule
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}