using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class chucnanglist : Form
    {
        string data,per;
        public chucnanglist()
        {
            InitializeComponent();
        }
        public void getdata(string chuoi,string quyen)
        {
            per = quyen;
            data = chuoi;
            Clipboard.SetText(data);
        }
        private void xuiButton2_MouseHover(object sender, EventArgs e)
        {
        }

        private void xuiButton3_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void xuiButton1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            tracuu l = new tracuu();
          
            l.ShowDialog();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {

        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/anhlatuananh.android");
        }

        private void chucnanglist_Load(object sender, EventArgs e)
        {

        }
    }
}
