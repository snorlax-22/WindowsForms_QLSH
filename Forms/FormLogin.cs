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

                ////join các biến lấy từ người dùng thành json string để truyền vào API PostAccount
                var body = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";

                var response = getAPIs.GetLogin(body)["responseCode"]["code"];
                int responseCode = Convert.ToInt32(((int)response).ToString());
                           
                if (responseCode != 0)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    return;
                }
                else
                {

                    var response2 = getAPIs.GetLogin(body)["responseData"]["idRole"];
                    int responseCode2 = Convert.ToInt32(((int)response2).ToString());
                    Console.WriteLine("oke", responseCode2, response2);
              
                   if(responseCode2 == 2 || responseCode2 == 1)
                    {
                        MessageBox.Show("Login thành công");

                        Form1 form1 = new Form1();
                        form1.ShowDialog();
                    } else
                    {
                        MessageBox.Show("Bạn không có quyền truy cập");
                        return;
                    }
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
