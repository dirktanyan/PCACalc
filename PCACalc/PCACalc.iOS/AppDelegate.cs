using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace PCACalc.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            //Register Syncfusion License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA0NTkwQDMxMzcyZTMxMmUzMEN1Zi9EYlZTZTR3b1V0QkFqUjdNc1NjRDhhWXBWSC9EVGRVZEI1TFhPcjg9;MTA0NTkxQDMxMzcyZTMxMmUzMFY2RlRIKzZ3dy9sMEdwZzdLQWpBZ0h2Z3ZZTEUzYlVEYWFlOHJmY0ZZNUk9;MTA0NTkyQDMxMzcyZTMxMmUzMGJzTFpKblptRXRTKytYT0x4V3dMZE5KWHVtcjI4NkF3U3FKUUNJMTlSZU09;MTA0NTkzQDMxMzcyZTMxMmUzMGNIeEk5ZUFsWUx6TmF4NlZ6aEI5UU1sOXdlMGJZN2VJZTU2UkljR2RtL0E9;MTA0NTk0QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89;MTA0NTk1QDMxMzcyZTMxMmUzMEFLTE9jS2I4cExRU1RLbTB2M3dZUnE1c01qaEhvdXBrTERURlZ5aU51Ync9;MTA0NTk2QDMxMzcyZTMxMmUzMEd3VkdmcHlrY2JQM2d1ZFV6T01OK1hBU2dHWlhQUk0vM2M5WDRpOURpWlE9;MTA0NTk3QDMxMzcyZTMxMmUzME50UForUVNISVgzbnNsaHdlWWRqQzlLRldhKzJBWHNSbW90MDJmdmk4WXc9;MTA0NTk4QDMxMzcyZTMxMmUzMGU1c25VUUpQSHBueXFFekdjSmNqSVJWVjkxYkVORTlWd3pSME1jbE1XanM9;MTA0NTk5QDMxMzcyZTMxMmUzMG9aTVVpR21pRHpwVnlqNnR1WmdvRkE3VHZpN3JyVXNTZTc5MFhjTVhYRm89");

            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
