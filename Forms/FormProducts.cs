using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_QLSH.APIs;
using WindowsForms_QLSH.Models;

namespace WindowsForms_QLSH
{
    public partial class FormProducts : Form
    {
        IList<Flower> flowers;
        IList<Category> category;
        IList<Models.Color> colors;
        Size size = new Size(200, 200);
        string base64String = "";
        PostAPIs postAPIs = new PostAPIs();
        GetAPIs getAPIs = new GetAPIs();
        public FormProducts(JToken listflowerjson)
        {
            GetAPIs getAPIs = new GetAPIs();
            InitializeComponent();


            
            
            try
            {
                var listcolorjson = getAPIs.GetAllColor()["responseData"]["data"];
                var listcategoryjson = getAPIs.GetAllCategory()["responseData"]["data"];
                
                //var listflowerjson = getAPIs.GetAllFlower()["responseData"]["data"];
                flowers = listflowerjson.ToObject<IList<Flower>>();
                category = listcategoryjson.ToObject<IList<Category>>();
                colors = listcolorjson.ToObject<IList<Models.Color>>();
                //there are many flowers in the list with the same name, so we need to remove duplicate
                var listflower = flowers.GroupBy(x => x.name).Select(y => y.First()).ToList();

                foreach (var item in listflower)
                {
                    ShopItem uc = new ShopItem(item.name,item.price,item.image)
                    {
                        ForeColor = System.Drawing.Color.Black,
                        Size = size,
                        
                };

                    uc.MouseDown += (sender, e) => { uc.BorderStyle = BorderStyle.FixedSingle; };
                    uc.MouseUp += (sender, e) => { uc.BorderStyle = BorderStyle.None; };
                    flowLayoutPanel2.Controls.Add(uc);
                    

                }
                flowLayoutPanel2.AutoScroll = true;
                
            }
            catch (Exception objex)
            {
                string strerrormessage = "lỗi gọi api";
                string strerrormessagedetail = objex.ToString();
                MessageBox.Show(strerrormessagedetail, strerrormessage);
            }


            //Set key và data cho combobox roles
            cbbColors.DisplayMember = "Text";
            cbbColors.ValueMember = "Value";
            List<Object> items = new List<Object>();
            foreach (var item in colors)
            {
                items.Add(new { Text = item.name, Value = item.id });
            }
            cbbColors.DataSource = items;

            //Set key và data cho combobox roles
            cbbCategory.DisplayMember = "Text";
            cbbCategory.ValueMember = "Value";
            List<Object> items1 = new List<Object>();
            foreach (var item in category)
            {
                items1.Add(new { Text = item.name, Value = item.id });
            }
            cbbCategory.DataSource = items1;

        }

        

        private void FormProducts_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flower flower = new Flower();
            byte[] a = null;
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                 a = imageToByteArray(Image.FromFile(fileOpen.FileName));
            }
            base64String = Convert.ToBase64String(a, 0, a.Length);
            fileOpen.Dispose();
             

            Console.WriteLine(a);
            Console.WriteLine(base64String);
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                pictureBox1.Image = Image.FromStream(ms, true);
            }

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //Byte array to photo
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHoa_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string price = txtPrice.Text;
            string contents = txtContents.Text;
            string discount = txtDiscount.Text;
            string image = base64String;
            string imgDetail = rtbImgDetail.Text;
            var a = cbbColors.SelectedValue;
            var b = cbbCategory.SelectedValue;
            string idColor = a.ToString();
            string idCategory = b.ToString();

            var body = "{\"name\":\"" + name + "\",\"price\":\"" + price + "\",\"contents\":\"" + contents + "\",\"discount\":\"" + discount + "\",\"image\":\"" + image + "\",\"imgDetail\":\"" + imgDetail +"\",\"idColor\":"+idColor+ ",\"idCategory\":" + idCategory + "}";
            try
            {
                var response = postAPIs.PostFlower(body)["responseCode"];
                //int responseCode = Convert.ToInt32(((int)response).ToString());                
                int responseCode = 1;
                if (responseCode != 0)
                {
                    MessageBox.Show(response.ToString(), "Lỗi gọi API");
                }
                else
                {
                    MessageBox.Show("Thanh toán thành công");
                    JToken listFlowerJson = getAPIs.GetAllFlower()["responseData"]["data"];
                    IList<Flower> flowers = listFlowerJson.ToObject<IList<Flower>>();
                    var listflower = flowers.GroupBy(x => x.name).Select(y => y.First()).ToList();

                    //foreach (var item in listflower)
                    //{
                    //    ShopItem uc = new ShopItem(item.name, item.price, item.image)
                    //    {
                    //        ForeColor = System.Drawing.Color.Black,
                    //        Size = size,

                    //    };
                    //    flowLayoutPanel2.Controls.Add(uc);


                    //}
                    //flowLayoutPanel2.AutoScroll = true;
                }
            }
            catch (Exception objEx)
            {
                string strErrorMessage = "Lỗi gọi API";
                string strErrorMessageDetail = objEx.ToString();
                MessageBox.Show(strErrorMessageDetail, strErrorMessage);
            }
        }
    }
}
