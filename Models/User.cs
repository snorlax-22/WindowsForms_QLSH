using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_QLSH
{
    class User
    {
        public int id{ get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public Boolean isDeleted { get; set; }
        public string idRole { get; set; }
    }
}
