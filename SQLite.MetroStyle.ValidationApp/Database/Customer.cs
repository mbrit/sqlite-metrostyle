using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.MetroStyle.ValidationApp
{
    public class Customer
    {
        [AutoIncrement, PrimaryKey]
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
