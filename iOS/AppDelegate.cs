﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Syncfusion.SfGauge.XForms.iOS;
using UIKit;

namespace FindMe.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            ImageCircleRenderer.Init();
            new SfLinearGaugeRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

