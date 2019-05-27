using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LogEntries = new ObservableCollection<TripLogEntry>();

            LogEntries.Add(new TripLogEntry
            {
                Title = "Home Beakes Road",
                Notes = "Good",
                Rating = 3,
                Date = new DateTime(2018, 2, 5),
                Latitude = 52.4819,
                Longitude = -1.9766
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Birmingham",
                Notes = "Not Bad",
                Rating = 4,
                Date = new DateTime(2019, 2, 5),
                Latitude = 52.4819,
                Longitude = -1.9766
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Somewhere",
                Notes = "The best",
                Rating = 3,
                Date = new DateTime(2017, 2, 5),
                Latitude = 52.4819,
                Longitude = -1.9766
            });
        }

        ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get
            {
                return _logEntries;
            }
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }
    }
}
