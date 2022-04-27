using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinDayOfYear
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(XamarinDayOfYear.Views.DayOfYear), typeof(XamarinDayOfYear.Views.DayOfYear));

            
        }

    }
}
