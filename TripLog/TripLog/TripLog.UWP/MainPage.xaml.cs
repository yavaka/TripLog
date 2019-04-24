using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TripLog.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("joYebvD8BRBH9ktAv0zN~Quiy_bxerPhIb9YCVwu0wA~Ap-CPPkLQz0rb1qTzH07KPJ-d7YCoOKMNQJvrE1S1mySDiM2dNMBaSfUkhfEMgh0");
            LoadApplication(new TripLog.App());
        }
    }
}
