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
        string quyen=" ";

        public void getdata(string per)
        {
            quyen = per;
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
            d.getdata("Data Source=(local);Initial Catalog=QLNS;Integrated Security=True", quyen);
            d.ShowDialog();
            }
           
        }
        
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            doipass l = new doipass();
            l.getdata("Data Source=(local);Initial Catalog=QLNS;Integrated Security=True", Properties.Settings.Default.id);
            l.ShowDialog();
                
        }
    }
}
