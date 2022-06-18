//using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using Octokit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_QLSH.APIs;
using WindowsForms_QLSH.Forms;


namespace WindowsForms_QLSH
{
    public partial class Form1 : Form
    {
        GetAPIs getAPIs = new GetAPIs();
        
        APIHelper apiHelper = new APIHelper();
        JToken listflowerjson;
        PostAPIs postAPIs = new PostAPIs();
        private Form activeForm;

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public Form1()
        {

            InitializeComponent();


            //_ = githubAsync();


                        this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            listflowerjson = getAPIs.GetAllFlower()["responseData"]["data"];
            
        }

        public async Task githubAsync()
        {
            var gitHubClient = new GitHubClient(new ProductHeaderValue("MyCoolApp"));
            var user = await gitHubClient.User.Get("snorlax-22");
            gitHubClient.Credentials = new Credentials("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");
            Console.WriteLine($"Woah! Dave has {user.Login} public repositories.");
        }

        public void openChildForm(Form childForm, object btnSender)
        {
            //if(activeForm != null)
            //{
            //    activeForm.Close();
            //}
            //mở Form được truyền vào
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPhieuTam_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            
            openChildForm(new FormBill(listflowerjson), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            openChildForm(new FormProducts(listflowerjson), sender);
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
           
            openChildForm(new FormCRM(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormRevenue(), sender);
        }

        private void DisableCreateBillButton()
        {
          
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
               this.WindowState = FormWindowState.Maximized;
            }
            
        }

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            //kéo thả được form bằng cách giữ chuột ở title
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {

        }
    }
}
