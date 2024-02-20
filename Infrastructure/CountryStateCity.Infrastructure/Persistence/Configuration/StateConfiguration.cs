using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountryStateCity.Infrastructure.Persistence.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.HasKey(e => e.Id);
            builder.HasMany<City>(g => g.Cities)
                .WithOne(s => s.State)
                .HasForeignKey(fk => fk.StateId);
        }
    }
}
