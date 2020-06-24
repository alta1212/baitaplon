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
    public partial class qltklist : Form
    {
        string data;
        string quyen;
        string id;
        public void getdata(string chuoi,string per,string tendn)
        {
            quyen = per;
            data = chuoi;
            id = tendn;
        }
        public qltklist()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if(quyen=="nguoidung")
            {
                MessageBox.Show("Bạn đang đăng nhập với quyền người dùng,không thể quản lý tài khoản", "Quyền truy cập bị từ chối",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
            dangky d = new dangky();
            d.getdata(data,quyen);
            d.ShowDialog();
            }
           
        }
        
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            doipass l = new doipass();
            l.getdata("Data Source=(local);Initial Catalog=qlns;Persist Security Info=True;User ID=sa;Password=123",id);
            l.ShowDialog();
                
        }
    }
}
