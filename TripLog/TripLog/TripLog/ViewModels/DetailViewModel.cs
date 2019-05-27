using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel(TripLogEntry entry)
        {
            Entry = entry;
        }

        TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

    }
}
