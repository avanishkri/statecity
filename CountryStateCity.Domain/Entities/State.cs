namespace CountryStateCity.Domain.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StateCode { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
