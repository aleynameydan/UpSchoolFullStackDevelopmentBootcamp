using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Identity;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaims>
{
    public void Configure(EntityTypeBuilder<RoleClaims> builder)
    {
        // Primary key
        builder.HasKey(rc => rc.Id);
        builder.Property(x => x.Id).HasMaxLength(191);

        // Maps to the AspNetRoleClaims table
        builder.ToTable("RoleClaims");
    }
    
}