using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCACalc.Services;
using PCACalc.Views;

namespace PCACalc
{
    public partial class App : Application
    {

        public App()
        {
            //Register Syncfusion License
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA0NTkwQDMxMzcyZTMxMmUzMEN1Zi9EYlZTZTR3b1V0QkFqUjdNc1NjRDhhWXBWSC9EVGRVZEI1TFhPcjg9;MTA0NTkxQDMxMzcyZTMxMmUzMFY2RlRIKzZ3dy9sMEdwZzdLQWpBZ0h2Z3ZZTEUzYlVEYWFlOHJmY0ZZNUk9;MTA0NTkyQDMxMzcyZTMxMmUzMGJzTFpKblptRXRTKytYT0x4V3dMZE5KWHVtcjI4NkF3U3FKUUNJMTlSZU09;MTA0NTkzQDMxMzcyZTMxMmUzMGNIeEk5ZUFsWUx6TmF4NlZ6aEI5UU1sOXdlMGJZN2VJZTU2UkljR2RtL0E9;MTA0NTk0QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89;MTA0NTk1QDMxMzcyZTMxMmUzMEFLTE9jS2I4cExRU1RLbTB2M3dZUnE1c01qaEhvdXBrTERURlZ5aU51Ync9;MTA0NTk2QDMxMzcyZTMxMmUzMEd3VkdmcHlrY2JQM2d1ZFV6T01OK1hBU2dHWlhQUk0vM2M5WDRpOURpWlE9;MTA0NTk3QDMxMzcyZTMxMmUzME50UForUVNISVgzbnNsaHdlWWRqQzlLRldhKzJBWHNSbW90MDJmdmk4WXc9;MTA0NTk4QDMxMzcyZTMxMmUzMGU1c25VUUpQSHBueXFFekdjSmNqSVJWVjkxYkVORTlWd3pSME1jbE1XanM9;MTA0NTk5QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89");

            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
