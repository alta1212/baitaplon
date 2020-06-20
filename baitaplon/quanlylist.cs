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
    public partial class quanlylist : Form
    {
        string data;
        public void getdata(string chuoi)
        {
            data = chuoi;
            Clipboard.SetText(data);
        }
        public quanlylist()
        {
            InitializeComponent();
        }

        private void quanlylist_Load(object sender, EventArgs e)
        {

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            phongban k = new phongban();
            k.getdata(data);
            k.ShowDialog();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            bangcong k = new bangcong();
            k.getdata(data);
            k.ShowDialog();
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            frmbophan k = new frmbophan();
            k.getdata(data);
            k.ShowDialog();
        }
    }
}
