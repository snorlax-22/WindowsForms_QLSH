using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_QLSH.APIs;
using WindowsForms_QLSH.Models;

namespace WindowsForms_QLSH.Forms
{
    public partial class FormBill : Form
    {
        public FormBill(JToken listflowerjson)
        {
            InitializeComponent();
            
            GetAPIs getAPIs = new GetAPIs();
            


            IList<Flower> flowers;
            Size size = new Size(200, 200);

            try
            {
                //var listflowerjson = getAPIs.GetAllFlower()["responseData"]["data"];
                flowers = listflowerjson.ToObject<IList<Flower>>();

                //there are many flowers in the list with the same name, so we need to remove duplicate
                var listflower = flowers.GroupBy(x => x.name).Select(y => y.First()).ToList();

                foreach (var item in listflower)
                {

                    ShopItem uc = new ShopItem(item.name, item.price)
                    {
                        ForeColor = Color.Black,
                        Size = size,

                    };

                    uc.MouseDown += (sender, e) => { uc.BorderStyle = BorderStyle.FixedSingle; };
                    uc.MouseUp += (sender, e) => { uc.BorderStyle = BorderStyle.None; };
                    flowLayoutPanel1.Controls.Add(uc);


                }
                flowLayoutPanel1.AutoScroll = true;

            }
            catch (Exception objex)
            {
                string strerrormessage = "lỗi gọi api";
                string strerrormessagedetail = objex.ToString();
                MessageBox.Show(strerrormessagedetail, strerrormessage);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String title = "Phiếu tạm";
            TabPage bill = new TabPage(title);
            tabControl1.TabPages.Add(bill);
        }
    }
}
