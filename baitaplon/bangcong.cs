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
    public partial class bangcong : Form
    {
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
        public bangcong()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }
        void loaddatagirl()
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter("select * from TblBangCongThuViec", data);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            ngatketNoi();
        }
        private void xuiButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string insert = "insert into TblBangCongThuViec values(N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + cbbmnv1.Text + "',N'" + txt3.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + textBox3.Text + "',N'" + txt9.Text + "')";
                comd = new SqlCommand(insert, cont);
                read = comd.ExecuteReader();
                loaddatagirl();
                MessageBox.Show("Xong");
                ngatketNoi();
            }
            catch (Exception ll)
            {
                MessageBox.Show(ll.Message);
            }
        }
        void loadcbb(ComboBox m,string sql)
        {
            ketNoi();
            comd = new SqlCommand(sql,cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                m.Items.Add(read[0].ToString());
            }

            ngatketNoi();
        }
        private void bangcong_Load(object sender, EventArgs e)
        {
            loaddatagirl();
            loadcbb(cbbmnv1, "select MaNVTV from TblHoSoThuViec");
            loadcbb(cbbtenphong, "SELECT TenPhong FROM TblPhongBan");
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update TblBangCongThuViec set TenBoPhan=N'" + txt1.Text + "',TenPhong=N'" + txt2.Text + "',LuongTViec=N'" + txt3.Text + "',Thang=N'" + txt4.Text + "',Nam='" + txt5.Text + "',SoNgayCong=N'" + txt6.Text + "',SoNgayNghi=N'" + txt7.Text + "',SoGioLamThem=N'" + txt8.Text + "',Luong=N'" + textBox3.Text + "',GhiChu='" + txt9.Text + "' where MaNVTV=N'" + cbbmnv1.Text + "'";
                comd = new SqlCommand(update,cont);
                comd.ExecuteNonQuery();
                loaddatagirl();
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           try 
            {
                int i = e.RowIndex;
                txt1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                txt2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                cbbmnv1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                txt3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txt4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                txt5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                txt6.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                txt7.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                txt8.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                txt9.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            }
            catch
            {

            }
          
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "delete from TblBangCongThuViec where MaNVTV=N'" + cbbmnv1.Text + "'";
                comd = new SqlCommand(delete, cont);
                comd.ExecuteNonQuery();
                MessageBox.Show("Xong");
                loaddatagirl();
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void xuiButton6_Click(object sender, EventArgs e)
        {
            int l = Convert.ToInt32(txt3.Text);
            int nc = Convert.ToInt32(txt6.Text);
            int lt = Convert.ToInt32(txt8.Text);
            float luong = ((l / 26) * nc + (lt * 40000));
            textBox3.Text = luong.ToString();
        }
    }
}
