﻿namespace VivaWallet.Models
{
    public class RestCountriesDeserializeObj
    {      
        public List<Country> Countries { get; set; }
    }

    public class Country
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public string Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public Currencies Currencies { get; set; }
        public Idd Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public Languages Languages { get; set; }
        public Translations Translations { get; set; }
        public List<double> Latlng { get; set; }
        public bool Landlocked { get; set; }
        public float Area { get; set; }
        public Demonyms Demonyms { get; set; }
        public string Flag { get; set; }
        public Maps Maps { get; set; }
        public int Population { get; set; }
        public Car Car { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Continents { get; set; }
        public Flags Flags { get; set; }
        public CoatOfArms CoatOfArms { get; set; }
        public string StartOfWeek { get; set; }
        public CapitalInfo CapitalInfo { get; set; }
        public PostalCode PostalCode { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public NativeName NativeName { get; set; }
    }

    public class NativeName
    {
        public Fra Fra { get; set; }
    }

    public class Fra
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Currencies
    {
        public Dictionary<string, Currency> CurrenciesData { get; set; }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }

    public class Idd
    {
        public string Root { get; set; }
        public List<string> Suffixes { get; set; }
    }

    public class Languages
    {
        public Dictionary<string, string> LanguagesData { get; set; }
    }

    public class Translations
    {
        public Dictionary<string, Translation> TranslationsData { get; set; }
    }

    public class Translation
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Demonyms
    {
        public Eng Eng { get; set; }
        public Fra Fra { get; set; }
    }

    public class Eng
    {
        public string F { get; set; }
        public string M { get; set; }
    }

    public class Maps
    {
        public string GoogleMaps { get; set; }
        public string OpenStreetMaps { get; set; }
    }

    public class Car
    {
        public List<string> Signs { get; set; }
        public string Side { get; set; }
    }

    public class Flags
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }

    public class CoatOfArms
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }

    public class CapitalInfo
    {
        public List<double> Latlng { get; set; }
    }

    public class PostalCode
    {
        public string Format { get; set; }
        public string Regex { get; set; }
    }

}
