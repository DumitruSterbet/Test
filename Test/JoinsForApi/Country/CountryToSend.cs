using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.JoinsForApi.Country
{
    public class CountryToSend
    {
        public int Id { set; get; }
        public string CountryCode { set; get; }

        public string FullName { set; get; }

        public List<string> HolidayTypes { set; get; }
        public List<string> Regions { get; set; }
        public FromDate FromDate { set; get; }
        public ToDate ToDate { get; set; }
    }
}
