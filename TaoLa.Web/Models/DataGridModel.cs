using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaoLa.Web.Models
{
    public class DataGridModel<T>
    {
        public IEnumerable<T> rows
        {
            get;
            set;
        }

        public int total
        {
            get;
            set;
        }

        public DataGridModel()
        {
        }
    }
}