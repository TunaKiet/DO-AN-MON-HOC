using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offical_winform_quanlybaidang
{
    public partial class FormDangNhap : Form
    {
        List<TaiKhoan> listTaiKhoan = DsTaiKhoan.Instance.ListTaiKhoan;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void lbTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cktbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(cktbShowPass.Checked)
            {
                txbMatKhau.UseSystemPasswordChar = false;
            }
            else
                txbMatKhau.UseSystemPasswordChar = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (Kiemtradangnhap(txbTaiKhoan.Text, txbMatKhau.Text))
            {
                FormQuanLy f = new FormQuanLy();
                f.Show();
                this.Hide();
                f.DangXuat += F_DangXuat; ;

                foreach (var item in groupBox1.Controls)
                {
                    TextBox item1 = item as TextBox;
                    if (item1 != null)
                        item1.Clear();
                }
                MessageBox.Show("Chào mừng bạn đến với phần mềm quản lý bài đăng!", " Thành công! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTaiKhoan.Focus();
            }    
            
        }

        private void F_DangXuat(object sender, EventArgs e)
        {
            (sender as FormQuanLy).isThoat = false;
            (sender as FormQuanLy).Close();
            this.Show();
            cktbShowPass.Checked = false;
        }

        bool Kiemtradangnhap(string tentaikhoan, string matkhau)
        {
            for(int i = 0; i < listTaiKhoan.Count; i++)
            {
                if (tentaikhoan == listTaiKhoan[i].TenTaiKhoan && matkhau == listTaiKhoan[i].MatKhau)
                    return true;
            }
                return false;
        }

       
    }
}
