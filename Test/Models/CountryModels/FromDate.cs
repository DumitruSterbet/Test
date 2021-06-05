using Test.Models.Abstract;
using Test.SserializationModels.Country;

namespace Test.Models
{
    public class FromDate :DateAbstract
    {
       

        public FromDate (CountryD countr)
        {
            Day = countr.FromDate.Day;
            Month = countr.FromDate.Month;
            Year = countr.FromDate.Year;

        }
        public FromDate() { }
    }
}
