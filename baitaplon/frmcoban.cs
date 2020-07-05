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
    public partial class frmcoban : Form
    {
      

        public frmcoban()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
      
        check ck = new check();
        //public void getdata(string chuoi)
        //{
        //    data = chuoi;
    
        //}
        //void ketNoi()
        //{
        //    cont = new SqlConnection(data);
        //    // Mở
        //    if (cont.State == ConnectionState.Closed)
        //        cont.Open();
        //}
        //void ngatketNoi()
        //{
        //    cont = new SqlConnection(data);
        //    // Đóng
        //    if (cont.State == ConnectionState.Open)
        //        cont.Close();
        //}

        private void frmcoban_Load(object sender, EventArgs e)
        {
            ck.loadcbb(cbbmbp,0, "SELECT mabophan FROM TblBoPhan");
            ck.loadcbb(cbbluong, 0, "select MaLuong from TblBangLuongCTy");
            ck.loaddg("select * from TblTTNVCoBan", dataGridView1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            if(ck.checkmatrung(txtmnv.Text, "TblTTNVCoBan","manv"))
            {
                errorProvider1.Clear();
                try
                { 
                   
                    string insert = "insert into TblTTNVCoBan values(N'" + cbbmbp.Text + "',N'" + cbbmaphong.Text + "',N'" + txtmnv.Text + "',N'" + txthoten.Text + "',N'" + cbbluong.Text + "',N'" + datebirth.Text + "',N'" + cbbgioitinh.Text + "',N'" + txthonnhan.Text + "',N'" + txtcmt.Text + "',N'" + txtnoicap.Text + "',N'" + txtchucvu.Text + "',N'" + txthd.Text + "',N'" + txttime.Text + "',N'" + datengayvao.Text + "',N'" + datengayra.Text + "',N'" + txtghichu.Text + "')";

                    ck.thucthi(insert);
                        ck.loaddg("select * from TblTTNVCoBan", dataGridView1);
                        MessageBox.Show("Đã thêm");
                    foreach (Control ctr in this.groupBox1.Controls)
                    {
                        if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                        {
                            ctr.Text = "";
                        }
                    }
                  
                }
                catch(Exception p)
                {
                    MessageBox.Show(p.Message);
                }
            }    
            else
            {
                errorProvider1.SetError(txtmnv, "Mã nhân viên đã tồn tại");
            } 
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
   

        }
      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = string.Format("select p.MaPhong from TblBoPhan b,TblPhongBan p where b.MaBoPhan=p.MaBoPhan and p.MaBoPhan=N'{0}'",cbbmbp.Text);
            ck.loadcbb(cbbmaphong,0,sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                cbbmbp.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                cbbmaphong.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtmnv.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                txthoten.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                cbbluong.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                datebirth.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                cbbgioitinh.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                txthonnhan.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtcmt.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtnoicap.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtchucvu.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
                txthd.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
                txttime.Text= dataGridView1.Rows[i].Cells[12].Value.ToString();
                datengayvao.Text = dataGridView1.Rows[i].Cells[13].Value.ToString();
                datengayra.Text = dataGridView1.Rows[i].Cells[14].Value.ToString();
                txtghichu.Text= dataGridView1.Rows[i].Cells[15].Value.ToString();
               
                txtmnv.Enabled = false;
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
             
                string sql = string.Format("update TblTTNVCoBan set MaBoPhan=N'" + cbbmbp.Text + "',MaPhong=N'" + cbbmaphong.Text + "',HoTen=N'" + txthoten.Text + "',MaLuong=N'" + cbbluong.Text + "'," + "NgaySinh='" + datebirth.Value + "',GioiTinh=N'" + cbbgioitinh.Text + "',TTHonNhan=N'" + txthonnhan + "',CMTND=N'" + txtcmt.Text + "',NoiCap=N'" + txtnoicap.Text + "',ChucVu=N'"+ txtchucvu.Text+ "',LoaiHD=N'"+txthd.Text+"'," + "ThoiGian=N'"+txttime.Text+"',NgayKy='"+datengayvao.Value+"',NgayHetHan='"+datengayra.Value+"',GhiChu=N'"+txtghichu.Text+"' where MaNV=N'"+txtmnv.Text+"'");
                ck.thucthi(sql);
                ck.loaddg("select * from TblTTNVCoBan", dataGridView1);
                MessageBox.Show("Xong");
    
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "delete from TblTTNVCoBan where MaBoPhan=N'"+txtmnv.Text+"'";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ck.thucthi(sql) ;
                    MessageBox.Show("Đã xoá");
                    dataGridView1.Refresh();
                }
                catch 
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xoá");
                }

            }
          
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            txtmnv.Enabled = true;
        }

        private void txtmnv_Leave(object sender, EventArgs e)
        {
            if (!ck.checkmatrung(txtmnv.Text, "TblTTNVCoBan","manv"))   
            {
                errorProvider1.SetError(txtmnv, "Mã nhân viên đã tồn tại");

            }
            else
            {
                errorProvider1.Clear();
            }    
        }
    }
}
