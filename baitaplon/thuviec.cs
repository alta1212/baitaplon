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
    public partial class thuviec : Form
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
            loaddt();
        }
        void loadcbb()
        {
            ketNoi();
            comd = new SqlCommand("select * from Tblphongban", cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cbbmaphong.Items.Add(read[1].ToString());
            }
            ngatketNoi();
        }
        void loaddt()
        {
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter("select * from TblHoSoThuViec", data);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            ngatketNoi();
        }
    }
}
