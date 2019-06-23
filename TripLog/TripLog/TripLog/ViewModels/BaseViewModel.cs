using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TripLog.Services;

namespace TripLog.ViewModels
{
    //Abstract class which contain basic functionality
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected INavService NavService { get; private set; }
        protected BaseViewModel(INavService navService)
        {
            NavService = navService;
        }

        public abstract Task Init();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //Second abstract class with generic type to pass strongly typed parameters to Init method
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navService) : base(navService)
        {

        }

        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }
}
