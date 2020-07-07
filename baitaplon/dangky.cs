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
    public partial class dangky : Form
    {
        string data;
        SqlConnection cont;
        SqlCommand comd;
        string quyen;
        public void getdata(string chuoi,string per)
        {
            quyen = per;
            data = chuoi;

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
        public dangky()
        {
            InitializeComponent();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            ketNoi();
            string sql;
            try
            {
                if(textBox2.Text!=textBox3.Text)
                {
                    MessageBox.Show("mật khẩu xác nhận không đúng");
                }    
                else if(textBox2.Text=="")
                {
                    MessageBox.Show("Vui lòng điền mật khẩu");
                }    
                else
                {
                    if(bunifuDropdown1.selectedIndex==1)
                    {
                        sql =string.Format("Exec sp_addlogin {0},'{1}' Exec sp_adduser {0},{0} Exec sp_addrolemember quantri, {0}",textBox1.Text,textBox2.Text);
                 
                    }   
                    else
                    {
                        sql = string.Format("Exec sp_addlogin {0},'{1}' Exec sp_adduser {0},{0} Exec sp_addrolemember nguoidung, {0}", textBox1.Text, textBox2.Text);
                    }
                    comd = new SqlCommand(sql,cont);
                    comd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm người dùng");
                }  
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã có người sử dụng !");
            }
  
            ngatketNoi();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dangky_Load(object sender, EventArgs e)
        {
            if(quyen=="caonhat")
            {
                bunifuDropdown1.AddItem("Admin");
            }    
        }
    }
}
