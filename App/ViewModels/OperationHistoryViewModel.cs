using Data;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App.ViewModels
{
    public class OperationHistoryViewModel : ViewModelBaseClass
    {
        private List<Operation> _operations;
        public List<Operation> Operations
        {
            get { return _operations; }
            set { _operations = value; OnPropertyChanged("Operations"); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }

        public OperationHistoryViewModel(bool initDataRequest = false)
        {
            if (initDataRequest) Operations = DAO.GetOperations();

        }
        public void ResetOperations()
        {
            try
            {
                DAO.ClearOperations();
                DAO.AddOperation(new List<Operation>()
            {
                new Operation()
                {
                    Type = OperationType.Outcome,
                    Amount = 3.1415926,
                    Category = "Транспорт",
                    Date = DateTimeOffset.Now,
                },
                new Operation()
                {
                    Type = OperationType.Income,
                    Amount = 42,
                    Category = "Зарплата",
                    Date = DateTimeOffset.Now,
                },
                new Operation()
                {
                    Type = OperationType.Outcome,
                    Amount = 14,
                    Category = "Еда",
                    Date = DateTimeOffset.Now,
                }
            });
                Operations = DAO.GetOperations();

                Message = "База очищена и заполнена стартовыми данными";
            }
            catch (ArgumentException e)
            {
                Message = "Что-то пошло не так, исключение: " + e.Message;
            }
        }
        public void SendOperations()
        {
            try
            {
                DAO.UpdateOperartion(Operations);
                Message = "Данные сохранены";
                Operations = DAO.GetOperations();
            }
            catch (ArgumentException e)
            {
                Message = "Что-то пошло не так, исключение: " + e.Message;
            }
        }
    }
}
