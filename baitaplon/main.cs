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
        SqlConnection cont;
        string data;
        string perm,tendn;
        public main()
        {
            InitializeComponent();
        }
        public void getdata(string text,string per,string ten)
        {
            tendn = ten;
            perm = per;
            data = text;
            ketNoi();
        }
        void ketNoi()
        {
            cont = new SqlConnection(data);
            // Mở
            if (cont.State == ConnectionState.Closed)
                cont.Open();
        }
        void ngatketNoi()
        {
            cont = new SqlConnection(data);
            // Đóng
            if (cont.State == ConnectionState.Open)
                cont.Close();
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
            l.getdata(data,perm);
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
            l.getdata(data,perm);
            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            quanlylist l = new quanlylist();
            l.getdata(data,perm);
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
            label1.Text = tendn;
          
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            qltklist l = new qltklist();
            l.getdata(data,perm,tendn);
            pannelmenu.Controls.Clear();
            l.TopLevel = false;
            l.Dock = DockStyle.Fill;
            pannelmenu.Controls.Add(l);
            l.Show();
        }
    }
} 
