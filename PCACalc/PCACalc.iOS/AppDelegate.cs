using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.XForms.iOS.TextInputLayout;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTE4MTMzQDMxMzcyZTMyMmUzMGgxdnNzbm5qWjhhenVUdUZRY2NGbXlFUjdvYWF4RWhlSWFwcWYvQUxHcGs9;MTE4MTM0QDMxMzcyZTMyMmUzMFI5WFNqRlYvUjd6Yk1hYlBhemY3VXhHckFUZEN3R0lJMHBUQzRhM3RNVmc9;MTE4MTM1QDMxMzcyZTMyMmUzMEVteGV6dThhVHpYcU9MemNMS1lKZ2l2SkVTbWRIaTUvM2lPYkVRaXdNS0k9;MTE4MTM2QDMxMzcyZTMyMmUzMG9pVWZwK3ordms2V0FzUDJyNVZBck1yNmsrSld1VGFLZERuVlBua2dFcU09;MTE4MTM3QDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9;MTE4MTM4QDMxMzcyZTMyMmUzMFNwQmE4a0VLa09idktyUnJVR3ZrU1hweTVpODR2dlQrK3BzN3h1enlSaU09;MTE4MTM5QDMxMzcyZTMyMmUzMENIYzJsdHFVdjE1QXhXQVA1ZVArTmNxWkZ6bUVHSmphMUlreGVZTFJmTG89;MTE4MTQwQDMxMzcyZTMyMmUzMFJaY0lqdDhoV1RObHFvZVhBRXBlQ2xSdHdGWnZPSmNZMS95UndvOHRuUjA9;MTE4MTQxQDMxMzcyZTMyMmUzMGh3Qi9mV3k1NUcxMFg1bjEyZ1hJQm8zQ0VZczRyMm9EQm9EdklvNDJrSm89;MTE4MTQyQDMxMzcyZTMyMmUzMFJ4eW0wNmhLRGlLTVlUMkNEd1RXZnNYRGI5aUgvbDRlL0hzN25pQUNVcHc9");

            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();

            SfTextInputLayoutRenderer.Init();
            new SfNumericTextBoxRenderer();
            
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
