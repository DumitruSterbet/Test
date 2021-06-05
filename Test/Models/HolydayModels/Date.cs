using Test.Models.Abstract;
using Test.SserializationModels.Holiday;

namespace Test.Models.HolydayModels
{
    public class Date :DateAbstract
    {public int DayOfWeek { set; get; }
        public Date (DateD dateD)
        {
            this.Day = dateD.Day;
            this.DayOfWeek = dateD.DayOfWeek;
            this.Month = dateD.Month;
            this.Year = dateD.Year;

        }
        public Date() { }
    }
}
