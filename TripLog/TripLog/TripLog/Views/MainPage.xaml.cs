using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }

        //Call Init method when page first appears
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Initialize MainViewModel
            if (_vm != null)
            {
                await _vm.Init();
            }
        }

        private MainViewModel _vm
        {
            get
            {
                return BindingContext as MainViewModel;
            }
        }

        //New button of toolbar
        private void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        private void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;

            _vm.ViewCommand.Execute(trip);

            trips.SelectedItem = null;
        }
    }
}
