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
        check ck = new check();
     
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
            if (ck.checkmatrung(txt1.Text, "TblBangLuongCTy", "MaLuong"))
                if (txt1.Text.Trim() != "")
                    try
                    {
                        errorProvider1.Clear();
                        string insert = "insert into TblBangLuongCTy values(N'" + txt1.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + dateTimePicker1.Text + "',N'" + txt6.Text + "',N'" + dateTimePicker2.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + dateTimePicker3.Text + "',N'" + txt9.Text + "')";
                        ck.thucthi(insert);
                   
                        ck.loaddg("select * from TblBangLuongCTy", dataGridView1);
                     
                    }
                    catch
                    {
                        MessageBox.Show("dữ liệu đầu vào không hợp lệ");
                    }
                else
                    MessageBox.Show("dữ liệu đầu vào không hợp lệ");

            else
                errorProvider1.SetError(txt1, "Mã lương đã tồn tại");
        }


        private void bangluong_Load(object sender, EventArgs e)
        {
  
            ck.loaddg("select * from TblBangLuongCTy", dataGridView1);
            ck.loaddg("select * from TblTangLuong", dg2);
            ck.loadcbb(comboBox1,2, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )");
            ck.loadcbb(cbbmlc,0, "select MaLuong from TblbangLuongcty");
            ck.loadcbb(cbbmlm, 0, "select MaLuong from TblbangLuongcty");
        }

       

        private void xuiButton9_Click(object sender, EventArgs e)
        {
            try
            {
              
                string update = "update TblBangLuongCTy set LCB=N'" + txt4.Text + "',PCChucVu=N'" + txt5.Text + "',NgayNhap='" + dateTimePicker1.Text + "',LCBMoi=N'" + txt6.Text + "',NgaySua=N'" + dateTimePicker2.Text + "',LyDo=N'" + txt7.Text + "',PCCVuMoi='" + txt8.Text + "',NgaySuaPC=N'" + dateTimePicker3.Text + "',GhiChu=N'" + txt9.Text + "' where MaLuong=N'" + txt1.Text + "'";
                ck.thucthi(update);
                ck.loaddg("select * from TblBangLuongCTy", dataGridView1);
            
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
                cbbmlc.Text = dg2.Rows[i].Cells[4].Value.ToString();
                cbbmlm.Text = dg2.Rows[i].Cells[5].Value.ToString();
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
               
                string delete = "delete from TblBangLuongCTy where MaLuong=N'" + txt1.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ck.thucthi(delete);
                    ck.loaddg("select * from TblBangLuongCTy", dataGridView1);
                 
                }
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
            if(ck.checkmatrung(comboBox1.Text, "TblTangLuong","Manv"))
            try
            {
                    errorProvider1.Clear();
               
                string insert = "insert into TblTangLuong values(N'" + comboBox1.Text + "',N'" + txt10.Text + "',N'" + txt11.Text + "',N'" + txt12.Text + "',N'" + cbbmlc.Text + "',N'" + cbbmlm.Text + "',N'" + dateTimePicker6.Text + "',N'" + txt18.Text + "')";
                    ck.thucthi(insert);
                
                string up = "update TblTTNVCoBan set MaLuong=N'" + cbbmlm.Text + "' where MaNV='" + comboBox1.Text + "'";
                    ck.thucthi(up);

                ck.loaddg("select * from TblTangLuong", dg2);
           
              
                comboBox1.Items.Clear();
                ck.loadcbb(comboBox1,2, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )");
            }
            catch(Exception k)
            {
                MessageBox.Show(k.Message);
            }
          else
            {
                errorProvider1.SetError(comboBox1, "Mã nhân viên đã tồn tại trong bảng tăng lương");
            }    
          
   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 ck.loadtextbox(txt10, "select HoTen from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'",0);
                 ck.loadtextbox(txt11, "select GioiTinh from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'",0);
                 ck.loadtextbox(txt12, "select ChucVu from TblTTNVCoBan where MaNV='" + comboBox1.Text + "'",0);
                 ck.loadtxtcbb(cbbmlc, "select MaLuong from TblCongKhoiDieuHanh where MaNV='" + comboBox1.Text + "'",0);
                 ck.loadtxtcbb(cbbmlm, "select MaLuongMoi from TblTangLuong where MaNV='" + comboBox1.Text + "'",0);
                 ck.loadtextbox(txt18, "select LyDo from TblTangLuong where MaNV='" + comboBox1.Text + "'",0);
                 ck.setdate(dateTimePicker6, "select NgayTang from TblTangLuong where MaNV='" + comboBox1.Text + "'");
              
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
               
                string update = "update TblTangLuong set HoTen=N'" + txt10.Text + "',GioiTinh=N'" + txt11.Text + "',ChucVu=N'" + txt12.Text + "',cbbmlc='" + cbbmlc.Text + "',MaLuongMoi=N'" + cbbmlm.Text + "',NgayTang='" + dateTimePicker6.Text + "',LyDo=N'" + txt18.Text + "' where MaNV=N'" + comboBox1.Text + "'";
                ck.thucthi(update);

                string up = "update TblTTNVCoBan set MaLuong=N'" + cbbmlm.Text + "' where MaNV='" + comboBox1.Text + "'";
                ck.thucthi(up);
                ck.loaddg("select * from TblTangLuong", dg2);
               
             
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
          
            
        
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
           
            string delete = "delete from TblTangLuong where MaNV=N'" + comboBox1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ck.thucthi(delete);
                ck.loaddg("select * from TblTangLuong", dg2);
                comboBox1.Items.Clear();
                ck.loadcbb(comboBox1,2, "select * from TblTTNVCoBan where MaNV not in (select MaNV from TblTangLuong )");
                MessageBox.Show("đã xoá");
            }
          
        }

        private void txt1_Leave(object sender, EventArgs e)
        {
            if (!ck.checkmatrung(txt1.Text, "TblBangLuongCTy", "MaLuong"))
            {
                errorProvider1.SetError(txt1, "Mã nhân viên đã tồn tại");

            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
