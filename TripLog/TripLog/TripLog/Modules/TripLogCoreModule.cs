using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        private const string URL = "https://triplogapplication.azurewebsites.net";
        
        public override void Load()
        {
            //ViewModels
            Bind<MainViewModel>()
                .ToSelf();
            Bind<DetailViewModel>()
                .ToSelf();
            Bind<NewEntryViewModel>()
                .ToSelf(); 

            //Core services
            //Azure Data Access
            var tripLogService = new TripLogApiDataService(new Uri(URL));
            Bind<ITripLogDataService>()
                .ToMethod(x => tripLogService)
                .InSingletonScope();

        }
    }
}
