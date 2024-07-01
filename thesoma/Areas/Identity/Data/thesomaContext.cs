using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using thesoma.Areas.Identity.Data;

namespace thesoma.Data;

public class thesomaContext : IdentityDbContext<thesomaUser>
{
    public thesomaContext(DbContextOptions<thesomaContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<thesomaUser>
{
    public void Configure(EntityTypeBuilder<thesomaUser > builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);

    }

}