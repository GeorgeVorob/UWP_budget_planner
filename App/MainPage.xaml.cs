using System;
using Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using App.ViewModels;
using Windows.UI.ViewManagement;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace App
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainPageViewModel();
            ApplicationView.PreferredLaunchViewSize = new Size(900, 900);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        // По требованию задания страница должна быть одна, поэтому смену содержимого сделал через ContentControl
        // TODO: вынести сопоставление пунктов меню и UserControlов в список
        private void navigationHandler(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            switch (args.SelectedItemContainer.Name)
            {
                case "History":
                    ViewModel.currentControl = new OperationsHistory();
                    break;
                case "Add":
                    ViewModel.currentControl = new AddOperation();
                    break;
            }
        }
    }
}
