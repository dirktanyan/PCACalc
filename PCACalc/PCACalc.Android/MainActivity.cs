using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PCACalc.Droid
{
    [Activity(Label = "PCACalc", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Register Syncfusion License
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA0NTkwQDMxMzcyZTMxMmUzMEN1Zi9EYlZTZTR3b1V0QkFqUjdNc1NjRDhhWXBWSC9EVGRVZEI1TFhPcjg9;MTA0NTkxQDMxMzcyZTMxMmUzMFY2RlRIKzZ3dy9sMEdwZzdLQWpBZ0h2Z3ZZTEUzYlVEYWFlOHJmY0ZZNUk9;MTA0NTkyQDMxMzcyZTMxMmUzMGJzTFpKblptRXRTKytYT0x4V3dMZE5KWHVtcjI4NkF3U3FKUUNJMTlSZU09;MTA0NTkzQDMxMzcyZTMxMmUzMGNIeEk5ZUFsWUx6TmF4NlZ6aEI5UU1sOXdlMGJZN2VJZTU2UkljR2RtL0E9;MTA0NTk0QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89;MTA0NTk1QDMxMzcyZTMxMmUzMEFLTE9jS2I4cExRU1RLbTB2M3dZUnE1c01qaEhvdXBrTERURlZ5aU51Ync9;MTA0NTk2QDMxMzcyZTMxMmUzMEd3VkdmcHlrY2JQM2d1ZFV6T01OK1hBU2dHWlhQUk0vM2M5WDRpOURpWlE9;MTA0NTk3QDMxMzcyZTMxMmUzME50UForUVNISVgzbnNsaHdlWWRqQzlLRldhKzJBWHNSbW90MDJmdmk4WXc9;MTA0NTk4QDMxMzcyZTMxMmUzMGU1c25VUUpQSHBueXFFekdjSmNqSVJWVjkxYkVORTlWd3pSME1jbE1XanM9;MTA0NTk5QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89");

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}