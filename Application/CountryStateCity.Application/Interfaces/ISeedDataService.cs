namespace CountryStateCity.Application.Interfaces
{
    public interface ISeedDataService
    {
        void SeedData(CancellationToken cancellationToken);
    }
}