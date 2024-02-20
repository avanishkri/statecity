namespace CountryStateCity.Domain.Entities
{
    public class Timezone
    {
        public int Id { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public int GmtOffset { get; set; } 
        public string GmtOffsetName { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string TzName { get; set; } = string.Empty;
    }
}
