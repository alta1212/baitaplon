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
    public partial class chedo : Form
    {
        public chedo()
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
            Clipboard.SetText(data);
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
        public void FillCombo(string sql, ComboBox com)
        {
            ketNoi();
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                com.Items.Add(read[0].ToString());
            }

            ngatketNoi();

        }
        private void chedo_Load(object sender, EventArgs e)
        {
            FillCombo("select manv from TblTTNVCoBan where manv in(select MaNV from TblCongKhoiDieuHanh where manv in (select manv from TblBangLuongCTy where manv not in (select manv from TblSoBH)))", cbbmnv);
            FillCombo("select manv from TblTTNVCoBan where manv in(select MaNV from TblCongKhoiDieuHanh where manv not in (select manv from TblThaiSan))", cbbmnv2);
            loaddatagirl("select * from TblSoBH", databaohiem);
            loaddatagirl("select * from TblThaiSan", datathaisan);
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
        void loaddatagirl(string sql,DataGridView d)
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter(sql, data);
            adap.Fill(dt);
            d.DataSource = dt;
            ngatketNoi();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();

                string insert = "insert into TblSoBH values(N'" + cbbmnv.Text + "',N'" + txtmaluong.Text + "',N'" + txtmabh.Text + "',N'" + datengaycap.Text + "',N'" + txtnoicap.Text + "',N'" + txtghichu.Text + "')";
                comd = new SqlCommand(insert,cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblSoBH", databaohiem);
                MessageBox.Show("Xong");
                ngatketNoi();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblSoBH set masobh=N'"+txtmabh.Text+"' ,ngaycapso='"+datengaycap.Value+"' ,noicapso='"+txtnoicap.Text+"' ,ghichu='"+txtghichu.Text+"' where manv=N'"+cbbmnv.Text+"'";
                Clipboard.SetText(update);
                comd = new SqlCommand(update,cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblSoBH", databaohiem);
                MessageBox.Show("Xong");
                ngatketNoi();
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
                    ketNoi();
                    comd = new SqlCommand(sql, cont);
                    comd.ExecuteNonQuery();
                    ngatketNoi();
                    MessageBox.Show("Đã xoá");
                    loaddatagirl("select * from TblSoBH", databaohiem);
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
                txtmaluong.Text = databaohiem.Rows[i].Cells[1].Value.ToString();
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
                ketNoi();
                string insert = "insert into TblThaiSan values(N'" + txtmabp.Text + "',N'" + txtmaphong.Text + "',N'" + cbbmnv2.Text + "',N'" + txthoten.Text + "',N'" + datengaysinh.Text + "',N'" + datengayves.Text + "',N'" + datengayve.Text + "',N'" + datengaydilam.Text + "',N'" + txttrocapct.Text + "',N'" + txtghichu2.Text + "')";
                comd = new SqlCommand(insert,cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblThaiSan", datathaisan);
                MessageBox.Show("xong");
                ngatketNoi();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void cbbmnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from TblThaiSan where manv=N'"+cbbmnv.Text+"'";
            ketNoi();
           

            ngatketNoi();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá nó?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
              
            try
            {
                ketNoi();
                string insert = "update TblThaiSan set mabophan=N'"+txtmabp.Text+"',maphong=N'"+txtmaphong.Text+"',hoten=N'"+txthoten.Text+"', ngaysinh='"+datengaysinh.Value+"' ,ngayvesom='"+datengayve.Value+"',ngaynghisinh='"+ datengayve.Value+"',ngaydilam='"+datengaydilam.Value+"',trocapcongty='"+txtnoicap.Text+"',ghichu='"+txtghichu2.Text+"'";
                comd = new SqlCommand(insert, cont);
                comd.ExecuteNonQuery();
                loaddatagirl("select * from TblThaiSan", datathaisan);
                MessageBox.Show("xong");
                ngatketNoi();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
            }
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ketNoi();
            string sql = "delete TblThaiSan where manv='"+cbbmnv.Text+"'";
            comd = new SqlCommand(sql, cont);
            comd.ExecuteNonQuery();
            loaddatagirl("select * from TblThaiSan", datathaisan);
            MessageBox.Show("xong");
            ngatketNoi();
        }
    }
}
