using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_QLSH.Models
{
    class Transaction
    {
        public string customerAddress { get; set; } //Tân Lập,
        public string note { get; set; }
        public float amount { get; set; }
        public int isCanceled { get; set; }
        public DateTime created { get; set; }
        public string message { get; set; }
        public int userID { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public int id { get; set; }
        public Nullable<DateTime> updated { get; set; }
        public int status { get; set; }
    }
}
