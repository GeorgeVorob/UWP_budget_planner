using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.ViewModels
{
    public abstract class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
