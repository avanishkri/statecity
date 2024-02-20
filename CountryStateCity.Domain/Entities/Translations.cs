using Newtonsoft.Json;

namespace CountryStateCity.Domain.Entities
{
    public class Translations
    {
        public int Id { get; set; } 
        public string Kr { get; set; } = string.Empty;

        [JsonProperty("pt-BR")]
        public string PtBR { get; set; } = string.Empty;
        public string Pt { get; set; } = string.Empty;
        public string Nl { get; set; } = string.Empty;
        public string Hr { get; set; } = string.Empty;
        public string Fa { get; set; } = string.Empty;
        public string De { get; set; } = string.Empty;
        public string Es { get; set; } = string.Empty;
        public string Fr { get; set; } = string.Empty;
        public string It { get; set; } = string.Empty;
        public string Cn { get; set; } = string.Empty;
        public string Tr { get; set; } = string.Empty;
    }
}
