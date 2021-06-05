using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.JoinsForApi.Country.Interfaces
{
    public abstract class ForCountry
    {
        public int Id {set;get;}
        public string CountryCode { set; get; }

        public string  FullName  { set; get; }

        public string HolidayTypes { set; get; }
        public string Regions { get; set; }

    }
}
