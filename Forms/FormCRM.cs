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

            JToken listflowerjson = getAPIs.GetAllRole()["responseData"]["data"];

            IList<Role> roles = listflowerjson.ToObject<IList<Role>>();
            List<string> nameRole = new List<string>();

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
                var a = postAPIs.PostAcount(body)["responseCode"]["code"];
                int responseCode = Convert.ToInt32(((int)a).ToString());
                if (responseCode != 0)
                {
                    MessageBox.Show(a.ToString(), "Lỗi gọi API");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thành công");
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
