using CrystalDecisions.CrystalReports.Engine;
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
    public partial class formthongkenv : Form
    {

     
        formthongke thk = new formthongke();
        check ck = new check();
        string sql = "select nv.manv,nv.hoten,nv.ChucVu,nv.NgaySinh,nv.GhiChu,pb.MaPhong,pb.TenPhong from TblTTNVCoBan nv inner join TblPhongBan pb on nv.MaBoPhan = pb.MaBoPhan where pb.MaBoPhan = @MaBoPhan";

        public formthongkenv()
        {
            InitializeComponent();
        }

        private void xuiRadio3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            sql = "";
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (xuiRadio2.Checked)
            {
                 ck.loadrpnvct(sql, comboBox1.Text);  
                 formthongke k = new formthongke();
                 k.ShowDialog();
            }    
            else if (xuiRadio1.Checked)
            {       
                nvtv n = new nvtv();
                n.ShowDialog();
            }    
              

        }

        private void xuiRadio2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            sql = "select nv.manv,nv.hoten,nv.ChucVu,nv.NgaySinh,nv.GhiChu,pb.MaPhong,pb.TenPhong from TblTTNVCoBan nv inner join TblPhongBan pb on nv.MaBoPhan = pb.MaBoPhan where pb.MaBoPhan = @MaBoPhan";
 
        }


        private void xuiRadio1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void formthongkenv_Load(object sender, EventArgs e)
        {
            ck.loadcbb(comboBox1, 0, "select mabophan from TblPhongBan");
        }
    }
}
