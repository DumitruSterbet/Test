using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.HolydayModels;

namespace Test.JoinsForApi.Holidays
{
    public class HolidayFinal
    {
        public Date Date { set; get; }
        public List<Name> Name { set; get; }
        public string HolidayType { set; get; }
    }
}
