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
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();

            BindingContext = new DetailViewModel(DependencyService.Get<INavService>());
        }

        DetailViewModel _detailViewModel
        {
            get { return BindingContext as DetailViewModel; }
        }

        private void UpdateMap()
        {
            if (_detailViewModel.Entry == null)
            {
                return;
            }

            //Set region
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(_detailViewModel.Entry.Latitude, _detailViewModel.Entry.Longitude)
                , Distance.FromMiles(.5)));

            //Create new pin
            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = _detailViewModel.Entry.Title,
                Position = new Position(_detailViewModel.Entry.Latitude, _detailViewModel.Entry.Longitude)
            };
            map.Pins.Add(pin);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(DetailViewModel.Entry))
            {
                UpdateMap();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_detailViewModel != null)
            {
                _detailViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (_detailViewModel != null)
            {
                _detailViewModel.PropertyChanged -= OnViewModelPropertyChanged;
            }
        }
    }
}