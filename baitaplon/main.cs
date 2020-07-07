using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class main : Form
    {
        string data=Properties.Settings.Default.data;
        string perm = Properties.Settings.Default.per;
        public main()
        {
            InitializeComponent();
        }
      
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void changuser_Click(object sender, EventArgs e)
        {
            Hide();
            login k = new login();
            k.ShowDialog();
            Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
          
                   Application.Exit();

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            danhmuclist l = new danhmuclist();
          
            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
           
        //    l.ShowDialog();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            chucnanglist l = new chucnanglist();

            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            quanlylist l = new quanlylist();
          
            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
        }

        private void xuiClock1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bây giờ là : " +DateTime.Now);
        }

        private void main_Load(object sender, EventArgs e)
        {
            label1.Text = Properties.Settings.Default.id;
          
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            thongke k = new thongke();
            k.ShowDialog();
         
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            qltklist l = new qltklist();
            MessageBox.Show(data + perm);
            l.getdata(perm);
            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
        }
    }
} 
