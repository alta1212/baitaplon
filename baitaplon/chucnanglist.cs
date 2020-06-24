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
            xuiButton4.Visible = true;
            xuiButton5.Visible = true;
        }

        private void xuiButton3_MouseHover(object sender, EventArgs e)
        {
            xuiButton4.Visible = false;
            xuiButton5.Visible = false;
        }

        private void xuiButton1_MouseHover(object sender, EventArgs e)
        {
            xuiButton4.Visible = false;
            xuiButton5.Visible = false;
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            tracuu l = new tracuu();
            l.getdata(data);
            l.ShowDialog();
        }

        private void chucnanglist_Load(object sender, EventArgs e)
        {

        }
    }
}
