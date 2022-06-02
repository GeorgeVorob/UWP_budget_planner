using Data;
using Model.Models;
using System;

namespace App.ViewModels
{
    public class AddOperationViewModel : ViewModelBaseClass
    {
        private Operation _opToAdd { get; set; }
        public Operation OpToAdd
        {
            get { return _opToAdd; }
            set { _opToAdd = value; OnPropertyChanged("OpToAdd"); }
        }

        private string _message { get; set; }
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }

        public AddOperationViewModel()
        {
            OpToAdd = new Operation();
            OpToAdd.Type = OperationType.Outcome;
            OpToAdd.Date = DateTimeOffset.Now;
        }
        public void AddOperation()
        {
            try
            {
                DAO.AddOperation(OpToAdd);
                Message = "Запись добавлена";
                OpToAdd = new Operation();
                OpToAdd.Date = DateTimeOffset.Now;
            }
            catch (ArgumentException e)
            {
                Message = "Что-то пошло не так, исключение: " + e.Message;
            }
        }
    }
}
