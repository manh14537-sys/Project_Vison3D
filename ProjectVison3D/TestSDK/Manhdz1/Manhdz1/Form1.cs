using System;
using System.Windows.Forms;
using rokae.clr; // Namespace ROKAE xCore SDK

namespace Manhdz1
{
    public partial class Form1 : Form
    {
        // 1. Đổi kiểu khai báo từ Cobot sang xMateRobot (dành cho SR5)
        private xMateRobot robotSR5 = null;
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
        }
        // Load tất cả dữ liệu khi Form 1 được bật lên
        private void Form1_Load(object sender, EventArgs e)
        {
            // Viết code khởi tạo ở đây (ví dụ: chọn sẵn MoveL trong ComboBox)
            if (cboMoveType.Items.Count > 0)
            {
                cboMoveType.SelectedIndex = 0;
            }
            if (cboCoordinate.Items.Count > 0)
            {
                cboCoordinate.SelectedIndex = 0;
            }
        }
        //
        // Sự kiện nút Connect
        // Sự kiện nút Connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIpAddress.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Please enter the robot IP address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Status: Connecting...";

                // Khởi tạo đối tượng robot. 
                // LƯU Ý: Nếu vẫn gặp lỗi NullReference, hãy thử đổi tên lớp thành new xMateRobot() theo mẫu của SDK[cite: 6].
                robotSR5 = new xMateRobot();

                // Sử dụng phiên bản hàm chỉ nhận 1 tham số (IP của robot)[cite: 10]
                robotSR5.connectToRobot(ipAddress);

