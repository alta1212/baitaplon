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
    public partial class frmbophan : Form
    {
      
        check ck = new check();

        public frmbophan()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            if (ck.checkmatrung(textBox1.Text, "TblBoPhan", "mabophan"))
                try
                {
                    errorProvider1.Clear();
                    string insert = "insert into TblBoPhan values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox3.Text + "')";
                    ck.thucthi(insert);
                    ck.loaddg("select * from TblBoPhan", dataGridView1);
                    MessageBox.Show("Xong");



                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            else
                errorProvider1.SetError(textBox1,"mã bộ phận đã tồn tại");
        }

        private void frmbophan_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from TblBoPhan", dataGridView1);
        }
       

        private void xuiButton5_Click(object sender, EventArgs e)
        {

            try
            {
              
                string update = "update TblBoPhan set TenBoPhan=N'" + textBox2.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox3.Text + "' where MaBoPhan='" + textBox1.Text + "'";
                ck.thucthi(update);
                ck.loaddg("select * from TblBoPhan", dataGridView1);
              
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    
                    string del = "delete from TblBoPhan where MaBoPhan='" + textBox1.Text + "'";
                    ck.thucthi(del);
                    MessageBox.Show("xoá thành công");
                   
                }
                catch (Exception l)
                {
                    MessageBox.Show(l.Message);
                }
            }

        }
    }
}
