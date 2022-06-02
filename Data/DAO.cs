using Microsoft.EntityFrameworkCore;
using Model;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Data
{
    // Стоит-ли вообще делать слой доступа к данным при Entity Framework?
    // Хотел в каком-то виде придумать слой бизнес-логики, но не нашел повода его вставлять сюда
    public static class DAO // Data Access Object
    {
        private static BudgetContext GetDb()
        {
            string dbPath = "Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "myDatabaseName.db");
            var context = new BudgetContext(dbPath);
            if (context.Database.EnsureCreated())
            {
                context.Database.Migrate();
            }
            return context;
        }

        public static List<Operation> GetOperations()
        {
            List<Operation> operations = new List<Operation>();
            using (var db = GetDb())
            {
                operations = db.operations.ToList();
            }
            return operations;
        }

        public static void AddOperation(Operation data)
        {
            if (!data.IsValid()) throw new ArgumentException("Operation object is invalid.");
            using (var db = GetDb())
            {
                db.operations.Add(data);
                db.SaveChanges();
            }
        }

        public static void AddOperation(IEnumerable<Operation> data)
        {
            using (var db = GetDb())
            {
                int i = 0;
                foreach (var op in data)
                {
                    if (!op.IsValid()) throw new ArgumentException("Operation object is invalid. Index: " + i);
                    db.operations.Add(op);
                    i++;
                }
                db.SaveChanges();
            }
        }

        public static void ClearOperations()
        {
            using (var db = GetDb())
            {
                // пишут что это очень плохо работает для больших таблиц, но пойдет
                db.operations.RemoveRange(db.operations);
                db.SaveChanges();
            }
        }

        public static void UpdateOperartion(Operation data)
        {
            if (!data.IsValid() || data.Id <= 0) throw new ArgumentException("Operation object is invalid.");

            using (var db = GetDb())
            {
                Operation opToUpdate = db.operations.Single(op => op.Id == data.Id);
                opToUpdate.Type = data.Type;
                opToUpdate.Amount = data.Amount;
                opToUpdate.Category = data.Category;
                opToUpdate.Comment = data.Comment;
                opToUpdate.Date = data.Date;
                db.SaveChanges();
            }
        }

        public static void UpdateOperartion(IEnumerable<Operation> data)
        {
            using (var db = GetDb())
            {
                foreach (var op in data)
                {
                    if (!op.IsValid() || op.Id <= 0) throw new ArgumentException("Operation object is invalid.");

                    Operation opToUpdate = db.operations.Single(_op => _op.Id == op.Id);
                    opToUpdate.Type = op.Type;
                    opToUpdate.Amount = op.Amount;
                    opToUpdate.Category = op.Category;
                    opToUpdate.Comment = op.Comment;
                    opToUpdate.Date = op.Date;
                }
                db.SaveChanges();
            }
        }
    }
}
