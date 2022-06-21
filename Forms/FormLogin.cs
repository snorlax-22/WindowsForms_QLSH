using System;
using System.Windows.Forms;
using WindowsForms_QLSH.APIs;

namespace WindowsForms_QLSH.Forms
{
    public partial class FormLogin : Form
    {
        GetAPIs getAPIs = new GetAPIs();
        PostAPIs postAPIs = new PostAPIs();

        APIHelper apiHelper = new APIHelper();
        public FormLogin()
        {
            InitializeComponent();
            //JToken listAccountJson = getAPIs.GetAllAccounts()["responseData"]["id"];

            //JToken listRolesJson = getAPIs.GetAllRole()["responseData"]["id"];


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                //join các biến lấy từ người dùng thành json string để truyền vào API PostAccount
                var body = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
                Console.WriteLine(body);
                //postAPIs.PostAcount(body);
                var response = getAPIs.GetLogin(body)["responseData"];
                //var responseCode = Convert.ToInt32(((int)response).ToString());
                Console.WriteLine(response);
                //if (responseCode == -1)
                //{
                //    MessageBox.Show(response.ToString(), "Lỗi gọi API");
                //    return;
                //}
                //else
                //{
                //    MessageBox.Show("Thêm tài khoản thành công");
                //    //dataGridView1.Update();
                //    //dataGridView1.Refresh();
                //    //JToken listAccountJson = getAPIs.GetAllAccounts()["responseData"]["data"];
                //    //IList<User> users = listAccountJson.ToObject<IList<User>>();
                //    //dataGridView1.DataSource = users;
                //}
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
