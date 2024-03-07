using KYC360_Assessment.Entites;
using Microsoft.EntityFrameworkCore;

namespace KYC360_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
           .HasMany(p => p.Addresses)  // Patient has many Addresses
           .WithOne()                  // Address has one Patient
           .HasForeignKey(a => a.Id); // Foreign key property in Address referring to Patient

            base.OnModelCreating(modelBuilder);
        }
        */

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Date> Dates { get; set; }
        
    }
}
