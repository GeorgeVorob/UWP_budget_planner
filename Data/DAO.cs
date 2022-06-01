using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DAO
    {
        public static int calls = 0;
        public static string GetData()
        {
            calls++;
            return "Hello world, calls: " + calls.ToString();
        }
    }
}
