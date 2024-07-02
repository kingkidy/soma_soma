using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using thesoma.Areas.Identity.Data;
using thesoma.Models;

namespace thesoma.Data
{
    public class thesomaContext : IdentityDbContext<thesomaUser>
    {
        public thesomaContext(DbContextOptions<thesomaContext> options)
            : base(options)
        {
        }

        public DbSet<ParentOrGuardian> ParentsOrGuardians { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure additional properties for thesomaUser
            builder.Entity<thesomaUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);
            });

            // Configure other entity mappings if needed
        }
    }
}
