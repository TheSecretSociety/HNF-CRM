using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HNFCRM_Chat.Validate
{
    public class Validation
    {
        //DateTime Culture
        IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

        //Check datetime format
        public int CheckDate(string date)
        {
            try
            {
                DateTime checkdate = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //Check end date always behind start date
        public int CheckDuration(string startdate, string enddate)
        {
            try
            {
                DateTime start = DateTime.Parse(startdate, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                DateTime end = DateTime.Parse(enddate, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                if (start > end)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Check(string startdate, string enddate)
        {
            if(CheckDate(startdate)!= 1)
            {
                return 0;
            }
            else if (CheckDate(enddate) != 1)
            {
                return 0;
            }
            else if (CheckDuration(startdate, enddate) != 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public DateTime ConvertDate(string date)
        {
            if (date == "" || date == null)
            {
                return DateTime.Now;
            }
            DateTime checkdate = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            return checkdate;
        }
    }
}
