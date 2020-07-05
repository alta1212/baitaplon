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
        SqlCommand comd;
        SqlDataReader read;
        DataTable dt;
        SqlDataAdapter sqladt;

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
      
   



        public delegate void delPassData(TextBox text);



        private void login_Load(object sender, EventArgs e)
        {
            ch.Checked = baitaplon.Properties.Settings.Default.check;
            if (baitaplon.Properties.Settings.Default.check)
            {
                txtid.Text = baitaplon.Properties.Settings.Default.id;
                txtpass.Text = baitaplon.Properties.Settings.Default.pass;
                ch.Checked = baitaplon.Properties.Settings.Default.check;
            }
            else
            {
                txtid.Text = "";
                txtid.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton1_Click(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id = txtid.Text;
            Properties.Settings.Default.pass = txtpass.Text;
            Properties.Settings.Default.check = ch.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Save();
         
        //    try
            {

                data = string.Format(@"Data Source=(local);Initial Catalog=qlns;Persist Security Info=True;User ID={0};Password={1}", txtid.Text, txtpass.Text);
                ketNoi();
                Hide();
                main l = new main();
                l.getdata(data,check(),txtid.Text);
                l.ShowDialog();
                Close();
                

            }
           //catch
           // {
           //     MessageBox.Show("Sai tên đăng nhập hoặc mật khảu");
           // }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
      
        }
        public string check()
        {
            int i = 0;
            string sql = "SELECT 	roles.[name] as role_name,	members.[name] as user_name FROM sys.database_role_members     JOIN sys.database_principals roles ON database_role_members.role_principal_id = roles.principal_id       JOIN sys.database_principals members ON database_role_members.member_principal_id = members.principal_id	ORDER BY 	roles.[name],	members.[name]";
            sqladt = new SqlDataAdapter(sql,cont);
            dt = new DataTable();
            sqladt.Fill(dt);
            while (i<dt.Rows.Count)
            {   
                if(dt.Rows[i][0].ToString() == "quantri" && dt.Rows[i][1].ToString() == txtid.Text)
                {

                    return dt.Rows[i][0].ToString();
                }
                else if (dt.Rows[i][0].ToString() == "nguoidung" && dt.Rows[i][1].ToString() == txtid.Text)
                {

                    return dt.Rows[i][0].ToString();
                }

                i++;
            }
            return "caonhat";
        }
    }
}
