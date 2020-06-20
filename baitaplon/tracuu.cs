using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class tracuu : Form
    {
        string data;
        SqlConnection cont;
        DataTable dt;
        SqlDataAdapter adap;
        public void getdata(string chuoi)
        {
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

        public tracuu()
        {
            InitializeComponent();
        }

        private void tracuu_Load(object sender, EventArgs e)
        {
            loaddta("select * from TblTTNVCoBan");
        }
        void loaddta(string k)
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter(k, data);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            ngatketNoi();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text == ""))
                {
                    MessageBox.Show("bạn chưa nhập tù khóa", "Nhập từ khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    int i=0;
                    string sql;
                    foreach (RadioButton rdo in groupBox3.Controls.OfType<RadioButton>())
                    {
                        i++;
                        if (rdo.Checked)
                        {
                            break;

                        }
                    }
                    if(i==1)
                    {
                        sql= "select * from TblTTNVCoBan where MaNV like N'%" + textBox1.Text + "%'";
                        loaddta(sql);
                    }
          

                    if (i == 2)
                    {
                        sql = "select * from TblTTNVCoBan where HoTen like N'%" + textBox1.Text + "%'";
                        loaddta(sql);
                    }
                  

                    if (i == 3)
                    {
                        sql = "select * from TblTTNVCoBan where CMTND like N'%" + textBox1.Text + "%'";
                        loaddta(sql);
                    }

                   

                }
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
