using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PublicHolidays.Core.Models
{
    public class Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int dayOfWeek { get; set; }
    }

    public class Name
    {
        public string lang { get; set; }
        public string text { get; set; }
    }

    public class Holiday
    {
        public Date date { get; set; }
        public List<Name> name { get; set; }
        public string holidayType { get; set; }
    }


}