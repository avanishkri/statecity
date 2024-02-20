namespace CountryStateCity.Application.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Iso3 { get; set; } = string.Empty;
    }
}
