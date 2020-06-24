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
    public partial class bangluong : Form
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
        public bangluong()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton8_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton10_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();

                string insert = "insert into TblBangLuongCTy values(N'" + txt1.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + dateTimePicker1.Text + "',N'" + txt6.Text + "',N'" + dateTimePicker2.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + dateTimePicker3.Text + "',N'" + txt9.Text + "')";
                comd = new SqlCommand(insert,cont);
                comd.ExecuteNonQuery();
                MessageBox.Show("xong");
                loaddatagirl("select * from TblBangLuongCTy", dataGridView1);
                ngatketNoi();
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }
        void loaddatagirl(string sql,DataGridView d)
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter(sql, data);
            adap.Fill(dt);
            d.DataSource = dt;
            ngatketNoi();
        }

        private void bangluong_Load(object sender, EventArgs e)
        {
            loaddatagirl("select * from TblBangLuongCTy",dataGridView1);
            loaddatagirl("select * from TblTangLuong", dg2);
            loadcombobox(comboBox1, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )", 2);
        }

        public void loadcombobox(ComboBox cb, string strselect, byte chiso)
        {
            ketNoi();
            comd = new SqlCommand(strselect, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cb.Items.Add(read[chiso].ToString());
            }
            ngatketNoi();
            read.Close();
        }

        private void xuiButton9_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblBangLuongCTy set LCB=N'" + txt4.Text + "',PCChucVu=N'" + txt5.Text + "',NgayNhap='" + dateTimePicker1.Text + "',LCBMoi=N'" + txt6.Text + "',NgaySua=N'" + dateTimePicker2.Text + "',LyDo=N'" + txt7.Text + "',PCCVuMoi='" + txt8.Text + "',NgaySuaPC=N'" + dateTimePicker3.Text + "',GhiChu=N'" + txt9.Text + "' where MaLuong=N'" + txt1.Text + "'";
                comd = new SqlCommand(update, cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblBangLuongCTy", dataGridView1);
                MessageBox.Show("Sửa thành công");
                ngatketNoi();
            }
            catch(Exception l)
            {
                MessageBox.Show(l.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 int i = e.RowIndex;
            txt1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt6.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt7.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt8.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txt9.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            }
            catch
            {

            }
           
        }

        private void dg2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 int i = e.RowIndex;
          
                comboBox1.Text = dg2.Rows[i].Cells[0].Value.ToString();
         
                txt10.Text = dg2.Rows[i].Cells[1].Value.ToString();
                txt11.Text = dg2.Rows[i].Cells[2].Value.ToString();
                txt12.Text = dg2.Rows[i].Cells[3].Value.ToString();
                textBox1.Text = dg2.Rows[i].Cells[4].Value.ToString();
                txt15.Text = dg2.Rows[i].Cells[5].Value.ToString();
                dateTimePicker6.Text = dg2.Rows[i].Cells[6].Value.ToString();
                txt18.Text = dg2.Rows[i].Cells[7].Value.ToString();
            }
            catch
            {
               
            }
           
        }

        private void xuiButton6_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string delete = "delete from TblBangLuongCTy where MaLuong=N'" + txt1.Text + "'";
                Clipboard.SetText(delete);
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    comd = new SqlCommand(delete,cont);
                    comd.ExecuteNonQuery();
                    loaddatagirl("select * from TblBangLuongCTy", dataGridView1);
                    MessageBox.Show("Đã xoá");
                }
                ngatketNoi();
            }
            catch (Exception l)
            {
                MessageBox.Show(l.Message);
            }
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox4.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string insert = "insert into TblTangLuong values(N'" + comboBox1.Text + "',N'" + txt10.Text + "',N'" + txt11.Text + "',N'" + txt12.Text + "',N'" + textBox1.Text + "',N'" + txt15.Text + "',N'" + dateTimePicker6.Text + "',N'" + txt18.Text + "')";
                comd = new SqlCommand(insert,cont);
                comd.ExecuteNonQuery();
                
                string up = "update TblTTNVCoBan set MaLuong=N'" + txt15.Text + "' where MaNV='" + comboBox1.Text + "'";
                comd = new SqlCommand(up, cont);
                comd.ExecuteNonQuery();

                loaddatagirl("select * from TblTangLuong", dg2);
                MessageBox.Show("Đã thêm");
                ngatketNoi();
                comboBox1.Items.Clear();
                loadcombobox(comboBox1, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )", 2);
            }
            catch(Exception k)
            {
                MessageBox.Show(k.Message);
            }
          
          
   
        }
        public void loadtextbox(TextBox cb, string strselect)
        {
            ketNoi();
            comd = new SqlCommand(strselect, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cb.Text = read[0].ToString();
            }
            ngatketNoi();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 loadtextbox(txt10, "select HoTen from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'");
                 loadtextbox(txt11, "select GioiTinh from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'");
                 loadtextbox(txt12, "select ChucVu from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'");
                 loadtextbox(textBox1, "select MaLuong from TblCongKhoiDieuHanh where MaNV='" + comboBox1.Text + "'");
                 loadtextbox(txt15, "select MaLuongMoi from TblTangLuong where MaNV='" + comboBox1.Text + "'");
                 loadtextbox(txt18, "select LyDo from TblTangLuong where MaNV='" + comboBox1.Text + "'");
                ketNoi();
                comd = new SqlCommand("select NgayTang from TblTangLuong where MaNV='" + comboBox1.Text + "'", cont);
                read = comd.ExecuteReader();
                while (read.Read())
                {
                    dateTimePicker6.Text = read[0].ToString();
                }
                ngatketNoi();
              
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
                
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblTangLuong set HoTen=N'" + txt10.Text + "',GioiTinh=N'" + txt11.Text + "',ChucVu=N'" + txt12.Text + "',MaLuongCu='" + textBox1.Text + "',MaLuongMoi=N'" + txt15.Text + "',NgayTang='" + dateTimePicker6.Text + "',LyDo=N'" + txt18.Text + "' where MaNV=N'" + comboBox1.Text + "'";
                comd = new SqlCommand(update,cont);
                comd.ExecuteNonQuery();

                string up = "update TblTTNVCoBan set MaLuong=N'" + txt15.Text + "' where MaNV='" + comboBox1.Text + "'";
                comd = new SqlCommand(up, cont);
                comd.ExecuteNonQuery();

                loaddatagirl("select * from TblTangLuong", dg2);
                MessageBox.Show("Sửa thành công");
                ngatketNoi();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
          
            
        
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            ketNoi();
            string delete = "delete from TblTangLuong where MaNV=N'" + comboBox1.Text + "'";
            Clipboard.SetText(delete);
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                comd = new SqlCommand(delete, cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblTangLuong", dg2);
                comboBox1.Items.Clear();
                loadcombobox(comboBox1, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )", 2);
                MessageBox.Show("đã xoá");
            }
            ngatketNoi();
        }
    }
}
