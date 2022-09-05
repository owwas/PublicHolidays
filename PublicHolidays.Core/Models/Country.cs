using System;
using System.Collections.Generic;
using System.Text;

namespace PublicHolidays.Core.Models
{
    
    public class Country
    {
        public string countryCode { get; set; }
        public List<string> regions { get; set; }
        public List<string> holidayTypes { get; set; }
        public string fullName { get; set; }
        public FromDate fromDate { get; set; }
        public ToDate toDate { get; set; }
    }

    public class FromDate
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }

    public class ToDate
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}