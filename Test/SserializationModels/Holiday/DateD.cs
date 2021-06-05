using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Abstract;

namespace Test.SserializationModels.Holiday
{
    public class DateD
    { public int Month { set; get; }
        public int Year { set; get; }
        public int Day { set; get; }
        public int DayOfWeek { set; get; }
    }
}
