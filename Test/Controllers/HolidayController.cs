using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Test.JoinsForApi.Holidays;
using Test.Models;
using Test.Models.HolydayModels;
using Test.Models.UsedUrls;
using Test.QuerryModels;
using Test.SserializationModels.Holiday;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        UsersContext db;
        public HolidayController(UsersContext context)
        {
            db = context;
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }//between       
        public string urlYearCountry (int Year,string Country)
        {
            string url = "https://kayaposoft.com/enrico/json/v2.0/?action=getHolidaysForYear&&year=" +
               Year +
               "&country=" +
               Country +
               "&holidayType=public_holiday";
            return url;
        }
        
        public string deserializeYearCountry(int Year,string Country)
        {
            List<Holiday> holidays = db.holidays.Where(u => u.Country == Country).ToList();
            List<Date> dates = db.dates.Where(u => u.Year == Year).ToList();
            List<Holiday> querries = holidayJoinDate(holidays, dates);
            List<HolidayFinal> holidayFinals = deserializeHolidays(querries);
            string jacsjon = JsonConvert.SerializeObject(holidayFinals);
            return jacsjon;
        }
        [NonAction]
        public List<Holiday> holidayJoinDate(List<Holiday> holidays, List<Date> dates)
        {
             
            List<Holiday> holidayQuerries = new List<Holiday>();
            holidayQuerries = holidays.Join(
                dates,
                u => u.DateId, p => p.Id, (u,p) => 
            new Holiday {
                Id=u.Id,
                Country=u.Country,
                HolidayType=u.HolidayType,
                NameIds=u.NameIds,
               Date=u.Date,
               DateId=u.DateId
            }).ToList();

            return holidayQuerries;
        } 
        [HttpGet("")]
        public ContentResult Doru()
        {
            string p = "Doru";

            return Content(p);
        }
        public int ifRepeatUrl(string url)
        {
            UsedUrl B = new UsedUrl();
            B.Name = url;
            UsedUrl A = db.UsedUrls.FirstOrDefault(p => p.Name == url);
            if (A != null) return 1;

            string json = FromJsonToobject(url);
            if (json.Contains("error")) { return 2; }

            db.UsedUrls.Add(B);
            db.SaveChanges();
            return 3;
        }
        public void AddHolidayBd(List<HolidayD> holidays)
        {
            List<Holiday> holidays1 = new List<Holiday>();
            Name A;
            Holiday obj;
            List<int> ids;
            foreach (HolidayD ob in holidays)
            {
                obj = new Holiday();
                ids = new List<int>();
                A = new Name();
                int k;
                Name B;
                foreach (NameD sd in ob.Name)
                {
                    B = new Name(sd);
                    db.names.Add(B);
                    db.SaveChanges();
                    A = db.names.OrderBy(u => u.Id).Last();
                    k = A.Id;
                    ids.Add(k);
                }

                string v = string.Join(" ", ids);
                obj.NameIds = v;
                obj.Country = ob.Country;
                obj.Date = new Date(ob.Date);
                obj.HolidayType = ob.HolidayType;
                db.holidays.Add(obj);
                db.SaveChanges();
            }
        }//serialization}
        public string FromJsonToobject(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString(url);
            return json;

        }

        public List<HolidayFinal> deserializeHolidays(List<Holiday>deser)
        {

            List<Date> dates = new List<Date>();
            dates = db.dates.ToList();
           
            List<HolidayWithDate> withDates = new List<HolidayWithDate>();
            withDates = deser.Join(dates, k => k.DateId, p => p.Id, (k, p) => new HolidayWithDate
            {
                Id = k.Id,
                HolidayType = k.HolidayType,
                NameIds = k.NameIds,
                Date = p
            }).ToList();
            List<HolidayWithInt> withInts = new List<HolidayWithInt>();
            HolidayWithInt Ap;
            foreach (HolidayWithDate obj in withDates)
            {
                Ap = new HolidayWithInt();
                Ap.Date = obj.Date;
                Ap.Id = obj.Id;
                Ap.HolidayType = obj.HolidayType;
                List<string> vs = obj.NameIds.Split(" ").ToList();
                Ap.NameIds = vs.Select(int.Parse).ToList();
                withInts.Add(Ap);

            }
            List<HolidayFinal> holidayDs = new List<HolidayFinal>();
            HolidayFinal BS;
            List<Name> names4 = db.names.ToList();

            List<Name> names2;
            Name name3;
            foreach (HolidayWithInt obj in withInts)
            {
                BS = new HolidayFinal();
                names2 = new List<Name>();

                foreach (int ob in obj.NameIds)
                {
                    name3 = new Name();
                    name3 = names4.First(u => u.Id == ob);
                    names2.Add(name3);
                }
                BS.Name = names2;
                BS.HolidayType = obj.HolidayType;
                BS.Date = obj.Date;
                holidayDs.Add(BS);
            }
            return holidayDs;
        }

        public void addBDfromUrl (string url,string Country)
        {
            string json = FromJsonToobject(url);// function for read json data from Enrico
            List<HolidayD> holidays1;
            holidays1 = JsonConvert.DeserializeObject<List<HolidayD>>(json);

            foreach (HolidayD obj in holidays1)
            {
                obj.Country = Country;
            }
            AddHolidayBd(holidays1);
        }
       
        public int if_day_holiday_or_free(int Year,int Day,int Month, string Country,List<HolidayQuerry> holidayQuerries)
        {
            HolidayQuerry querry = new HolidayQuerry();
            if (if_day_free(Year, Day, Month)) return 1;
             querry = holidayQuerries.FirstOrDefault(u =>
             (u.Year == Year && u.Month == Month && u.Country == Country && u.Day == Day));
            if (querry!=null)
            return 2;
            return 3;
        }     
        public int number_Of_Free_plus_Holidays(int Year,string Country, List<HolidayQuerry> holidayQuerries)
        { 
            int count = 0;
           
            DateTime time = new DateTime(Year, 1, 1);
            DateTime date = time.AddYears(1);
            
              {
                   while (time.Year < date.Year)
                   {
                      
                        if(if_day_holiday_or_free(Year, time.Day, time.Month, Country, holidayQuerries)==1 || 
                        if_day_holiday_or_free(Year, time.Day, time.Month, Country, holidayQuerries) == 2)
                        {   
                            count++;
                        } 
                       time=time.AddDays(1);
                   }
               } 

            return count;
        }
        public bool if_day_free(int Year,int Day,int  Month)
        {
            DateTime date = new DateTime(Year, Month, Day);
            int day=(int)date.DayOfWeek;
            if (day==6 || day==0)
            return true;
            return false;
        }
        [NonAction]
        public List<HolidayQuerry> transform_Holiday_To_HolidayQuerry(List<Date>dates,List<Holiday> holidays)
        {
            List<HolidayQuerry> holidayQuerries = holidays.Join(
                dates, u => u.DateId, p => p.Id,
                (u, p) => new HolidayQuerry
                {Id=u.Id,Name=u.NameIds,
                    HolidayType=u.HolidayType,Country=u.Country,
                    Day=p.Day,DayOfWeek=p.DayOfWeek,
                    Month=p.Month,Year=p.Year

                }).ToList();


            return holidayQuerries;
        }

        [HttpGet("Year={Year}&Country={Country}")]
        public ContentResult Year(int Year, string Country)
        {
            string url = urlYearCountry(Year, Country);
            string jakson = "Aceasta data nu este suportata de aceast stat";
            int repeat = ifRepeatUrl(url);
            if (repeat == 3)
            {
                addBDfromUrl(url, Country);
            }

            if (repeat == 1 || repeat == 3) jakson = deserializeYearCountry(Year, Country);


            return Content(jakson);
        }

        [HttpGet("action=freeDaysYear&Year={year}&Country={country}")]
        public ContentResult freeDaysYear(int Year, string country)
        {
            string url = urlYearCountry(Year, country);
            string jakson = "Aceasta data nu este suportata de aceast stat";
            int repeat = ifRepeatUrl(url);
            if (repeat == 3)
            {
                addBDfromUrl(url, country);
            }

            if (repeat == 1 || repeat == 3)
            {
                List<Date> dates = db.dates.Where(u => u.Year == Year).ToList();
                List<Holiday> holidays = db.holidays.Where(u => u.Country == country).ToList();
                List<HolidayQuerry> holidayQuerries = transform_Holiday_To_HolidayQuerry(dates, holidays);
                int freeday = number_Of_Free_plus_Holidays(Year, country, holidayQuerries);
                jakson = " " + freeday;
            }



            return Content(jakson);
        }
        [HttpGet("action=isfreeday&Day={day}&Month={month}&Year={year}&Country={country}")]
        public ContentResult is_free_day(int day,int month,int year, string country)
        {
            string jakson;           
            
                List<Date> dates = db.dates.Where(u => u.Year == year&&u.Month==month&&u.Day==day).ToList();
                List<Holiday> holidays = db.holidays.Where(u => u.Country == country).ToList();
                List<HolidayQuerry> holidayQuerries = transform_Holiday_To_HolidayQuerry(dates, holidays);
            int freeday = if_day_holiday_or_free(year,day,month,country,holidayQuerries);

            if (freeday == 1) { jakson = "zi_de_odihna"; }
            else if (freeday == 2) { jakson = "zi_de_sarbatoare"; }
            else jakson = "zi_lucratoare";
            TypeOfDay typeOfDay = new TypeOfDay(jakson);
            
            string json=JsonConvert.SerializeObject(typeOfDay);
            return Content(json);
        }
    }
    }

