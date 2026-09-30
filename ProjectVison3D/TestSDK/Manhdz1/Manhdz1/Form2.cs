using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manhdz1
{
    public partial class Form2 : Form
    {
        private Form1 _parentForm1; // Khai báo biến lưu tham chiếu của Form1 [1, 2]

        // Sửa hàm khởi tạo Form2 để nhận Form1 truyền vào từ bên ngoài [1, 2]
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _parentForm1 = form1; // Lưu Form1 lại [1, 2]
        }

        // Sự kiện Click của nút bấm quay về trên Form2 (ví dụ: btnBack hoặc BackForm1) [1, 2]
        
        private void btnOpenForm1_Click_1(object sender, EventArgs e)
        {
            if (_parentForm1 != null)
            {
                _parentForm1.Show(); // Bật Form1 hiển thị trở lại [1, 2]
            }
            this.Close(); // Đóng Form2 hiện tại [1, 2]
        }
    }
}
