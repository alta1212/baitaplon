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
    public partial class phongban : Form
    {
     
        check ck = new check();

        public phongban()
        {
            InitializeComponent();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void phongban_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from tblphongban",dataGridView1);
            ck.loadcbb(comboBox1, 0, "select * from TblBoPhan");
        }
     

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {if(ck.checkmatrung(textBox2.Text, "TblPhongBan", "MaPhong"))
            try
            {
                    errorProvider1.Clear();
               
                    string insert = "insert into TblPhongBan values('" + comboBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox5.Text + "')";
                    ck.thucthi(insert);
                ck.loaddg("select * from tblphongban", dataGridView1);
                MessageBox.Show("Xong");
              
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
            else
            {
                errorProvider1.SetError(textBox2, "mã phòng đã tồn tại");
            }    
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            try
            {
              
                string update = "update TblPhongBan set MaBoPhan=N'" + comboBox1.Text + "',TenPhong=N'" + textBox3.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox5.Text + "' where MaPhong=N'" + textBox2.Text.Trim() + "'";
                Clipboard.SetText(update);
                ck.thucthi(update);
                ck.loaddg("select * from tblphongban", dataGridView1);
                MessageBox.Show("Sửa thành công");
              
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            try
            {
              
                string del = "delete from TblPhongBan where MaPhong=N'" + textBox2.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ck.thucthi(del);
                    ck.loaddg("select * from tblphongban", dataGridView1);
                    MessageBox.Show("xoá thành công");
                }
               
            }
            catch(Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            comboBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
    }
}
