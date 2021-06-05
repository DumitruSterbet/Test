using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Interfaces;

namespace Test.Models
{
    public class Country : IEntity
    { public int Id { set; get; }
        public string CountryCode { set; get; }
        
        public string Regions { set; get; }
       
        public string HolidayTypes { set; get; }
        public string FullName { get; set; }
       public int FromDateId { get; set; }
        public FromDate FromDate { get; set; }
       
      public int ToDateId { get; set; }
        public ToDate ToDate { get; set; }

        public Country (string countryCode,string regions,string holidaytypes,string fullname,FromDate from,ToDate toDate)
        {
            this.CountryCode = countryCode;
            this.FullName = fullname;
            this.Regions = regions;
            this.HolidayTypes = holidaytypes;
            this.FromDate = from;
            this.ToDate = toDate;

        }
        public Country() { }
       
    }
}
