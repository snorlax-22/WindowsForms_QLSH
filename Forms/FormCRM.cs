using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WindowsForms_QLSH.APIs;
using WindowsForms_QLSH.Forms;

namespace WindowsForms_QLSH
{
    public partial class FormCRM : Form
    {
        GetAPIs getAPIs = new GetAPIs();
        PostAPIs postAPIs = new PostAPIs();

        APIHelper apiHelper = new APIHelper();
        public FormCRM()
        {
            InitializeComponent();

            JToken listAccountJson = getAPIs.GetAllAccounts()["responseData"]["data"];

            JToken listRolesJson = getAPIs.GetAllRole()["responseData"]["data"];

            IList<Role> roles = listRolesJson.ToObject<IList<Role>>();
            IList<User> users = listAccountJson.ToObject<IList<User>>();
            foreach(var item in users)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddMilliseconds(Double.Parse(item.created)).ToLocalTime();              
                item.created = dateTime.ToString();
            }
           
            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    if (user.idRole.Equals(role.id.ToString()))
                    {
                        user.idRole = role.roleName;
                    }
                }
            }

            dataGridView1.DataSource = users;

            this.dataGridView1.Columns["updated"].Visible = false;
            this.dataGridView1.Columns["isDeleted"].Visible = false;
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["created"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["idRole"].HeaderText = "Vai trò";

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.FromArgb(30, 30, 30);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Set key và data cho combobox roles
            cbbRoles.DisplayMember = "Text";
            cbbRoles.ValueMember = "Value";
            List<Object> items = new List<Object>();
            foreach (var item in roles)
            {
                items.Add(new { Text = item.roleName, Value = item.id });
            }
            cbbRoles.DataSource = items;
        }

        private void cbbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string pw = txtPw.Text;
                int idRole = (int)cbbRoles.SelectedValue;

                //join các biến lấy từ người dùng thành json string để truyền vào API PostAccount
                var body = "{\"email\":\"" + email + "\",\"name\":\"" + name + "\",\"phone\":\"" + phone + "\",\"address\":\"" + address + "\",\"password\":\"" + pw + "\",\"idRole\":" + idRole + "}";

                //postAPIs.PostAcount(body);
                var response = postAPIs.PostAcount(body)["responseCode"]["code"];
                int responseCode = Convert.ToInt32(((int)response).ToString());
                if (responseCode != 0)
                {
                    MessageBox.Show(response.ToString(), "Lỗi gọi API");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    JToken listAccountJson = getAPIs.GetAllAccounts()["responseData"]["data"];
                    IList<User> users = listAccountJson.ToObject<IList<User>>();
                    dataGridView1.DataSource = users;
                }
            }
            catch (Exception objEx)
            {
                string strErrorMessage = "Lỗi gọi API";
                string strErrorMessageDetail = objEx.ToString();
                MessageBox.Show(strErrorMessageDetail, strErrorMessage);
            }
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
