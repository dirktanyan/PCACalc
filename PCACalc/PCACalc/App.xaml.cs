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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTE4MTMzQDMxMzcyZTMyMmUzMGgxdnNzbm5qWjhhenVUdUZRY2NGbXlFUjdvYWF4RWhlSWFwcWYvQUxHcGs9;MTE4MTM0QDMxMzcyZTMyMmUzMFI5WFNqRlYvUjd6Yk1hYlBhemY3VXhHckFUZEN3R0lJMHBUQzRhM3RNVmc9;MTE4MTM1QDMxMzcyZTMyMmUzMEVteGV6dThhVHpYcU9MemNMS1lKZ2l2SkVTbWRIaTUvM2lPYkVRaXdNS0k9;MTE4MTM2QDMxMzcyZTMyMmUzMG9pVWZwK3ordms2V0FzUDJyNVZBck1yNmsrSld1VGFLZERuVlBua2dFcU09;MTE4MTM3QDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9;MTE4MTM4QDMxMzcyZTMyMmUzMFNwQmE4a0VLa09idktyUnJVR3ZrU1hweTVpODR2dlQrK3BzN3h1enlSaU09;MTE4MTM5QDMxMzcyZTMyMmUzMENIYzJsdHFVdjE1QXhXQVA1ZVArTmNxWkZ6bUVHSmphMUlreGVZTFJmTG89;MTE4MTQwQDMxMzcyZTMyMmUzMFJaY0lqdDhoV1RObHFvZVhBRXBlQ2xSdHdGWnZPSmNZMS95UndvOHRuUjA9;MTE4MTQxQDMxMzcyZTMyMmUzMGh3Qi9mV3k1NUcxMFg1bjEyZ1hJQm8zQ0VZczRyMm9EQm9EdklvNDJrSm89;MTE4MTQyQDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9");

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
