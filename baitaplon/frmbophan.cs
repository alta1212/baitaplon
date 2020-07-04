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
        string data;
        check ck = new check();
        SqlConnection cont;
        SqlCommand comd;
        SqlDataReader read;
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
            try
            {
                ketNoi();
                string insert = "insert into TblBoPhan values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox3.Text + "')";
                comd = new SqlCommand(insert, cont);
                comd.ExecuteNonQuery();
                ck.loaddg("select * from TblBoPhan", dataGridView1);
                MessageBox.Show("Xong");
                ngatketNoi();
                

            }
            catch(Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        private void frmbophan_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from TblBoPhan", dataGridView1);
        }
       

        private void xuiButton5_Click(object sender, EventArgs e)
        {

            try
            {
                ketNoi();
                string update = "update TblBoPhan set TenBoPhan=N'" + textBox2.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox3.Text + "' where MaBoPhan='" + textBox1.Text + "'";
                comd = new SqlCommand(update, cont);
                comd.ExecuteNonQuery();
                ck.loaddg("select * from TblBoPhan", dataGridView1);
                MessageBox.Show("Xong");
                ngatketNoi();
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
                    ketNoi();
                    string del = "delete from TblBoPhan where MaBoPhan='" + textBox1.Text + "'";
                    comd = new SqlCommand(del, cont);
                    comd.ExecuteNonQuery();
                    MessageBox.Show("xoá thành công");
                    ngatketNoi();
                }
                catch (Exception l)
                {
                    MessageBox.Show(l.Message);
                }
            }

        }
    }
}
