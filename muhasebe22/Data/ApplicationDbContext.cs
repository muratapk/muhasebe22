using Microsoft.EntityFrameworkCore;
using muhasebe22.Models;
namespace muhasebe22.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<idare> idares { get; set; }
        public DbSet<Ogrenci> ogrencis { get; set; }
        public DbSet<ogretmen> ogretmens { get; set; }
        public DbSet<okul> okuls { get; set; }

        public DbSet<Admin> admins { get; set; }
    }
}
