using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Interfaces;

namespace Test.Models.HolydayModels
{
    public class Holiday :IEntity
    { public int Id { set; get; }
        public int DateId { set; get; }
        public Date Date { get; set; }
        public string NameIds { get; set; }
        public string HolidayType { get; set; }
        public string Country { get; set; }

    }
}
