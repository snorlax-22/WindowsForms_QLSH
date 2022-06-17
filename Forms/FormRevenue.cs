using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsForms_QLSH.Models;

namespace WindowsForms_QLSH.Forms
{
    public partial class FormRevenue : Form
    {
        APIs.GetAPIs getAPIs = new APIs.GetAPIs();
        public FormRevenue()
        {
            InitializeComponent();

            

            JToken listChartJson = getAPIs.GetChart()["responseData"]["data"];

            IList<Models.Chart> chart = listChartJson.ToObject<IList<Models.Chart>>();
            
            chart1.DataSource = chart;
            Series series = this.chart1.Series.Add("Doanh thu theo tháng");
            chart1.Palette = ChartColorPalette.Excel;
            foreach (var item in chart)
            {
                series.Points.AddXY(item.month, item.amount);
            }
            chart1.Titles.Add("Biểu đồ doanh thu");
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
