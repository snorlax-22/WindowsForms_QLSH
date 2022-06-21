using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_QLSH.Forms;

namespace WindowsForms_QLSH
{
    internal static class Program
    {
        public static List<string> ColorList = new List<string>
        {

        };
        public static string baseURL = "http://127.0.0.1:8080/HDVAPI/";
        public static string bearerToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJEb2FuQ3VvbmdEYWkiLCJuYW1lIjoiSERWIEdyb3VwIiwiaWF0IjoyNTAxMjAyMjA5MTE3MTE5MDB9.2VaeS_V11otO0TX6P1w9eIPQQKtlNHbGfUoS55AzkGg";
        public static string contentType = "application/json";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.MaxServicePointIdleTime = 5000;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            //Application.Run(new Form1());
        }

        
    }
}
