using Test.JoinsForApi.Country.Interfaces;
using Test.Models;

namespace Test.JoinsForApi.Country
{
    public class CountryJoinToDate :ForCountry
    {  
        public ToDate ToDate { get; set; }
        public int FromDateId { get; set; }
       
    }
}
