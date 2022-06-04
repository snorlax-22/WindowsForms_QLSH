using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_QLSH.Models
{
    class Flower
    {
        //"image": "cm3.jpg",
        //            "color": "Đỏ",
        //            "contents": "Hoa cúc - loài hoa được người ta yêu mến bởi vẻ mộc mạc, giản đơn và biết bao gần gũi. Không chỉ là nét ngây thơ trong sáng của những đóa cúc nhỏ nhắn, trắng xinh; mà còn là niềm vui tươi, rạng rỡ của những đóa cúc đa sắc màu...",
        //            "price": 100000.0,
        //            "created": "17:54:21",
        //            "name": "Trao yêu thương 1",
        //            "discount": 25,
        //            "id": 3,
        //            "category": "Hoa Chúc Mừng",
        //            "updated": null,
        //            "views": 100,
        //            "status": 0

        public string image { get; set; }
        public string color { get; set; }
        public string contents { get; set; }
        public float price { get; set; }
        public DateTime created { get; set; }
        public string name { get; set; }
        public float discount { get; set; }
        public int id { get; set; }
        public string category { get; set; }
        public Nullable<DateTime> updated { get; set; }
        public int views { get; set; }
        public int status { get; set; }


    }
}
