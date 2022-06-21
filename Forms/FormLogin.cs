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

                var response = getAPIs.GetLogin(body)["responseData"]["id"];
                int responseCode = Convert.ToInt32(((int)response).ToString());
                //Console.WriteLine(response);

                
                
                if (responseCode == -1)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    return;
                }
                else
                {

                    var response2 = getAPIs.GetAllRole()["responseData"]["id"];
                    //int responseCode2 = Convert.ToInt32(((int)response).ToString());
                    Console.WriteLine(response2);
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    //MessageBox.Show("Login thành công");
                    //return;
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
