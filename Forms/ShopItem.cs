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
        public ShopItem(string name, float price, string base64String)
        {
            InitializeComponent();
            label1.Text = name;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string priceformatted = price.ToString("#,###", cul.NumberFormat);
            label2.Text = priceformatted + "₫";

            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                pictureBox1.Image = Image.FromStream(ms, true);
            }
           
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
