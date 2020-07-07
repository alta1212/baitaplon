using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    public partial class thoiviec : Form
    {
        check ck = new check();
        public thoiviec()
        {
            InitializeComponent();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            ck.thucthi("delete from TblNVThoiViec where manv =N'"+comboBox1.Text+"'");
            ck.loaddg("select * from TblNVThoiViec", dataGridView1);
            MessageBox.Show("xong");
        }

        private void thoiviec_Load(object sender, EventArgs e)
        {
            ck.loadcbb(comboBox1,0, "select manv from TblTTNVCoBan");
            ck.loaddg("select * from TblNVThoiViec", dataGridView1);

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string them = string.Format("insert into TblNVThoiViec values ('{0}','{1}','{2}','{3}')",comboBox1.Text,textBox1.Text,dateTimePicker1.Value,richTextBox1.Text);
                string delete= string.Format("delete TblTTNVCoBan where manv =N'{0}'",comboBox1.Text);
                ck.thucthi(them);
                ck.thucthi(delete);
                ck.loaddg("select * from TblNVThoiViec", dataGridView1);
                foreach (Control ctr in this.groupBox1.Controls)
                {
                    if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                    {
                        ctr.Text = "";
                    }
                }
                MessageBox.Show("Xong");
            }
            catch
            {

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ck.loadtextbox(textBox1, "select hoten from TblTTNVCoBan where manv =N'"+comboBox1.Text+"'",0);
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            ck.thucthi(string.Format("update TblNVThoiViec set tennv=N'{0}',ngaythoiviec=N'{1}',lydo=N'{2}' where manv=N'{3}'", textBox1.Text, dateTimePicker1.Value, richTextBox1.Text, comboBox1.Text)) ;
            ck.loaddg("select * from TblNVThoiViec", dataGridView1);
            MessageBox.Show("xong");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   int i = e.RowIndex;
            comboBox1.Text=dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Value =DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            richTextBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }
    }
}
