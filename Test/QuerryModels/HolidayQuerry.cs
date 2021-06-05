using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.SserializationModels.Holiday;

namespace Test.QuerryModels
{
    public class HolidayQuerry
    { public int Id { set; get; }
       public int Year { set; get; }
        public int Day { set; get; }
        public int DayOfWeek { set; get; }
        public int Month { set; get; }
        public string Name { set; get; }
        public string HolidayType { set; get; }
        public string Country { set; get; }
       
    }
}
