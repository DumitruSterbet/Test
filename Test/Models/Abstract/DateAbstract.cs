using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Interfaces;

namespace Test.Models.Abstract
{
    public abstract class DateAbstract :IEntity
    {
        public int Id { set; get; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
