using Windows.UI.Xaml.Controls;

namespace App.ViewModels
{
    public class MainPageViewModel : ViewModelBaseClass
    {
        private string _text;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                this._text = value;
                this.OnPropertyChanged(nameof(text));
            }
        }

        private UserControl _currentControl;
        public UserControl currentControl
        {
            get
            {
                return _currentControl;
            }
            // private set?
            set
            {
                this._currentControl = value;
                this.OnPropertyChanged(nameof(currentControl));
            }
        }
    }
}
