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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTE4MTMzQDMxMzcyZTMyMmUzMGgxdnNzbm5qWjhhenVUdUZRY2NGbXlFUjdvYWF4RWhlSWFwcWYvQUxHcGs9;MTE4MTM0QDMxMzcyZTMyMmUzMFI5WFNqRlYvUjd6Yk1hYlBhemY3VXhHckFUZEN3R0lJMHBUQzRhM3RNVmc9;MTE4MTM1QDMxMzcyZTMyMmUzMEVteGV6dThhVHpYcU9MemNMS1lKZ2l2SkVTbWRIaTUvM2lPYkVRaXdNS0k9;MTE4MTM2QDMxMzcyZTMyMmUzMG9pVWZwK3ordms2V0FzUDJyNVZBck1yNmsrSld1VGFLZERuVlBua2dFcU09;MTE4MTM3QDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9;MTE4MTM4QDMxMzcyZTMyMmUzMFNwQmE4a0VLa09idktyUnJVR3ZrU1hweTVpODR2dlQrK3BzN3h1enlSaU09;MTE4MTM5QDMxMzcyZTMyMmUzMENIYzJsdHFVdjE1QXhXQVA1ZVArTmNxWkZ6bUVHSmphMUlreGVZTFJmTG89;MTE4MTQwQDMxMzcyZTMyMmUzMFJaY0lqdDhoV1RObHFvZVhBRXBlQ2xSdHdGWnZPSmNZMS95UndvOHRuUjA9;MTE4MTQxQDMxMzcyZTMyMmUzMGh3Qi9mV3k1NUcxMFg1bjEyZ1hJQm8zQ0VZczRyMm9EQm9EdklvNDJrSm89;MTE4MTQyQDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9");

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