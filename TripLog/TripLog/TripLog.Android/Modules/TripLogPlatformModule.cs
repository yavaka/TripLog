﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ninject.Modules;
using TripLog.Droid.Services;

namespace TripLog.Droid.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<LocationService>()
                .To<LocationService>()
                .InSingletonScope();
        }
    }
}