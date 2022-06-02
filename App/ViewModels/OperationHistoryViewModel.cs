using Data;
using Model.Models;
using System;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class OperationHistoryViewModel : ViewModelBaseClass
    {
        private List<Operation> _operations;
        public List<Operation> Operations
        {
            get { return _operations; }
            set { _operations = value; OnPropertyChanged("Operations"); UpdateSumm(); }
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
            UpdateSumm();
        }
        private string _summ { get; set; }
        public string Summ {
            get { return _summ; }
            set
            {
                _summ = value;
                OnPropertyChanged("Summ");
            }
        }
        public void UpdateSumm()
        {
            double _summ = 0;
            foreach (Operation operation in Operations)
            {
                if (operation.Type == OperationType.Income) _summ += operation.Amount;
                else _summ -= operation.Amount;
            }
            Summ =  "Итого на счету: " + _summ.ToString();
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
                    Amount = 3,
                    Category = "Транспорт",
                    Date = DateTimeOffset.Now,
                    Comment = "Комментарий"
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
                UpdateSumm();
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
