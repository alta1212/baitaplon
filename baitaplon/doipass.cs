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
    public partial class doipass : Form
    {
        SqlCommand comd;
        SqlConnection cont;
        string data, id;
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
        public void getdata(string chuoi,string dn)
        {
            data = chuoi;
            id = dn;
        }    
        public doipass()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xuiButton1_Click(sender,e);
           
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {try
            {
                ketNoi();
                if(txtpassnew.Text=="")
                {
                    MessageBox.Show("Mật khẩu không được trống");
                }   
                else if(txtpassnew.Text!=txtpassnew2.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không đúng");
                }    
                else
                {
                    string sql = "ALTER LOGIN "+id+" WITH PASSWORD = '"+txtpassnew.Text+"' OLD_PASSWORD = '"+txtpassold.Text+"' ";
                    comd = new SqlCommand(sql, cont);
                    comd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công,vui lòng đăng nhập lại");
                    Hide();
                    Close();
                    login k = new login();
                    k.ShowDialog();
                }    
              
                ngatketNoi();
            }
            catch
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
            }
        }
    }
}
