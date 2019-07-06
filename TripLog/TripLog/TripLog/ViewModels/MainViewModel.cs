using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ITripLogDataService _tripLogDataService;

        public MainViewModel(INavService navService, ITripLogDataService tripLogDataService) : base(navService)
        {
            //Azure Data Access
            _tripLogDataService = tripLogDataService;

            LogEntries = new ObservableCollection<TripLogEntry>();
        }


        ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return _logEntries; }
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
                return _viewCommand ?? (_viewCommand = new Command<TripLogEntry>(async (entry) => await ExecuteViewCommand(entry)));
            }
        }

        Command _newCommand;
        public Command NewCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new Command(async () => await ExecuteNewCommand()));
            }
        }

        Command _refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new Command(async () => await LoadEntries()));
            }
        }

        
        public override async Task Init()
        {
            await LoadEntries();
        }

        async Task LoadEntries()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            LogEntries.Clear();

            try
            {
                //Get entries from azure database
                var entries = await _tripLogDataService.GetEntriesAsync();

                LogEntries = new ObservableCollection<TripLogEntry>(entries);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteViewCommand(TripLogEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
        }

        async Task ExecuteNewCommand()
        {
            await NavService.NavigateTo<NewEntryViewModel>();
        }
    }
}
