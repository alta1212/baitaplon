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
     
        check ck = new check();
     

     
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void i4canhan_Load(object sender, EventArgs e)
        {
            ck.loaddg("select * from TblTTCaNhan", dataGridView1);
            ck.loadcbb(cbbmnv,2, "select * from TblTTNVCoBan");
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
                ck.thucthi(sql) ;

                foreach (Control ctr in this.groupBox1.Controls)
                {
                    if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                    {
                        ctr.Text = "";
                    }
                }
                ck.loaddg("select * from TblTTCaNhan", dataGridView1);
                MessageBox.Show("xong");
               
                
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
                    ck.thucthi(sql);
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
