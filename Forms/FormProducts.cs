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
        public FormProducts(JToken listflowerjson)
        {
            GetAPIs getAPIs = new GetAPIs();
            InitializeComponent();


            IList<Flower> flowers;
            Size size= new Size(200, 200);
            
            try
            {
                //var listflowerjson = getAPIs.GetAllFlower()["responseData"]["data"];
                flowers = listflowerjson.ToObject<IList<Flower>>();

                //there are many flowers in the list with the same name, so we need to remove duplicate
                var listflower = flowers.GroupBy(x => x.name).Select(y => y.First()).ToList();

                foreach (var item in listflower)
                {
                   
                    ShopItem uc = new ShopItem(item.name,item.price,item.image)
                    {
                        ForeColor = Color.Black,
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


            //----------Cách gọi get API
            //try
            //{
            //    var listFlowerJson = getAPIs.GetAllFlower()["responseData"]["data"];

            //    IList<Flower> flowers = listFlowerJson.ToObject<IList<Flower>>();

            //    dataGridView1.DataSource = flowers;


            //}
            //catch (Exception objEx)
            //{
            //    string strErrorMessage = "Lỗi gọi API";
            //    string strErrorMessageDetail = objEx.ToString();
            //    MessageBox.Show(strErrorMessageDetail, strErrorMessage);
            //}

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
            string base64String = Convert.ToBase64String(a, 0, a.Length);
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
    }
}
