using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        string data;
        SqlConnection cont;

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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
     (
         int nLeftRect,     // x-coordinate of upper-left corner
         int nTopRect,      // y-coordinate of upper-left corner
         int nRightRect,    // x-coordinate of lower-right corner
         int nBottomRect,   // y-coordinate of lower-right corner
         int nWidthEllipse, // height of ellipse
         int nHeightEllipse // width of ellipse
     );
   



        public delegate void delPassData(TextBox text);



        private void login_Load(object sender, EventArgs e)
        {
            ch.Checked = baitaplon.Properties.Settings.Default.check;
            if (baitaplon.Properties.Settings.Default.check)
            {
                txtid.Text = baitaplon.Properties.Settings.Default.id;
                txtpass.Text = baitaplon.Properties.Settings.Default.pass;

            }
            else
            {
                txtid.Text = "";
                txtid.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {

                data = string.Format(@"Data Source=(local);Initial Catalog=qlns;Persist Security Info=True;User ID={0};Password={1}", txtid.Text, txtpass.Text);
                ketNoi();

                baitaplon.Properties.Settings.Default.id = txtid.Text;
                baitaplon.Properties.Settings.Default.pass = txtpass.Text;
                baitaplon.Properties.Settings.Default.Save();
                baitaplon.Properties.Settings.Default.check = ch.Checked;
                Hide();
                main l = new main();
                l.getdata(data);
                l.ShowDialog();
                Close();

            }
           catch
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khảu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
