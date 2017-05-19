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

        //Check all date is always be in right format
        public int Check(string startdate, string enddate)
        {
            if (CheckDate(startdate) != 1)
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

        //Convert date following date culture 
        public DateTime ConvertDate(string date)
        {
            if (date == "" || date == null)
            {
                return DateTime.Now;
            }
            else
            {
                DateTime checkdate = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                return checkdate;
            }
        }
    }

    public class TypeButton
    {
        //Check value of radio button
        //Use for Money Transfer and Customer Reminder Call
        //Use for ArmBorder, ArmpitBorder, Sidecut
        public string CheckRadioButton(string i)
        {
            if (i == "0")
            {
                return "0";
            }
            else if (i == "1")
            {
                return "1";
            }
            else if (i == "2")
            {
                return "2";
            }
            else if (i == "3")
            {
                return "3";
            }
            else if (i == "4")
            {
                return "4";
            }
            else
            {
                return "0";
            }
        }

        //Check value of checkbox button
        public bool CheckboxButton(string i)
        {
            if (i == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Number
    {
        public int CheckSurvey(string i)
        {
            if (i != "Điểm Đánh Giá")
            {
                return int.Parse(i);
            }
            else
            {
                return 0;
            }
        }
    }
}
