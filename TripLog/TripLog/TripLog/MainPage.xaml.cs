using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var items = new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Title = "Home Beakes Road",
                    Notes = "Good",
                    Rating = 3,
                    Date = new DateTime(2018,2,5),
                    Latitude = 52.4819,
                    Longitude = -1.9766
                },
                new TripLogEntry
                {
                    Title = "Dublin",
                    Notes = "The best",
                    Rating = 6,
                    Date = new DateTime(2019,4,20),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new TripLogEntry
                {
                    Title = "Florence",
                    Notes = "Not bad",
                    Rating = 5,
                    Date = new DateTime(2016,6,3),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };

            //trips comes from <ListView x:Name="trips">
            trips.ItemsSource = items;
        }
        //New button of toolbar
        private void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            await Navigation.PushAsync(new DetailPage(trip));

            //Clear selection
            //trips.SelectedItem = null;
        }
    }
}
