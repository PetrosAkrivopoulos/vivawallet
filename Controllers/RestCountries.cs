using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VivaWallet.Models;
using static VivaWallet.Models.RestCountriesResponseObj;
using System.Runtime.Caching;
using System.Data.SqlClient;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace VivaWallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestCountries : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CountryRespList>> Get()
        {
                ObjectCache cache = MemoryCache.Default;
                HttpResponseMessage response = null;
                List<RetrieveFromDb> countriesFromDb = null;
                  
                // From Cache
                if (cache.Get("RestCountriesResponse") != null && (DateTime)cache.Get("RestCountriesResponseExpiration") > DateTime.UtcNow) 
                {
                    response = (HttpResponseMessage)cache.Get("RestCountriesResponse");
                }

                // From SQL Server
                if ( (1==0) && response == null)
                {
                    using (var connection = new SqlConnection(/*read connection string from somewhere as parameter*/))
                    {
                        try
                        {
                            countriesFromDb = MyLib.Generic.RetrieveFromDb(connection);
                            // Transform records and assign 'em to response so as to be of compatible data type for further execution
                        }
                    catch (Exception ex)
                        {
                            // Log somewhere the sql error (file, db table, etc.)
                        }
                    }
                }

                if(!(countriesFromDb != null && countriesFromDb.Count > 0))
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        try
                        {
                            response = await httpClient.GetAsync("https://restcountries.com/v3.1/all");

                            if (!response.IsSuccessStatusCode)
                            {
                                return BadRequest(response.StatusCode);
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            return BadRequest(e.Message);
                        }
                    }
                }

                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1440) };

                cache.Set("RestCountriesResponse", response, policy);
                cache.Set("RestCountriesResponseExpiration", DateTime.UtcNow, policy);

                CountryRespList countryList = new CountryRespList();

                foreach (var country in JsonConvert.DeserializeObject<List<Country>>(await response.Content.ReadAsStringAsync()))
                {
                    CountryDetails countryDetails = new CountryDetails
                    {
                        CommonName = country.Name?.Common,
                        Capital = country.Capital?.FirstOrDefault(),
                        Borders = country.Latlng != null ? string.Join("|",country.Latlng) : null
                    };

                    countryList.Countries.Add(countryDetails);
                }

                using (var connection = new SqlConnection(/*read connection string from somewhere as parameter*/))
                {
                    try
                    {
                        string query = $"" +
                            $"truncate table Countries" +
                            $"insert into Countries (commonname, capital, borders) " +
                            $"values";

                        foreach (var item in countryList.Countries)
                        {
                            query = query + $"({item.CommonName}, {item.Capital}, {item.Borders}),";
                        }

                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log the sql error somewhere (file, db table, etc.)
                    }
                }

                return countryList;
        }
    }
}
