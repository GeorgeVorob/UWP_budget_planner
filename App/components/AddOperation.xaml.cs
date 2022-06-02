using App.ViewModels;
using Model.Models;
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

namespace App
{
    public sealed partial class AddOperation : UserControl
    {
        AddOperationViewModel ViewModel;
        public AddOperation()
        {
            InitializeComponent();
            ViewModel = new AddOperationViewModel();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.OpToAdd.Type = OperationType.Income;

            // https://stackoverflow.com/questions/37340758/two-way-binding-editing-passed-value-from-xaml-control-in-the-model-setter-does
            //...why?
            ViewModel.OnPropertyChanged("OpToAdd");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ViewModel.OpToAdd.Type = OperationType.Outcome;
            ViewModel.OnPropertyChanged("OpToAdd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddOperation();
        }
    }
}
