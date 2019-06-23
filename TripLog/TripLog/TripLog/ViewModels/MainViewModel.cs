using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavService navService)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
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


        Command<TripLogEntry> _viewCommand;
        public Command<TripLogEntry> ViewCommand
        {
            get
            {
                return _viewCommand
                    ?? (_viewCommand = new Command<TripLogEntry>(async (entry) => 
                    await ExecuteViewCommand(entry)));
            }
        }
        Command _newCommand;
        public Command NewCommand
        {
            get
            {
                return _newCommand
                    ?? (_newCommand = new Command(async () =>
                    await ExecuteNewCommand()));

            }
        }
        private async Task ExecuteNewCommand()
        {
            await NavService.NavigateTo<NewEntryViewModel>();
        }
        private async Task ExecuteViewCommand(TripLogEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
        }


        public override async Task Init()
        {
            await LoadEntries();
        }

        private async Task LoadEntries()
        {
            LogEntries.Clear();

            await Task.Factory.StartNew(() =>
            {
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
            });
        }
    }
}
