using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Net;
using System.Globalization;
using System.IO;

namespace WindowsForms_QLSH
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ShopItem : UserControl
    {
        public ShopItem(string name, float price)
        {
            InitializeComponent();
            label1.Text = name;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string priceformatted = price.ToString("#,###", cul.NumberFormat);
            label2.Text = priceformatted + "₫";

            //load url của google
            //pictureBox1.Load("https://file1.dangcongsan.vn/DATA/0/2018/10/68___gi%E1%BA%BFng_l%C3%A0ng_qu%E1%BA%A3ng_ph%C3%BA_c%E1%BA%A7u__%E1%BB%A9ng_h%C3%B2a___%E1%BA%A3nh_vi%E1%BA%BFt_m%E1%BA%A1nh-16_51_07_908.jpg");
            //load url github
            //pictureBox1.Load("https://fv9-3.failiem.lv/thumb_show.php?i=qwzgb77yr&view");
            //load url của Dại
            //pictureBox1.Load("https://raw.githubusercontent.com/dhmty/FLOWERSHOP_DND/main/WebContent/resources/images/flower/211204011549-ty2.jpg");
            
            //byte[] imageBytes = Convert.FromBase64String(pic);
            //// Convert byte[] to Image
            //using (var ms = new MemoryStream(imageBytes))
            //{
            //    pictureBox1.Image = Image.FromStream(ms, true);
            //}

            

            

            pictureBox1.Tag = Color.Pink;



            //if shopitem is clicked, it will changed the background color to pink

            label1.MouseHover += (sender, e) =>{this.BackColor = Color.Pink;};
            label2.MouseHover += (sender, e) => { this.BackColor = Color.Pink; };
            pictureBox1.MouseHover += (sender, e) => { this.BackColor = Color.Pink; };


            //on mouse left , it will change the background color to white

            label1.MouseLeave += (sender, e) => { this.BackColor = Color.White; };
            label2.MouseLeave += (sender, e) => { this.BackColor = Color.White; };
            pictureBox1.MouseLeave += (sender, e) => { this.BackColor = Color.White; };


        }

        public ShopItem()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
