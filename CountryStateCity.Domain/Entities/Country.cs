﻿#nullable enable

namespace CountryStateCity.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Iso3 { get; set; } = string.Empty;
        public string Iso2 { get; set; } = string.Empty;
        public string NumericCode { get; set; } = string.Empty;
        public string PhoneCode { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = string.Empty;
        public string Tld { get; set; } = string.Empty;
        public string Native { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Subregion { get; set; } = string.Empty;
        public List<Timezone> Timezones { get; set; } 
        public Translations Translations { get; set; }
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Emoji { get; set; } = string.Empty;
        public string EmojiU { get; set; } = string.Empty;
        public virtual List<State> States { get; set; }
    }
}
