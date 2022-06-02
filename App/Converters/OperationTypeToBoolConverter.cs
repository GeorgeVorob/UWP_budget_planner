using Model.Models;
using System;
using Windows.UI.Xaml.Data;

namespace App.Converters
{
    public class OperationTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            return (OperationType)value == OperationType.Income;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            if ((bool)value == true) return OperationType.Income;
            else return OperationType.Outcome;
        }

    }
}
