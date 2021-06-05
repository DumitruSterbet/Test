using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.HolydayModels;

namespace Test.JoinsForApi.Holidays
{
    public class HolidayWithDate
    {   public int Id { set; get; }
        public Date Date { get; set; }
        public string NameIds { get; set; }
        public string HolidayType { get; set; }
    }
}
