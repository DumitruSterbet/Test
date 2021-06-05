using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Test.JoinsForApi.Country;
using Test.Models;
using Test.Models.UsedUrls;
using Test.SserializationModels.Country;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        UsersContext db;
        public CountryController(UsersContext context)
        {
            db = context;
           
        }

        [HttpGet]
        public ContentResult Index()
        {
            
            string url = "https://kayaposoft.com/enrico/json/v2.0/?action=getSupportedCountries";
           
            if (!ifRepeatUrl(url))
            {
                string json = FromJsonToobject(url);// function for read json data from Enrico
                List<CountryD> countrys = JsonConvert.DeserializeObject<List<CountryD>>(json);// deserialization of JSON
                AddCountryBd(countrys);// function For Add all countries from Enrico to Bd
            }
           
            List<CountryJoinAllDate> obj2 = joinToSend();//change date from initial model in format what you can serialize
            List<CountryToSend> finalObj = readyForSend(obj2);// change string region and holidaytipes in format array
           
            string jsons = JsonConvert.SerializeObject(finalObj);//serialize object in JSON

            return Content(jsons);
        }

        public bool ifRepeatUrl(string url)
        {

            UsedUrl B = new UsedUrl();
            B.Name = url;


            UsedUrl A = db.UsedUrls.FirstOrDefault(p => p.Name == url);

            if (A != null) return true;

            db.UsedUrls.Add(B);
            db.SaveChanges();
            return false;
        }
        public List<CountryJoinAllDate> joinToSend()
        {
            List<CountryJoinToDate> obj = new List<CountryJoinToDate>();
            List<Country> deserialize = db.Countries.ToList();
            List<ToDate> toDates = db.toDates.ToList();
            List<FromDate> fromDates = db.fromDates.ToList();
            obj = deserialize.Join(
                toDates,
                u => u.ToDateId,
                p => p.Id,
                (u, p) =>
                    new CountryJoinToDate
                    {
                        Id = u.Id,
                        HolidayTypes = u.HolidayTypes,
                        CountryCode = u.CountryCode,
                        FullName = u.FullName,
                        Regions = u.Regions,
                        ToDate = p,
                        FromDateId = u.FromDateId
                    }

                ).ToList();
            List<CountryJoinAllDate> obj2 = new List<CountryJoinAllDate>();
            obj2 = obj.Join(fromDates,
                k => k.FromDateId, p => p.Id, (k, p) => new CountryJoinAllDate
                {
                    Id = k.Id,
                    HolidayTypes = k.HolidayTypes,
                    CountryCode = k.CountryCode,
                    FullName = k.FullName,
                    Regions = k.Regions,
                    ToDate = k.ToDate,
                    FromDate = p
                }).ToList();
            return obj2;

        }
        public List<CountryToSend> readyForSend(List<CountryJoinAllDate> obj2)
        {
            CountryToSend A;
            List<CountryToSend> finalObj = new List<CountryToSend>();

            foreach (CountryJoinAllDate ob in obj2)
            {
                A = new CountryToSend();
                A.Regions = ob.Regions.Split(" ").ToList();
                A.HolidayTypes = ob.HolidayTypes.Split(" ").ToList();
                A.CountryCode = ob.CountryCode;
                A.FromDate = ob.FromDate;
                A.FullName = ob.FullName;
                A.ToDate = ob.ToDate;
                A.Id = ob.Id;
                finalObj.Add(A);

            }
            return finalObj;
        }
        public void AddCountryBd(List<CountryD> obj)
        {

            {
                foreach (CountryD country in obj)
                {
                    string regions = string.Join(" ", country.Regions);
                    string holidaytypes = string.Join(" ", country.HolidayTypes);
                    FromDate fromDate = new FromDate(country);
                    db.fromDates.Add(fromDate);
                    ToDate toDate = new ToDate(country);
                    db.toDates.Add(toDate);
                    string countryCode = country.CountryCode;
                    string fullName = country.FullName;
                    Country country1 = new Country(countryCode, regions, holidaytypes, fullName, fromDate, toDate);
                    db.Countries.Add(country1);

                }
                db.SaveChanges();
            }
        }
        public string FromJsonToobject(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString(url);
            return json;

        }

     

    }
}
