using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace offical_winform_quanlybaidang
{
    public partial class FormQuanLy : Form
    {
        public bool isThoat = true;
        string FileImageName = null;
        PostManager postManager = new PostManager();
        public FormQuanLy()
        {
            InitializeComponent();
        }

        public event EventHandler DangXuat;


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }

        private void FormQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void FormQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThoat)
            {
                if (MessageBox.Show("Bạn có muốn thoát phần mềm?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
        void LoadImage(ref string imageName)
        {
            OpenFileDialog fileImageName = new OpenFileDialog();
            if (fileImageName.ShowDialog() == DialogResult.OK)
            {
                imageName = fileImageName.FileName;
            }
        }
   
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string title = txbTitle.Text;
            string content = txbContent.Text;
            string username = txbUserName.Text;

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(username))
            {
                lstTitle.Items.Add(txbTitle.Text);
                lstContent.Items.Add(txbContent.Text);
                
            }
            else
            {
                MessageBox.Show("Mời bạn nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadImage(ref FileImageName);
            pictureBox1.Image = new Bitmap(FileImageName);
        }

      

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lstPosts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là một chữ cái không
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái và không phải là phím điều khiển (như backspace), thì hủy sự kiện
                e.Handled = true;
            }
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là một chữ cái không
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái và không phải là phím điều khiển (như backspace), thì hủy sự kiện
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lstTitle.SelectedIndex != -1)
            {
                // Lấy chỉ mục của mục được chọn
                int selectedIndex = lstTitle.SelectedIndex;

                // Xóa mục có chỉ mục được chọn khỏi ListBox
                lstTitle.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lstTitle.SelectedIndex != -1)
            {
                // Lấy chỉ mục của mục được chọn
                int selectedIndex = lstTitle.SelectedIndex;

                // Hiển thị hộp thoại nhập liệu cho người dùng chỉnh sửa
                string editedItem = Interaction.InputBox("Nhập nội dung mới:", "Chỉnh sửa mục", lstTitle.Items[selectedIndex].ToString());

                // Kiểm tra xem người dùng đã nhập liệu hay không
                if (!string.IsNullOrEmpty(editedItem))
                {
                    // Xóa mục cũ có chỉ mục được chọn
                    lstTitle.Items.RemoveAt(selectedIndex);
                   
                    // Thêm mục mới (đã chỉnh sửa) vào cùng vị trí
                    lstTitle.Items.Insert(selectedIndex, editedItem);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để chỉnh sửa.");
            }
        }

        private void lstPosts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstTitle.SelectedIndex != -1)
            {
                // Lấy tiêu đề của mục được chọn trong ListBox
                string selectedTitle = lstTitle.SelectedItem.ToString();

                // Cập nhật giá trị của textBox để hiển thị tiêu đề tương ứng
                txbTitle.Text = selectedTitle;
            }
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lstContent.SelectedIndex != -1)
            {
                // Lấy chỉ mục của mục được chọn
                int selectedIndex = lstContent.SelectedIndex;

                // Hiển thị hộp thoại nhập liệu cho người dùng chỉnh sửa
                string editedItem = Interaction.InputBox("Nhập nội dung mới:", "Chỉnh sửa mục", lstContent.Items[selectedIndex].ToString());

                // Kiểm tra xem người dùng đã nhập liệu hay không
                if (!string.IsNullOrEmpty(editedItem))
                {
                    // Xóa mục cũ có chỉ mục được chọn
                    lstContent.Items.RemoveAt(selectedIndex);

                    // Thêm mục mới (đã chỉnh sửa) vào cùng vị trí
                    lstContent.Items.Insert(selectedIndex, editedItem);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để chỉnh sửa.");
            }
        }
    

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lstContent.SelectedIndex != -1)
            {
                // Lấy chỉ mục của mục được chọn
                int selectedIndex = lstContent.SelectedIndex;

                // Xóa mục có chỉ mục được chọn khỏi ListBox
                lstContent.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.");
            }
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContent.SelectedIndex != -1)
            {
                // Lấy tiêu đề của mục được chọn trong ListBox
                string selectedContent = lstTitle.SelectedItem.ToString();

                // Cập nhật giá trị của textBox để hiển thị tiêu đề tương ứng
                txbContent.Text = selectedContent;
            }
        }
    }
}
