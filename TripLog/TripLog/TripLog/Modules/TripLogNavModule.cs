﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.Modules
{
    public class TripLogNavModule : NinjectModule
    {
        //xf = XamarinForm
        readonly INavigation _xfNav;
        public TripLogNavModule(INavigation xamarinFormNavigation)
        {
            _xfNav = xamarinFormNavigation;
        }

        public override void Load()
        {
            var navService = new XamarinFormsNavService();
            navService.XamarinFormsNav = _xfNav;

            //Register view mappings
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

            Bind<INavService>()
                .ToMethod(x => navService)
                .InSingletonScope();
        }
    }
}
