using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWarsAPI.Models;
using StarWarsAPI.Models;
namespace StarWarsAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Character> Characters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
                .Ignore(c => c.Movies)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Character>()
                .Property(c => c.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById);
        }
    }
}
