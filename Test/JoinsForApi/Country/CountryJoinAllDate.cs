using Test.JoinsForApi.Country.Interfaces;
using Test.Models;

namespace Test.JoinsForApi.Country
{
    public class CountryJoinAllDate :ForCountry
    {
        public FromDate FromDate { set; get; }
        public ToDate ToDate { get; set; }
    }
}
