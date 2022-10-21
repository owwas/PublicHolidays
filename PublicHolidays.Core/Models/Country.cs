using System;
using System.Collections.Generic;
using System.Text;

namespace PublicHolidays.Core.Models
{

    public class Country
    {
        public string CountryCode { get; set; }
        public List<string> Regions { get; set; }
        public List<string> HolidayTypes { get; set; }
        public string FullName { get; set; }
        public FromDate FromDate { get; set; }
        public ToDate ToDate { get; set; }
    }

    public class FromDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class ToDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}