using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.SserializationModels.Country
{
    public class CountryD
    {
        public string CountryCode { set; get; }
        [NotMapped]
        public List<string> Regions { set; get; }
        [NotMapped]
        public List<string> HolidayTypes { set; get; }
        public string FullName { get; set; }

        public FromDate FromDate { get; set; }

        public ToDate ToDate { get; set; }
    }
}
