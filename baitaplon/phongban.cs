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
    public partial class phongban : Form
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

        public phongban()
        {
            InitializeComponent();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void phongban_Load(object sender, EventArgs e)
        {
            loaddta("select * from tblphongban");
            loadcombobox(comboBox1, "select * from TblBoPhan", 0);
        }
        void loaddta(string k)
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter(k, data);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            ngatketNoi();
        }
       void loadcombobox(ComboBox cb, string strselect, byte chiso)
        {
            ketNoi();
            comd = new SqlCommand(strselect, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[chiso].ToString());
            }
            ngatketNoi();
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

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                    string insert = "insert into TblPhongBan values('" + comboBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox5.Text + "')";
                    comd = new SqlCommand(insert, cont);
                    comd.ExecuteNonQuery();
                    loaddta("select * from tblphongban");
                MessageBox.Show("Xong");
                ngatketNoi();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string update = "update TblPhongBan set MaBoPhan=N'" + comboBox1.Text + "',TenPhong=N'" + textBox3.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox5.Text + "' where MaPhong=N'" + textBox2.Text.Trim() + "'";
                Clipboard.SetText(update);
                comd = new SqlCommand(update, cont);
                comd.ExecuteNonQuery();
                loaddta("select * from tblphongban");
                MessageBox.Show("Sửa thành công");
                ngatketNoi();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ketNoi();
                string del = "delete from TblPhongBan where MaPhong=N'" + textBox2.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    comd = new SqlCommand(del, cont);
                    comd.ExecuteNonQuery();
                    loaddta("select * from tblphongban");
                    MessageBox.Show("xoá thành công");
                }
                ngatketNoi();
            }
            catch(Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            comboBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
    }
}