using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class OperationHistoryViewModel : ViewModelBaseClass
    {
        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                this.OnPropertyChanged(nameof(text));
            }
        }
    }
}
