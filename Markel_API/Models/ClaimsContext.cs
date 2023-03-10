using Microsoft.EntityFrameworkCore;

namespace Markel_API.Models
{
    public class ClaimsContext: DbContext
    {
        public ClaimsContext(DbContextOptions<ClaimsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Claims)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);                

            modelBuilder.Entity<Claims>()
                .HasKey(x => x.UCR);

            modelBuilder.Seed();
        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Claims> Claims { get; set; }
    }
}
