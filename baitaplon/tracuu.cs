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
        check ck = new check();
        public tracuu()
        {
            InitializeComponent();
        }

        private void tracuu_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from TblTTNVCoBan",dataGridView1);
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
                        ck.loaddg(sql,dataGridView1 );
                    }
          

                    if (i == 2)
                    {
                        sql = "select * from TblTTNVCoBan where HoTen like N'%" + textBox1.Text + "%'";
                        ck.loaddg(sql, dataGridView1);
                    }
                  

                    if (i == 3)
                    {
                        sql = "select * from TblTTNVCoBan where CMTND like N'%" + textBox1.Text + "%'";
                        ck.loaddg(sql, dataGridView1);
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
