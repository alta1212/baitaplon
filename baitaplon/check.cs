using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    class check
    { 
        string data = Properties.Settings.Default.data;
        SqlConnection cont;
        SqlCommand comd;
        SqlDataReader read;
        DataTable dt;
        SqlDataAdapter adap;
        string per= Properties.Settings.Default.per;


        public void report()
        {
            ketNoi();

            ngatketNoi();
        }
        public void loadtextbox(TextBox cb, string sql,byte chiso)
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


       public void ketNoi()
        {
           
            cont = new SqlConnection(data);
          
            // Mở
            if (cont.State == ConnectionState.Closed)
                cont.Open();
        }
      public  void ngatketNoi()
        {
            cont = new SqlConnection(data);
            // Đóng
            if (cont.State == ConnectionState.Open)
                cont.Close();
        }
        public bool checkmatrung(string ma,string tb,string ss)
        {
            ketNoi();
            string sql = string.Format("select * from {0} where {2} ='{1}'",tb,ma,ss);
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            ngatketNoi();
            
            if (read.Read())
            {
                return false;
            }    
            return true;
        }
        public int getluong(string maluong)
        {  
              ketNoi();
            int luong=0;
            string sql = string.Format("select lcb from TblBangLuongCTy where MaLuong ='{0}'",maluong);
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            if (read.Read())
            {
                luong =int.Parse(read[0].ToString());
            }
            ngatketNoi();
            return luong;
        }
        public void setdate(DateTimePicker dt,string sql)
        {
            ketNoi();
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                dt.Text = read[0].ToString();
            }
            ngatketNoi();
        }

        public void loadtxtcbb(ComboBox cb,string sl,int chiso)
        {

            ketNoi();
            comd = new SqlCommand(sl, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cb.Text = read[chiso].ToString();
            }
            ngatketNoi();

        }
        public void loadcbb(ComboBox cb,int index,string sql)
        {
            ketNoi();
            comd = new SqlCommand(sql, cont);
            read = comd.ExecuteReader();
            while (read.Read())
            {
                cb.Items.Add(read[index].ToString());
            }

            ngatketNoi();
        }
        public void loaddg(string sql,DataGridView d)
        {
            
            ketNoi();
            dt = new DataTable();
            adap = new SqlDataAdapter(sql, data);
            adap.Fill(dt);
            d.DataSource = dt;
            ngatketNoi();
        }
        public void thucthi(string sqlcode)
        {
            if(per=="nguoidung")
            {
                MessageBox.Show("Bạn không có quyền thay đổi dữ liệu");
            }   
            else
            {
                ketNoi();
                comd = new SqlCommand(sqlcode, cont);
                comd.ExecuteNonQuery();
                ngatketNoi();
                MessageBox.Show("xong");
            }    
        
        }
    }
}
