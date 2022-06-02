using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BudgetContext : DbContext
    {
        public string ConnStr;
        public BudgetContext(DbContextOptions options) : base(options) { }
        public BudgetContext(string connStr) : base()
        {
            ConnStr = connStr;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnStr);
        }

        public DbSet<Operation> operations { get; set; }
    }
}
