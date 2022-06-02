using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public enum OperationType { Income, Outcome }
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public OperationType Type { get; set; }
        [Required]
        public double Amount { get; set; }
        // решил сделать категорию строковой для простоты
        // стоило-ли делать вторую таблицу и навигационное поле?
        [Required]
        public string Category { get; set; }
        public string Comment { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        public bool IsValid()
        {
            if (!Enum.IsDefined(typeof(OperationType),Type)) return false;
            if (Amount <= 0) return false;
            DateTimeOffset defaultDate = new DateTimeOffset();
            if (Date == defaultDate) return false;

            return true;
        }
    }
}
