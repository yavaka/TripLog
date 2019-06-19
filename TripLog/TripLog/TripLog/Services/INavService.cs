using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;

namespace TripLog.Services
{
    //Navigation API Interface
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
        //Restricts its use to objects of the BaseViewModel
        Task NavigateTo<TVM>()
            where TVM : BaseViewModel;
        Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel;
        Task RemoveLastView();
        Task ClearBackStack();
        Task NavigateToUri(Uri uri);

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
