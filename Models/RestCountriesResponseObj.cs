namespace VivaWallet.Models
{
    public class RestCountriesResponseObj
    {
        public class CountryRespList
        {
            public List<CountryDetails> Countries { get; set; }

            public CountryRespList()
            {
                Countries = new List<CountryDetails>();
            }
        }


        public class CountryDetails
        {
            public string? CommonName { get; set; }
            public string? Capital { get; set; }
            public string? Borders { get; set; }

        }
    }
    
    
}
