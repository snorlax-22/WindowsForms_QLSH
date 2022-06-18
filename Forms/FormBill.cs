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
            //form POS (Tính tiền sản phẩm cho khách)
            InitializeComponent();
            button1.Enabled = false;
            button1.Visible = false;

            float totalBill = 0;
            GetAPIs getAPIs = new GetAPIs();
            List<Flower> listFlowerbill = new List<Flower>();
            

            FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
            IList<Flower> flowers;
            Size size = new Size(200, 200);
            
            Label textBoxTotal = new Label();
            textBoxTotal.Location = new Point(280, 0);
            tabControl1.SelectedTab.Controls.Add(textBoxTotal);
            flowLayoutPanel2.AutoSize = true;

            try
            {
                //lấy List hoa từ API trả về
                flowers = listflowerjson.ToObject<IList<Flower>>();

                //lọc các hoa có trùng tên
                var listflower = flowers.GroupBy(x => x.name).Select(y => y.First()).ToList();
               
                
                //tạo các ô hoa riêng biệt
                foreach (var item in listflower)
                {

                    ShopItem uc = new ShopItem(item.name, item.price, item.image)
                    {
                        ForeColor = Color.Black,
                        Size = size,

                    };
                    
                    //set event cho UserControl hoa (Ô hoa)
                    uc.MouseDown += (sender, e) =>
                    {
                        totalBill = totalBill + item.price;
  
                        textBoxTotal.Text = "Tổng cộng: "+ totalBill.ToString();

                        //Mỗi lần click sẽ tạo ra 2 label có Text là tên hoa + giá tiền
                        flowLayoutPanel2.Controls.Add(AddNewLabel(item.name));
                        flowLayoutPanel2.Controls.Add(AddNewLabel(item.price.ToString()));
                        textBoxTotal.AutoSize = true;
                        textBoxTotal.Update();
                        
                        tabControl1.SelectedTab.Controls.Add(flowLayoutPanel2);

                        
                    };
                    uc.MouseUp += (sender, e) => { uc.BorderStyle = BorderStyle.None; };

                    flowLayoutPanel1.Controls.Add(uc);
                }
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                

                flowLayoutPanel1.AutoScroll = true;

            }
            catch (Exception objex)
            {
                string strerrormessage = "lỗi gọi api";
                string strerrormessagedetail = objex.ToString();
                MessageBox.Show(strerrormessagedetail, strerrormessage);
            }
        }

        public static Label AddNewLabel(string txt)
        {
            Label lbl = new Label(); //Khởi tạo đối tượng Textbox có tên là txt
            lbl.Text = txt;
            return lbl; //Trả lại đối tượng txt với các thuộc tính kèm theo
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

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
    
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }
    }
}
