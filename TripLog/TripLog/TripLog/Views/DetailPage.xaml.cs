using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();


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

            BindingContext = new DetailViewModel(entry);

            //title.Text = entry.Title;
            //date.Text = entry.Date.ToString("M");
            //rating.Text = $"{entry.Rating} star rating";
            //notes.Text = entry.Notes;
        }

        DetailViewModel _detailViewModel
        {
            get { return BindingContext as DetailViewModel; }
        }
    }
}