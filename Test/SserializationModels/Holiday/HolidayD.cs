using System.Collections.Generic;

namespace Test.SserializationModels.Holiday
{
    public class HolidayD
    {public DateD Date { set; get; }
        public List<NameD> Name { set; get; }
        public string HolidayType { set; get; }
        public string Country { set; get; }
    }
}
