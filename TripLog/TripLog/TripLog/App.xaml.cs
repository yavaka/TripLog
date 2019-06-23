using Ninject;
using Ninject.Modules;
using System;
using TripLog.Modules;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    public partial class App : Application
    {
        public App(params INinjectModule[] platformModules)
        {
            //Create new instance of the navigation service
            var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            //Register core services
            Kernel = new StandardKernel(
                new TripLogCoreModule(),
                new TripLogNavModule(mainPage.Navigation));

            //Register platform specific services
            Kernel.Load(platformModules);

            //Get the MainViewModel from the IoC container
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

            MainPage = mainPage;
        }

        public IKernel Kernel{ get; set; }

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
