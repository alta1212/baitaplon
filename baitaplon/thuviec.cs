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
    public partial class thuviec : Form
    {
        check ck = new check();
      

        public thuviec()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void thuviec_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from TblHoSoThuViec",dataGridView1);
            ck.loadcbb(cbbmaphong,1, "select * from Tblphongban");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
               
                if (ck.checkmatrung(txt1.Text, "TblHoSoThuViec", "MaNVTV"))
                {
                    string insert = "insert into TblHoSoThuViec values('" + cbbmaphong.Text + "',N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + dateTimePicker1.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + dateTimePicker2.Text + "',N'" + txt10.Text + "',N'" + txt11.Text + "')";
                    ck.thucthi(insert);
                    ck.loaddg("select * from TblHoSoThuViec", dataGridView1);
                    MessageBox.Show("Xong");
                    
                }
                else
                {
                    errorProvider1.SetError(txt1,"Mã nhân viên đã tồn tại");
                }
               
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                string update = "update TblHoSoThuViec set MaPhong=N'" + cbbmaphong.Text + "',HoTen=N'" + txt2.Text + "',NgaySinh=N'" + dateTimePicker1.Text + "',GioiTinh=N'" + txt4.Text + "',DiaChi=N'" + txt5.Text + "',TDHocVan=N'" + txt6.Text + "',HocHam=N'" + txt7.Text + "',ViTriThuViec=N'" + txt8.Text + "',NgayTV=N'" + dateTimePicker2.Text + "',ThangTV=N'" + txt10.Text + "',GhiChu=N'" + txt11.Text + "' where MaNVTV='" + txt1.Text + "'";
                ck.thucthi(update);
                ck.loaddg("select * from TblHoSoThuViec", dataGridView1);
                
                MessageBox.Show("Sửa thành công");
              
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
               
                string del = "delete from TblHoSoThuViec where MaNVTV='" + txt1.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ck.thucthi(del);
                    ck.loaddg("select * from TblHoSoThuViec",dataGridView1);
                }
               
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cbbmaphong.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txt6.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt7.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txt8.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            txt10.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            txt11.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
        }
    }
}
