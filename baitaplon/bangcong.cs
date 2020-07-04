﻿using System;
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
        check ck = new check();
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

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            try
            {
          if (ck.checkmatrung(cbbmnv1.Text, "TblBangCongThuViec", "MaNVTV"))
            {
                errorProvider1.Clear();
                try
                {
                    ketNoi();
                    string insert = "insert into TblBangCongThuViec values(N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + cbbmnv1.Text + "',N'" + txt3.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + textBox3.Text + "',N'" + txt9.Text + "')";
                    comd = new SqlCommand(insert, cont);
                    read = comd.ExecuteReader();
                        ck.loaddg("select * from TblBangCongThuViec", dataGridView1);
                    MessageBox.Show("Xong");
                    ngatketNoi();
                }
                catch (Exception ll)
                {
                    MessageBox.Show(ll.Message);
                }
            }
            else
            {
               errorProvider1.SetError(cbbmnv1, "Mã nhân viên đã tồn tại");
            }
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
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
            ck.loaddg("select * from TblBangCongThuViec", dataGridView1);
            ck.loaddg("select * from TblCongKhoiDieuHanh", dataGridView2);
            ck.loadcbb(cbbmnv1,0, "select MaNVTV from TblHoSoThuViec");
            ck.loadcbb(cbbtenphong, 0, "SELECT TenPhong FROM TblPhongBan");
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblBangCongThuViec set TenBoPhan=N'" + txt1.Text + "',TenPhong=N'" + txt2.Text + "',LuongTViec=N'" + txt3.Text + "',Thang=N'" + txt4.Text + "',Nam='" + txt5.Text + "',SoNgayCong=N'" + txt6.Text + "',SoNgayNghi=N'" + txt7.Text + "',SoGioLamThem=N'" + txt8.Text + "',Luong=N'" + textBox3.Text + "',GhiChu='" + txt9.Text + "' where MaNVTV=N'" + cbbmnv1.Text + "'";
                comd = new SqlCommand(update,cont);
                comd.ExecuteNonQuery();
                ck.loaddg("select * from TblBangCongThuViec", dataGridView1);
                MessageBox.Show("Sửa thành công");
                ngatketNoi();
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
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
                ketNoi();
                string delete = "delete from TblBangCongThuViec where MaNVTV=N'" + cbbmnv1.Text + "'";
                comd = new SqlCommand(delete, cont);
                comd.ExecuteNonQuery();
                MessageBox.Show("Xong");
                ck.loaddg("select * from TblBangCongThuViec", dataGridView1);
                ngatketNoi();
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

        private void cbbmnv1_SelectedIndexChanged(object sender, EventArgs e)
        {
           loadtextbox(txt2, "select * from TblPhongBan b,TblHoSoThuViec a where a.MaPhong=b.MaPhong and MaNVTV='" +cbbmnv1.Text + "'", 2);
           loadtextbox(txt1, "select * from TblBoPhan,TblPhongBan where TblPhongBan.MaBoPhan=TblBoPhan.MaBoPhan and TenPhong=N'" + txt2.Text + "'", 1);
           loadtextbox(txt3, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 3);
           loadtextbox(txt4, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 4);
           loadtextbox(txt5, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 5);
           loadtextbox(txt6, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 6);
           loadtextbox(txt7, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 7);
           loadtextbox(txt8, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 8);
           loadtextbox(textBox3, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 9);
           loadtextbox(txt9, "select * from TblBangCongThuViec where MaNVTV='" +cbbmnv1.Text + "'", 10);
        }
        void loadtextbox(TextBox cb, string sql,byte chiso)
        {
            ketNoi();
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cb.Text = read[chiso].ToString();
            }
            ngatketNoi();
        }

        private void cbbmnv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtextbox(txt50, "select * from TblTTNVCoBan where MaNV='" + cbbmnv2.Text + "'", 4);
            loadtextbox(txt10, "select * from TblBangLuongCTy l where l.MaLuong='" + txt50.Text + "'", 1);
            loadtextbox(txt11, "select * from TblBangLuongCTy l where l.MaLuong='" + txt50.Text + "'", 2);
            //loadtextbox(txt10, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 4);
            loadtextbox(txt53, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 2);
            //loadtextbox(txt51, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 3);
            // loadtextbox(txt11, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 5);
            loadtextbox(txt12, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 6);
            loadtextbox(textBox1, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 7);
            loadtextbox(textBox2, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 8);
            loadtextbox(txt13, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 9);
            loadtextbox(txt14, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 10);
            loadtextbox(txt15, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 11);
            loadtextbox(txt16, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 12);
            loadtextbox(txt17, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 13);
            loadtextbox(txt52, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 14);
            loadtextbox(txt18, "select * from TblCongKhoiDieuHanh where MaNV='" + cbbmnv2.Text + "'", 15);
        }

        private void cbbtenphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcbb(cbbmnv2, "select MaNV from TblCongKhoiDieuHanh where TenPhong=(select TenPhong from TblPhongBan a, TblTTNVCoBan b where a.MaPhong=b.MaPhong and a.TenPhong=N'" + cbbtenphong.Text + "' group by TenPhong)");
            for(int i =0; i<groupBox4.Controls.Count;i++)
            {
                if (groupBox4.Controls[i] is TextBox)
                    groupBox4.Controls[i].ResetText();
            }
            cbbmnv2.Text = "";
            
        }

        private void xuiButton11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton8_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox4.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton9_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblCongKhoiDieuHanh set  MaLuong=N'" + txt50.Text + "',TenPhong=N'" + cbbtenphong.Text + "', HoTen=N'" + txt53.Text + "',LCB=N'" + txt10.Text + "',PCChucVu=N'" + txt11.Text + "',PCapKhac=N'" + txt12.Text + "',Thuong=N'" + textBox1.Text + "',KyLuat='" + textBox2.Text + "',Thang=N'" + txt13.Text + "',Nam='" + txt14.Text + "',SoNgayCongThang=N'" + txt15.Text + "',SoNgayNghi=N'" + txt16.Text + "',SoGioLamThem=N'" + txt17.Text + "',Luong=N'" + txt52.Text + "',GhiChu='" + txt18.Text + "' where MaNV=N'" + cbbmnv2.Text + "'";
                comd = new SqlCommand(update, cont);
                comd.ExecuteNonQuery();
                ck.loaddg("select * from TblCongKhoiDieuHanh", dataGridView2);
                MessageBox.Show("Sửa thành công");
                ngatketNoi();
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void xuiButton7_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string delete = "delete from TblCongKhoiDieuHanh where MaNV=N'" + cbbmnv2.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    comd = new SqlCommand(delete,cont);
                    comd.ExecuteNonQuery();
                    ck.loaddg("select * from TblCongKhoiDieuHanh", dataGridView2);
                }
                ngatketNoi();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void xuiButton10_Click(object sender, EventArgs e)
        {
            int lcb = Convert.ToInt32(txt10.Text);
            int pc = Convert.ToInt32(txt11.Text);
            int pck = Convert.ToInt32(txt12.Text);
            int nc = Convert.ToInt32(txt15.Text);
            int lt = Convert.ToInt32(txt17.Text);
            int th = Convert.ToInt32(textBox1.Text);
            int kl = Convert.ToInt32(textBox2.Text);

            float luong = ((lcb / 26) * nc + (lt * 40000) + pc + pck + th - kl);
            txt52.Text = luong.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cbbmnv2.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            txt10.Text = dataGridView2.Rows[i].Cells[4].Value.ToString();
            txt53.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
            txt50.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
            cbbtenphong.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            txt11.Text = dataGridView2.Rows[i].Cells[5].Value.ToString();
            txt12.Text = dataGridView2.Rows[i].Cells[6].Value.ToString();
            textBox1.Text = dataGridView2.Rows[i].Cells[7].Value.ToString();
            textBox2.Text = dataGridView2.Rows[i].Cells[8].Value.ToString();
            txt13.Text = dataGridView2.Rows[i].Cells[9].Value.ToString();
            txt14.Text = dataGridView2.Rows[i].Cells[10].Value.ToString();
            txt15.Text = dataGridView2.Rows[i].Cells[11].Value.ToString();
            txt16.Text = dataGridView2.Rows[i].Cells[12].Value.ToString();
            txt17.Text = dataGridView2.Rows[i].Cells[13].Value.ToString();
            txt52.Text = dataGridView2.Rows[i].Cells[14].Value.ToString();
            txt18.Text = dataGridView2.Rows[i].Cells[15].Value.ToString();
        }
    }
}
