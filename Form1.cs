using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Net;
using System.Reflection;
using System.IO;
using RestSharp;
using Newtonsoft.Json.Linq;
using WindowsForms_QLSH.APIs;
using WindowsForms_QLSH.Models;

namespace WindowsForms_QLSH
{
    public partial class Form1 : Form
    {

        APIHelper apiHelper = new APIHelper();
        GetAPIs getAPIs = new GetAPIs();
        public Form1()
        {
            InitializeComponent();
            try
            {
                var listRoleJson = getAPIs.GetAllRole()["responseData"]["data"];
                var listFlowerJson = getAPIs.GetAllFlower()["responseData"]["data"];
                IList<Role> roles = listRoleJson.ToObject<IList<Role>>();
                IList<Flower> flowers = listFlowerJson.ToObject<IList<Flower>>();
                dataGridView1.DataSource = roles;
                dataGridView2.DataSource = flowers;
            }
            catch (Exception objEx)
            {
                string strErrorMessage = "Lỗi gọi API";
                string strErrorMessageDetail = objEx.ToString();
                MessageBox.Show(strErrorMessageDetail, strErrorMessage);
            }

          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
