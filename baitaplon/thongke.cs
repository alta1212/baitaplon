using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class thongke : Form
    {
        check ck = new check();
        public thongke()
        {
            InitializeComponent();
        }

        private void thongke_Load(object sender, EventArgs e)
        {
            ck.report();
            crystalReportViewer1.ReportSource = crystalReportViewer1;
            crystalReportViewer1.Refresh(); 
        }
    }
}
