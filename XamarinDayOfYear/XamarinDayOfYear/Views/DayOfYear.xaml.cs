using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDayOfYear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayOfYear : ContentPage
    {
        public DayOfYear()
        {
            InitializeComponent();
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (CurrentDate.Text == "")
                UseCurrentDateCheckBox.IsChecked = true;

            if (UseCurrentDateCheckBox.IsChecked == true)
            {
                ResultDayOfWeek.Text = GetDayOfWeek() + " Is Day Of Week";
                ResultDayOfYear.Text = GetDayOfYear() + " Is Day Of Year";
                ResultWeekNumber.Text = GetWeekNumber().ToString() + " Is Week Number";
                ResultDaysLeftInYear.Text = GetDaysLeftInYear().ToString() + " Days Left in Year";
            }
            else
            {
                DateTime currentDateTime = DateTime.Parse(CurrentDate.Text);
                ResultDayOfWeek.Text = GetDayOfWeek(currentDateTime).ToString() + " Is Day Of Week";
                ResultDayOfYear.Text = GetDayOfYear(currentDateTime).ToString() + " Is Day Of Year";
                ResultWeekNumber.Text = GetWeekNumber(currentDateTime).ToString() + "  Is Week Number";
                ResultDaysLeftInYear.Text = GetDaysLeftInYear(currentDateTime).ToString() + " Days Left In Year";
            }
            

        }

        private string GetDayOfWeek(DateTime prevdate = default(DateTime))
        {
            string dt = null;
            if (prevdate == default(DateTime))
                dt = DateTime.Now.DayOfWeek.ToString();
            else
            {
                dt = prevdate.DayOfWeek.ToString();
            }
            return dt;
        }

        private string GetDayOfYear(DateTime prevdate = default(DateTime))
        {
            int dayOfYear = 0;
            if (prevdate == default(DateTime))
            {
                prevdate = DateTime.Now;
                dayOfYear = prevdate.DayOfYear;
            }
               
            else
                dayOfYear = prevdate.DayOfYear;
            return dayOfYear.ToString();
        }

        private int GetWeekNumber(DateTime prevdate = default(DateTime))
        {
            if (prevdate == default(DateTime))
            {
                prevdate = DateTime.Now;
            }
            else
            {
            }
            var myCI = CultureInfo.CreateSpecificCulture("en-US");
            var myCal = myCI.Calendar;
            var myCWR = CalendarWeekRule.FirstFullWeek;
            var myFirstDOW = DayOfWeek.Sunday;
            var WeekNumber = myCal.GetWeekOfYear(prevdate, myCWR, myFirstDOW);
            return WeekNumber;
        }

        private int GetDaysLeftInYear(DateTime prevdate = default(DateTime))
        {
              if (prevdate == default(DateTime))
            {
                prevdate = DateTime.Now;
            }
              else
            {

            }
            int daysleft = 365 - int.Parse(GetDayOfYear(prevdate));
            return daysleft;
        }
    }
}