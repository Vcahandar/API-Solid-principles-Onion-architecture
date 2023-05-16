using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DomainLayer.Configurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SoftDelete).IsRequired(false).HasDefaultValue(false);
            builder.Property(m => m.CreatedAt).IsRequired(false).HasDefaultValue(DateTime.Now);
        }
    }
}
