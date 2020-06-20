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
    public partial class i4canhan : Form
    {

        public i4canhan()
        {
            InitializeComponent();
        }
        string data;
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
        void loaddtgv()
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter("select * from TblTTCaNhan", data);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            ngatketNoi();
        }
        void loadmnv()
        {
            ketNoi();
            comd = new SqlCommand("select * from TblTTNVCoBan", cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cbbmnv.Items.Add(read[2].ToString());
            }

            ngatketNoi();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void i4canhan_Load(object sender, EventArgs e)
        {
            loaddtgv();
            loadmnv();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;

                cbbmnv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                txthoten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtnoisinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtnguyenquan.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtdiachi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtdiachitamtru.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtdantoc.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                txttongiao.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtquoctich.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                txthocvan.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtghichu.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
                cbbmnv.Enabled = false;
            }
            catch
            { }
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "update TblTTCaNhan set Noisinh=N'" + txtnoisinh.Text + "',NguyenQuan=N'" + txtnguyenquan.Text + "',DCThuongChu=N'" + txtdiachi.Text + "',DCTamChu=N'" + txtdiachitamtru.Text + "',SDT=N'" + txtsdt.Text + "',DanToc=N'" + txtdantoc.Text + "',TonGiao=N'"+txttongiao.Text+ "',QuocTich=N'"+txtquoctich.Text+"',HocVan=N'"+txthocvan.Text+"',GhiChu=N'"+txtghichu.Text+"' where MaNV=N'"+cbbmnv.Text+"'";
          try
            {
                ketNoi();
                comd = new SqlCommand(sql,cont);
                comd.ExecuteNonQuery();

                foreach (Control ctr in this.groupBox1.Controls)
                {
                    if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                    {
                        ctr.Text = "";
                    }
                }
                loaddtgv();
                MessageBox.Show("xong");
                ngatketNoi();
                
            }
            catch
            {

            }
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            cbbmnv.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "delete from TblTTCaNhan where MaBoPhan=N'" + cbbmnv.Text + "'";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ketNoi();
                    comd = new SqlCommand(sql, cont);
                    comd.ExecuteNonQuery();
                    ngatketNoi();
                    MessageBox.Show("Đã xoá");
                    dataGridView1.Refresh();
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xoá");
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
