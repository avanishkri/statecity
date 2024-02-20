using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountryStateCity.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<State> States { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Timezone> Timezones { get; set; }
        DbSet<Translations> Translations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        
    }
}