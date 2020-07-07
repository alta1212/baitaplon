using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class chedo : Form
    {
        public chedo()
        {
            InitializeComponent();
        }
        check ck = new check();
     
        private void chedo_Load(object sender, EventArgs e)
        {
            ck.loadcbb(comboBox1, 0, "select * from TblBangLuongCTy");
            ck.loadcbb(cbbmnv,0, "select manv from TblTTNVCoBan where manv in(select MaNV from TblCongKhoiDieuHanh where manv in (select manv from TblBangLuongCTy where manv not in (select manv from TblSoBH)))");
            ck.loadcbb(cbbmnv2,0, "select manv from TblTTNVCoBan where manv in(select MaNV from TblCongKhoiDieuHanh where manv not in (select manv from TblThaiSan))");
            ck.loaddg("select * from TblSoBH", databaohiem);
            ck.loaddg("select * from TblThaiSan", datathaisan);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.grup1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ck.checkmatrung(cbbmnv.Text, "TblSoBH", "MaNV"))
                try
                {
                    errorProvider1.Clear();
                    string insert = "insert into TblSoBH values(N'" + cbbmnv.Text + "',N'" + comboBox1.Text + "',N'" + txtmabh.Text + "',N'" + datengaycap.Text + "',N'" + txtnoicap.Text + "',N'" + txtghichu.Text + "')";
                    ck.thucthi(insert);
                    ck.loaddg("select * from TblSoBH", databaohiem);
              

                }
                catch
                {
                    MessageBox.Show("dữ liệu đầu vào không đúng");
                }
            else
            {
                errorProvider1.SetError(cbbmnv, "Mã nhân viên đã tồn tại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string update = "update TblSoBH set masobh=N'" + txtmabh.Text + "' ,ngaycapso='" + datengaycap.Value + "' ,noicapso='" + txtnoicap.Text + "' ,ghichu='" + txtghichu.Text + "' where manv=N'" + cbbmnv.Text + "'";
                ck.thucthi(update);
                ck.loaddg("select * from TblSoBH", databaohiem);
            

            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "delete from TblSoBH where manv=N'" + cbbmnv.Text + "'";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ck.thucthi(sql);

                    MessageBox.Show("Đã xoá");
                    ck.loaddg("select * from TblSoBH", databaohiem);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xoá");
                }

            }
        }

        private void databaohiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                cbbmnv.Text = databaohiem.Rows[i].Cells[0].Value.ToString();
                comboBox1.Text = databaohiem.Rows[i].Cells[1].Value.ToString();
                txtmabh.Text = databaohiem.Rows[i].Cells[2].Value.ToString();
                datengaycap.Text = databaohiem.Rows[i].Cells[3].Value.ToString();
                txtnoicap.Text = databaohiem.Rows[i].Cells[4].Value.ToString();
                txtghichu.Text = databaohiem.Rows[i].Cells[5].Value.ToString();

                cbbmnv.Enabled = false;
            }
            catch
            { }
        }

        private void databaohiem_Leave(object sender, EventArgs e)
        {
            cbbmnv.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.grts.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {

                string insert = "insert into TblThaiSan values(N'" + txtmabp.Text + "',N'" + txtmaphong.Text + "',N'" + cbbmnv2.Text + "',N'" + txthoten.Text + "',N'" + datengaysinh.Text + "',N'" + datengayves.Text + "',N'" + datengayve.Text + "',N'" + datengaydilam.Text + "',N'" + txttrocapct.Text + "',N'" + txtghichu2.Text + "')";
                ck.thucthi(insert);
                ck.loaddg("select * from TblThaiSan", datathaisan);
           

            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void cbbmnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ck.loadtextbox(txtmabh, "select * from TblSoBH where MaNV=N'" + comboBox1.Text + "'", 2);
            ck.loadtxtcbb(comboBox1, "select * from TblTTNVCoBan where MaNV=N'" + comboBox1.Text + "'", 4);
            ck.setdate(datengaycap, "select ngaycapso from TblSoBH where MaNV=N'" + comboBox1.Text + "'");
            ck.loadtextbox(txtnoicap, "select * from TblSoBH where MaNV=N'" + comboBox1.Text + "'", 4);
            ck.loadtextbox(txtghichu, "select * from TblSoBH where MaNV=N'" + comboBox1.Text + "'", 5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                try
                {

                    string insert = "update TblThaiSan set mabophan=N'" + txtmabp.Text + "',maphong=N'" + txtmaphong.Text + "',hoten=N'" + txthoten.Text + "', ngaysinh='" + datengaysinh.Value + "' ,ngayvesom='" + datengayve.Value + "',ngaynghisinh='" + datengayve.Value + "',ngaydilam='" + datengaydilam.Value + "',trocapcongty='" + txtnoicap.Text + "',ghichu='" + txtghichu2.Text + "'";
                    ck.thucthi(insert);
                    ck.loaddg("select * from TblThaiSan", datathaisan);
             

                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng");
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

            string sql = "delete TblThaiSan where manv='" + cbbmnv.Text + "'";
            ck.thucthi(sql);
            ck.loaddg("select * from TblThaiSan", datathaisan);
            

        }
    }
}
