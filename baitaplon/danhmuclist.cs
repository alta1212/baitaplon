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
    public partial class danhmuclist : Form
    {
        string data,per;
        public danhmuclist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmcoban l = new frmcoban();
            l.ShowDialog();
        }

        private void danhmuclist_Load(object sender, EventArgs e)
        {
          
        }
        public void getdata(string sql,string quyen)
        {
            per = quyen;
            data = sql;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i4canhan l = new i4canhan();
            l.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chedo l = new chedo();
            l.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thuviec l = new thuviec();
            l.ShowDialog();
        }
    }
    
}
