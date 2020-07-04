﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaplon
{
    class check
    {
        string data = "Data Source=(local);Initial Catalog=QLNS;Integrated Security=True";
        SqlConnection cont;
        SqlCommand comd;
        SqlDataReader read;
        DataTable dt;
        SqlDataAdapter adap;


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
    }
}