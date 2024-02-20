using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountryStateCity.Infrastructure.Persistence.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(e => e.Id);
            builder.HasMany<State>(g => g.States)
                .WithOne(s => s.Country)
                .HasForeignKey(fk => fk.CountryId);
        }
    }
}
