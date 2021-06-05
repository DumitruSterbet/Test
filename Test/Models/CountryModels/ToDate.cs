using Test.Models.Abstract;
using Test.SserializationModels.Country;

namespace Test.Models
{
    public class ToDate :DateAbstract
    {  
        public ToDate(CountryD countr)
        {
            Day = countr.ToDate.Day;
            Month = countr.ToDate.Month;
            Year = countr.ToDate.Year;

        }
        public ToDate() { }
    }
}