                isConnected = true;
                lblStatus.Text = "Status: Connected to " + ipAddress;
                MessageBox.Show("Connected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                isConnected = false;
                lblStatus.Text = "Status: Connection Failed";
                MessageBox.Show("Connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Sự kiện nút EnableDrag
        private void btnEnableDrag_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Not connected to Robot!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;
                // Bật chế độ Drag
                robotSR5.enableDrag(DragOpt.Space.jointSpace, DragOpt.Type.freely, out ec);

                if (ec.value == 0)
                {
                    lblStatus.Text = "Status: Drag Enabled";
                    MessageBox.Show("Drag mode enabled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Enable Drag failed with code: " + ec.value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enable Drag error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm tắt Drag
        private void Close_Drag_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra robot đã kết nối chưa
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Robot chưa được kết nối!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;

                // 2. Gọi hàm disableDrag() từ SDK ROKAE để ngắt chế độ kéo tay
                robotSR5.disableDrag(out ec);

                // 3. Kiểm tra kết quả trả về
                if (ec.value == 0)
                {
                    lblStatus.Text = "Trạng thái: Đã TẮT chế độ Drag!";
                    MessageBox.Show("Đã tắt chế độ Drag (kéo tay) thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Lỗi tắt Drag: Mã " + ec.value;
                    MessageBox.Show("Không thể tắt chế độ Drag.\nMã lỗi: " + ec.value + " - " + ec.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ khi tắt Drag: " + ex.Message, "Ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ngắt kết nối khi tắt Form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                try
                {
                    ErrorCode ec;
                    robotSR5.disconnectFromRobot(out ec);
                }
                catch
                {
                    // Bỏ qua ngoại lệ lúc tắt app
                }
            }
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this); // Truyền chính Form1 hiện tại (this) vào Form2 [1, 2]
            f2.Show();
            this.Hide(); // Ẩn Form1 [1, 2]
        }
        // Bật nguồn cho động cơ 

        private void PowerOn_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Robot chưa được kết nối!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;

                // 1. Chuyển sang chế độ Manual và NrtCommand
                robotSR5.setOperateMode(OperateMode.automatic, out ec);
                robotSR5.setMotionControlMode(MotionControlMode.NrtCommand, out ec);

                // 2. Tạm thời TẮT phát hiện va chạm để tránh bị kích hoạt nhầm lúc bật nguồn
                robotSR5.disableCollisionDetection(out ec);

                // 3. Xóa các cảnh báo Servo / Vùng va chạm cũ
                robotSR5.clearServoAlarm(out ec);

                // 4. Bật nguồn động cơ Servo
                robotSR5.setPowerState(true, out ec);

                if (ec.value == 0)
                {
                    lblStatus.Text = "Trạng thái: Bật nguồn thành công!";

                    // 5. Bật lại chức năng phát hiện va chạm sau khi nguồn đã sẵn sàng (Đặt độ nhạy 1.0 = 100%)
                    double[] sensitivity = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
                    robotSR5.enableCollisionDetection(sensitivity, StopLevel.stop1, 0.01, out ec);

                    MessageBox.Show("Đã bật nguồn động cơ Robot thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Lỗi bật nguồn: " + ec.value;
                    MessageBox.Show("Mã lỗi: " + ec.value + " - " + ec.message + "\n\nLưu ý: Kiểm tra lại cài đặt tải trọng (Load) trên RobotAssist!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cắt nguồn động cơ
        private void PowerOff_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Robot chưa được kết nối!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;

                // 1. Chuyển sang chế độ Manual và NrtCommand
                robotSR5.setOperateMode(OperateMode.automatic, out ec);
                robotSR5.setMotionControlMode(MotionControlMode.NrtCommand, out ec);

                // 2. Tạm thời TẮT phát hiện va chạm để tránh bị kích hoạt nhầm lúc bật nguồn
                robotSR5.disableCollisionDetection(out ec);

                // 3. Xóa các cảnh báo Servo / Vùng va chạm cũ
                robotSR5.clearServoAlarm(out ec);

                // 4. Bật nguồn động cơ Servo
                robotSR5.setPowerState(false, out ec);

                if (ec.value == 0)
                {
                    lblStatus.Text = "Trạng thái: Bật nguồn thành công!";

                    // 5. Bật lại chức năng phát hiện va chạm sau khi nguồn đã sẵn sàng (Đặt độ nhạy 1.0 = 100%)
                    double[] sensitivity = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };
                    robotSR5.enableCollisionDetection(sensitivity, StopLevel.stop1, 0.01, out ec);

                    MessageBox.Show("Đã tắt nguồn động cơ Robot thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Lỗi tắt nguồn: " + ec.value;
                    MessageBox.Show("Mã lỗi: " + ec.value + " - " + ec.message + "\n\nLưu ý: Kiểm tra lại cài đặt tải trọng (Load) trên RobotAssist!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // Hàm bật tắt tay teach
        private void DisableTeachPendant_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Chưa kết nối với Robot!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;

                // Gọi hàm setTeachPendantMode với tham số false để TẮT tay Teach
                robotSR5.setTeachPendantMode(false, out ec);

                if (ec.value == 0)
                {
                    lblStatus.Text = "Trạng thái: Đã TẮT tay Teach! Toàn quyền điều khiển qua WinForms.";
                    MessageBox.Show("Đã TẮT tay Teach thành công!\nCác nút bấm vật lý trên tay Teach đã bị vô hiệu hóa.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Lỗi tắt tay Teach: " + ec.value;
                    MessageBox.Show($"Không thể tắt tay Teach.\nMã lỗi: {ec.value} - {ec.message}\n" +
                                    "(Lưu ý: Không thể chuyển trạng thái khi Robot đang di chuyển hoặc đang cấp nguồn thủ công)",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm bật tay teach
        private void EnableTeachPendant_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Chưa kết nối với Robot!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ErrorCode ec;

                // Gọi hàm setTeachPendantMode với tham số true để BẬT lại tay Teach
                robotSR5.setTeachPendantMode(true, out ec);

                if (ec.value == 0)
                {
                    lblStatus.Text = "Trạng thái: Đã BẬT lại tay Teach!";
                    MessageBox.Show("Đã BẬT lại tay Teach thành công!\nBạn có thể thao tác lại trên màn hình/nút bấm của tay Teach.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Lỗi bật tay Teach: " + ec.value;
                    MessageBox.Show($"Không thể bật tay Teach.\nMã lỗi: {ec.value} - {ec.message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // HÀM CHUẨN BỊ TRẠNG THÁI TRƯỚC KHI JOG
        // ==========================================
        private bool PrepareRobotForJog()
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Chưa kết nối với Robot!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ErrorCode ec;

            // 1. Chuyển sang chế độ Manual (BẮT BUỘC để chạy startJog)
            robotSR5.setOperateMode(OperateMode.manual, out ec);

            // 2. Chuyển sang chế độ lệnh không theo thời gian thực (NrtCommand)
            robotSR5.setMotionControlMode(MotionControlMode.NrtCommand, out ec);

            // 3. Đảm bảo nguồn Servo đã được bật
            robotSR5.setPowerState(true, out ec);

            return true;
        }
        // hàm chạy J1+
        private void J1_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 0, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J1+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J1+...";
            }
        }

        //hàm chạy J1-
        private void J1_P_Mouseup(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J1+";
            }
        }


        private void J1_N_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 0, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J1-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J1-...";
            }
        }

        private void J1_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J1-";
            }
        }






        private void J2_N_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 1, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J2-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J2-...";
            }
        }

        private void J2_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J2-";
            }
        }

        private void J2_P_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J2+";
            }
        }

        private void J2_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 1, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J2+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J2+...";
            }
        }

        private void J3_N_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 2, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J3-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J3-...";
            }
        }

        private void J3_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J3-";
            }
        }

        private void J3_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 2, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J3+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J3+...";
            }
        }

        private void J3_P_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J3+";
            }
        }

        private void J4_N_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 3, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J4-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J4-...";
            }
        }

        private void J4_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J4-";
            }
        }

        private void J4_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 3, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J4+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J4+...";
            }
        }

        private void J4_P_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J4+";
            }
        }

        private void J5_N_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 4, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J5-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J5-...";
            }
        }

        private void J5_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J5-";
            }
        }

        private void J5_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 4, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J5+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J5+...";
            }
        }

        private void J5_P_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J5+";
            }
        }

        private void J6_N_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 5, false, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J6-: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J6-...";
            }
        }

        private void J6_N_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J6-";
            }
        }

        private void J6_P_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PrepareRobotForJog()) return;

            ErrorCode ec;
            // Parameters:
            // - space: JogSpace.jointSpace (Chạy theo góc khớp)
            // - rate: 0.1 (10% tốc độ)
            // - step: 100.0 (Đặt bước lớn để chạy liên tục khi giữ nút)
            // - index: 0 (Chỉ số 0 = Khớp J1)
            // - direction: true (Chiều dương +)
            robotSR5.startJog(JogSpace.jointSpace, 0.1, 100.0, 5, true, out ec);

            if (ec.value != 0)
            {
                lblStatus.Text = "Lỗi Jog J6+: " + ec.value + " - " + ec.message;
            }
            else
            {
                lblStatus.Text = "Đang Jog J6+...";
            }
        }

        private void J6_P_MouseUp(object sender, MouseEventArgs e)
        {
            if (robotSR5 != null && isConnected)
            {
                ErrorCode ec;
                robotSR5.stop(out ec); // Bắt buộc gọi stop() khi dừng Jog
                lblStatus.Text = "Trạng thái: Đã dừng Jog J6+";
            }
        }
        //

        // Hàm cho phép chạy tới điểm đã định trước trong text
        private void MovePosition_Click(object sender, EventArgs e)
        {
            if (!isConnected || robotSR5 == null)
            {
                MessageBox.Show("Chưa kết nối với Robot!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Đọc kiểu Move được chọn từ ComboBox
            string selectedMoveStr = cboMoveType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedMoveStr))
            {
                MessageBox.Show("Vui lòng chọn kiểu di chuyển (MoveL hoặc MoveJ) trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định enum MoveCommand.Type dựa theo ComboBox
            MoveCommand.Type moveType = MoveCommand.Type.MoveL;
            if (selectedMoveStr == "MoveJ")
            {
                moveType = MoveCommand.Type.MoveJ;
            }

            // 2. Đọc và làm sạch chuỗi nhập vào từ ô txtPosition
            string inputStr = txtPosition.Text.Trim();
            if (string.IsNullOrEmpty(inputStr))
            {
                MessageBox.Show("Vui lòng nhập 6 giá trị: X, Y, Z, A, B, C", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] parts = inputStr.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 6)
            {
                MessageBox.Show($"Bạn mới nhập {parts.Length} số! Vui lòng nhập ĐỦ 6 số (X, Y, Z, A, B, C).",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] values = new double[6];
            for (int i = 0; i < 6; i++)
            {
                if (!double.TryParse(parts[i], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out values[i]))
                {
                    MessageBox.Show($"Giá trị thứ {i + 1} ('{parts[i]}') không phải số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                ErrorCode ec;

                // 3. Đổi đơn vị sang mét và Radian
                double x_m = values[0] / 1000.0;        // X (mm -> m)
                double y_m = values[1] / 1000.0;        // Y (mm -> m)
                double z_m = values[2] / 1000.0;        // Z (mm -> m)

                double a_rad = values[3] * Math.PI / 180.0; // A (độ -> rad)
                double b_rad = values[4] * Math.PI / 180.0; // B (độ -> rad)
                double c_rad = values[5] * Math.PI / 180.0; // C (độ -> rad)

                // Bật chế độ Auto và cấp nguồn Servo
                robotSR5.setOperateMode(OperateMode.automatic, out ec);
                robotSR5.setMotionControlMode(MotionControlMode.NrtCommand, out ec);
                robotSR5.setPowerState(true, out ec);

                // Khởi tạo tọa độ mục tiêu
                CartesianPosition targetPoint = new CartesianPosition
                {
                    trans = new double[] { x_m, y_m, z_m },
                    rpy = new double[] { a_rad, b_rad, c_rad }
                };

                MoveCommand moveCmd = new MoveCommand
                {
                    cartTarget = targetPoint,
                    speed = 100 // Tốc độ mm/s
                };

                string cmdId = "";

                // 4. TRUYỀN BIẾN moveType ĐÃ CHỌN VÀO HÀM moveAppend
                robotSR5.moveAppend(moveType, moveCmd, ref cmdId, out ec);

                if (ec.value == 0)
                {
                    robotSR5.moveStart(out ec); // Kích hoạt chạy
                    lblStatus.Text = $"Đang chạy kiểu {selectedMoveStr} tới: X={values[0]}, Y={values[1]}, Z={values[2]}";
                }
                else
                {
                    lblStatus.Text = $"Lỗi {selectedMoveStr}: " + ec.value + " - " + ec.message;
                    MessageBox.Show($"Mã lỗi SDK: {ec.value} - {ec.message}", "Lỗi di chuyển", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //


        //

        //
    }
}