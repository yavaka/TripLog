using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();

            //Set region
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(entry.Latitude, entry.Longitude)
                ,Distance.FromMiles(.5)));

            //Create new pin
            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = entry.Title,
                Position = new Position(entry.Latitude,entry.Longitude)
            };
            map.Pins.Add(pin);

            title.Text = entry.Title;
            date.Text = entry.Date.ToString("M");
            rating.Text = $"{entry.Rating} star rating";
            notes.Text = entry.Notes;
        }
    }
}