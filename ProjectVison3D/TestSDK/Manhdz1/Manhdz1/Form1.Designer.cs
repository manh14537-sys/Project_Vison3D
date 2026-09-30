namespace Manhdz1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblIpPrompt = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnEnableDrag = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnOpenForm2 = new System.Windows.Forms.Button();
            this.StartPro = new System.Windows.Forms.Button();
            this.StopPro = new System.Windows.Forms.Button();
            this.MovePosition = new System.Windows.Forms.Button();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.J3_N = new System.Windows.Forms.Button();
            this.J2_N = new System.Windows.Forms.Button();
            this.J1_N = new System.Windows.Forms.Button();
            this.J6_N = new System.Windows.Forms.Button();
            this.J5_N = new System.Windows.Forms.Button();
            this.J4_N = new System.Windows.Forms.Button();
            this.RotateC_P = new System.Windows.Forms.Button();
            this.RotateB_P = new System.Windows.Forms.Button();
            this.RotateA_P = new System.Windows.Forms.Button();
            this.Z_P = new System.Windows.Forms.Button();
            this.Y_P = new System.Windows.Forms.Button();
            this.X_P = new System.Windows.Forms.Button();
            this.J6_P = new System.Windows.Forms.Button();
            this.J5_P = new System.Windows.Forms.Button();
            this.J4_P = new System.Windows.Forms.Button();
            this.J3_P = new System.Windows.Forms.Button();
            this.J2_P = new System.Windows.Forms.Button();
            this.J1_P = new System.Windows.Forms.Button();
            this.RotateC_N = new System.Windows.Forms.Button();
            this.RotateB_N = new System.Windows.Forms.Button();
            this.RotateA_N = new System.Windows.Forms.Button();
            this.Z_N = new System.Windows.Forms.Button();
            this.Y_N = new System.Windows.Forms.Button();
            this.X_N = new System.Windows.Forms.Button();
            this.PowerOn = new System.Windows.Forms.Button();
            this.PowerOff = new System.Windows.Forms.Button();
            this.Close_Drag = new System.Windows.Forms.Button();
            this.DisableTeachPendant = new System.Windows.Forms.Button();
            this.EnableTeachPendant = new System.Windows.Forms.Button();
            this.cboMoveType = new System.Windows.Forms.ComboBox();
            this.cboCoordinate = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIpPrompt
            // 
            this.lblIpPrompt.AutoSize = true;
            this.lblIpPrompt.Location = new System.Drawing.Point(21, 22);
            this.lblIpPrompt.Name = "lblIpPrompt";
            this.lblIpPrompt.Size = new System.Drawing.Size(93, 13);
            this.lblIpPrompt.TabIndex = 0;
            this.lblIpPrompt.Text = "Robot IP Address:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(111, 19);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(129, 20);
            this.txtIpAddress.TabIndex = 1;
            this.txtIpAddress.Text = "192.168.0.160";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(24, 52);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnEnableDrag
            // 
            this.btnEnableDrag.Location = new System.Drawing.Point(141, 52);
            this.btnEnableDrag.Name = "btnEnableDrag";
            this.btnEnableDrag.Size = new System.Drawing.Size(99, 30);
            this.btnEnableDrag.TabIndex = 3;
            this.btnEnableDrag.Text = "EnableDrag";
            this.btnEnableDrag.UseVisualStyleBackColor = true;
            this.btnEnableDrag.Click += new System.EventHandler(this.btnEnableDrag_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(21, 100);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Ready";
            // 
            // btnOpenForm2
            // 
            this.btnOpenForm2.Location = new System.Drawing.Point(12, 656);
            this.btnOpenForm2.Name = "btnOpenForm2";
            this.btnOpenForm2.Size = new System.Drawing.Size(75, 23);
            this.btnOpenForm2.TabIndex = 5;
            this.btnOpenForm2.Text = "Mở trang 2";
            this.btnOpenForm2.UseVisualStyleBackColor = true;
            this.btnOpenForm2.Click += new System.EventHandler(this.btnOpenForm2_Click);
            // 
            // StartPro
            // 
            this.StartPro.Location = new System.Drawing.Point(24, 128);
            this.StartPro.Name = "StartPro";
            this.StartPro.Size = new System.Drawing.Size(95, 26);
            this.StartPro.TabIndex = 6;
            this.StartPro.Text = "Start Program";
            this.StartPro.UseVisualStyleBackColor = true;
            // 
            // StopPro
            // 
            this.StopPro.Location = new System.Drawing.Point(28, 175);
            this.StopPro.Name = "StopPro";
            this.StopPro.Size = new System.Drawing.Size(95, 26);
            this.StopPro.TabIndex = 7;
            this.StopPro.Text = "Stop Program";
            this.StopPro.UseVisualStyleBackColor = true;
            // 
            // MovePosition
            // 
            this.MovePosition.Location = new System.Drawing.Point(28, 220);
            this.MovePosition.Name = "MovePosition";
            this.MovePosition.Size = new System.Drawing.Size(95, 26);
            this.MovePosition.TabIndex = 8;
            this.MovePosition.Text = "MovePosition";
            this.MovePosition.UseVisualStyleBackColor = true;
            this.MovePosition.Click += new System.EventHandler(this.MovePosition_Click);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(199, 226);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(190, 20);
            this.txtPosition.TabIndex = 9;
            this.txtPosition.Text = "175, 300, 850, -163, 28, -66 ";
            // 
            // J3_N
            // 
            this.J3_N.Location = new System.Drawing.Point(631, 220);
            this.J3_N.Name = "J3_N";
            this.J3_N.Size = new System.Drawing.Size(95, 26);
            this.J3_N.TabIndex = 12;
            this.J3_N.Text = "J3_N";
            this.J3_N.UseVisualStyleBackColor = true;
            this.J3_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J3_N_MouseDown);
            this.J3_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J3_N_MouseUp);
            // 
            // J2_N
            // 
            this.J2_N.Location = new System.Drawing.Point(631, 175);
            this.J2_N.Name = "J2_N";
            this.J2_N.Size = new System.Drawing.Size(95, 26);
            this.J2_N.TabIndex = 11;
            this.J2_N.Text = "J2_N";
            this.J2_N.UseVisualStyleBackColor = true;
            this.J2_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J2_N_MouseDown);
            this.J2_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J2_N_MouseUp);
            // 
            // J1_N
            // 
            this.J1_N.Location = new System.Drawing.Point(631, 128);
            this.J1_N.Name = "J1_N";
            this.J1_N.Size = new System.Drawing.Size(95, 26);
            this.J1_N.TabIndex = 10;
            this.J1_N.Text = "J1_N";
            this.J1_N.UseVisualStyleBackColor = true;
            this.J1_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J1_N_MouseDown_1);
            this.J1_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J1_N_MouseUp);
            // 
            // J6_N
            // 
            this.J6_N.Location = new System.Drawing.Point(631, 358);
            this.J6_N.Name = "J6_N";
            this.J6_N.Size = new System.Drawing.Size(95, 26);
            this.J6_N.TabIndex = 15;
            this.J6_N.Text = "J6_N";
            this.J6_N.UseVisualStyleBackColor = true;
            this.J6_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J6_N_MouseDown);
            this.J6_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J6_N_MouseUp);
            // 
            // J5_N
            // 
            this.J5_N.Location = new System.Drawing.Point(631, 313);
            this.J5_N.Name = "J5_N";
            this.J5_N.Size = new System.Drawing.Size(95, 26);
            this.J5_N.TabIndex = 14;
            this.J5_N.Text = "J5_N";
            this.J5_N.UseVisualStyleBackColor = true;
            this.J5_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J5_N_MouseDown);
            this.J5_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J5_N_MouseUp);
            // 
            // J4_N
            // 
            this.J4_N.Location = new System.Drawing.Point(631, 266);
            this.J4_N.Name = "J4_N";
            this.J4_N.Size = new System.Drawing.Size(95, 26);
            this.J4_N.TabIndex = 13;
            this.J4_N.Text = "J4_N";
            this.J4_N.UseVisualStyleBackColor = true;
            this.J4_N.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J4_N_MouseDown);
            this.J4_N.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J4_N_MouseUp);
            // 
            // RotateC_P
            // 
            this.RotateC_P.Location = new System.Drawing.Point(1090, 358);
            this.RotateC_P.Name = "RotateC_P";
            this.RotateC_P.Size = new System.Drawing.Size(95, 26);
            this.RotateC_P.TabIndex = 21;
            this.RotateC_P.Text = "C+";
            this.RotateC_P.UseVisualStyleBackColor = true;
            // 
            // RotateB_P
            // 
            this.RotateB_P.Location = new System.Drawing.Point(1090, 313);
            this.RotateB_P.Name = "RotateB_P";
            this.RotateB_P.Size = new System.Drawing.Size(95, 26);
            this.RotateB_P.TabIndex = 20;
            this.RotateB_P.Text = "B+";
            this.RotateB_P.UseVisualStyleBackColor = true;
            // 
            // RotateA_P
            // 
            this.RotateA_P.Location = new System.Drawing.Point(1090, 266);
            this.RotateA_P.Name = "RotateA_P";
            this.RotateA_P.Size = new System.Drawing.Size(95, 26);
            this.RotateA_P.TabIndex = 19;
            this.RotateA_P.Text = "A+";
            this.RotateA_P.UseVisualStyleBackColor = true;
            // 
            // Z_P
            // 
            this.Z_P.Location = new System.Drawing.Point(1090, 220);
            this.Z_P.Name = "Z_P";
            this.Z_P.Size = new System.Drawing.Size(95, 26);
            this.Z_P.TabIndex = 18;
            this.Z_P.Text = "Z+";
            this.Z_P.UseVisualStyleBackColor = true;
            // 
            // Y_P
            // 
            this.Y_P.Location = new System.Drawing.Point(1090, 175);
            this.Y_P.Name = "Y_P";
            this.Y_P.Size = new System.Drawing.Size(95, 26);
            this.Y_P.TabIndex = 17;
            this.Y_P.Text = "Y+";
            this.Y_P.UseVisualStyleBackColor = true;
            // 
            // X_P
            // 
            this.X_P.Location = new System.Drawing.Point(1090, 128);
            this.X_P.Name = "X_P";
            this.X_P.Size = new System.Drawing.Size(95, 26);
            this.X_P.TabIndex = 16;
            this.X_P.Text = "X+";
            this.X_P.UseVisualStyleBackColor = true;
            // 
            // J6_P
            // 
            this.J6_P.Location = new System.Drawing.Point(751, 358);
            this.J6_P.Name = "J6_P";
            this.J6_P.Size = new System.Drawing.Size(95, 26);
            this.J6_P.TabIndex = 27;
            this.J6_P.Text = "J6_P";
            this.J6_P.UseVisualStyleBackColor = true;
            this.J6_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J6_P_MouseDown);
            this.J6_P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J6_P_MouseUp);
            // 
            // J5_P
            // 
            this.J5_P.Location = new System.Drawing.Point(751, 313);
            this.J5_P.Name = "J5_P";
            this.J5_P.Size = new System.Drawing.Size(95, 26);
            this.J5_P.TabIndex = 26;
            this.J5_P.Text = "J5_P";
            this.J5_P.UseVisualStyleBackColor = true;
            this.J5_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J5_P_MouseDown);
            this.J5_P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J5_P_MouseUp);
            // 
            // J4_P
            // 
            this.J4_P.Location = new System.Drawing.Point(751, 266);
            this.J4_P.Name = "J4_P";
            this.J4_P.Size = new System.Drawing.Size(95, 26);
            this.J4_P.TabIndex = 25;
            this.J4_P.Text = "J4_P";
            this.J4_P.UseVisualStyleBackColor = true;
            this.J4_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J4_P_MouseDown);
            this.J4_P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J4_P_MouseUp);
            // 
            // J3_P
            // 
            this.J3_P.Location = new System.Drawing.Point(751, 220);
            this.J3_P.Name = "J3_P";
            this.J3_P.Size = new System.Drawing.Size(95, 26);
            this.J3_P.TabIndex = 24;
            this.J3_P.Text = "J3_P";
            this.J3_P.UseVisualStyleBackColor = true;
            this.J3_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J3_P_MouseDown);
            this.J3_P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J3_P_MouseUp);
            // 
            // J2_P
            // 
            this.J2_P.Location = new System.Drawing.Point(751, 175);
            this.J2_P.Name = "J2_P";
            this.J2_P.Size = new System.Drawing.Size(95, 26);
            this.J2_P.TabIndex = 23;
            this.J2_P.Text = "J2_P";
            this.J2_P.UseVisualStyleBackColor = true;
            this.J2_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J2_P_MouseDown);
            this.J2_P.MouseUp += new System.Windows.Forms.MouseEventHandler(this.J2_P_MouseUp);
            // 
            // J1_P
            // 
            this.J1_P.Location = new System.Drawing.Point(751, 128);
            this.J1_P.Name = "J1_P";
            this.J1_P.Size = new System.Drawing.Size(95, 26);
            this.J1_P.TabIndex = 22;
            this.J1_P.Text = "J1_P";
            this.J1_P.UseVisualStyleBackColor = true;
            this.J1_P.MouseDown += new System.Windows.Forms.MouseEventHandler(this.J1_P_MouseDown);
            // 
            // RotateC_N
            // 
            this.RotateC_N.Location = new System.Drawing.Point(980, 358);
            this.RotateC_N.Name = "RotateC_N";
            this.RotateC_N.Size = new System.Drawing.Size(95, 26);
            this.RotateC_N.TabIndex = 33;
            this.RotateC_N.Text = "C-";
            this.RotateC_N.UseVisualStyleBackColor = true;
            // 
            // RotateB_N
            // 
            this.RotateB_N.Location = new System.Drawing.Point(980, 313);
            this.RotateB_N.Name = "RotateB_N";
            this.RotateB_N.Size = new System.Drawing.Size(95, 26);
            this.RotateB_N.TabIndex = 32;
            this.RotateB_N.Text = "B-";
            this.RotateB_N.UseVisualStyleBackColor = true;
            // 
            // RotateA_N
            // 
            this.RotateA_N.Location = new System.Drawing.Point(980, 266);
            this.RotateA_N.Name = "RotateA_N";
            this.RotateA_N.Size = new System.Drawing.Size(95, 26);
            this.RotateA_N.TabIndex = 31;
            this.RotateA_N.Text = "A-";
            this.RotateA_N.UseVisualStyleBackColor = true;
            // 
            // Z_N
            // 
            this.Z_N.Location = new System.Drawing.Point(980, 220);
            this.Z_N.Name = "Z_N";
            this.Z_N.Size = new System.Drawing.Size(95, 26);
            this.Z_N.TabIndex = 30;
            this.Z_N.Text = "Z-";
            this.Z_N.UseVisualStyleBackColor = true;
            // 
            // Y_N
            // 
            this.Y_N.Location = new System.Drawing.Point(980, 175);
            this.Y_N.Name = "Y_N";
            this.Y_N.Size = new System.Drawing.Size(95, 26);
            this.Y_N.TabIndex = 29;
            this.Y_N.Text = "Y-";
            this.Y_N.UseVisualStyleBackColor = true;
            // 
            // X_N
            // 
            this.X_N.Location = new System.Drawing.Point(980, 128);
            this.X_N.Name = "X_N";
            this.X_N.Size = new System.Drawing.Size(95, 26);
            this.X_N.TabIndex = 28;
            this.X_N.Text = "X-";
            this.X_N.UseVisualStyleBackColor = true;
            // 
            // PowerOn
            // 
            this.PowerOn.Location = new System.Drawing.Point(861, 219);
            this.PowerOn.Name = "PowerOn";
            this.PowerOn.Size = new System.Drawing.Size(95, 26);
            this.PowerOn.TabIndex = 34;
            this.PowerOn.Text = "PowerOn";
            this.PowerOn.UseVisualStyleBackColor = true;
            this.PowerOn.Click += new System.EventHandler(this.PowerOn_Click);
            // 
            // PowerOff
            // 
            this.PowerOff.Location = new System.Drawing.Point(861, 266);
            this.PowerOff.Name = "PowerOff";
            this.PowerOff.Size = new System.Drawing.Size(95, 26);
            this.PowerOff.TabIndex = 35;
            this.PowerOff.Text = "PoweOff";
            this.PowerOff.UseVisualStyleBackColor = true;
            this.PowerOff.Click += new System.EventHandler(this.PowerOff_Click);
            // 
            // Close_Drag
            // 
            this.Close_Drag.Location = new System.Drawing.Point(264, 52);
            this.Close_Drag.Name = "Close_Drag";
            this.Close_Drag.Size = new System.Drawing.Size(99, 30);
            this.Close_Drag.TabIndex = 36;
            this.Close_Drag.Text = "CloseDrag";
            this.Close_Drag.UseVisualStyleBackColor = true;
            this.Close_Drag.Click += new System.EventHandler(this.Close_Drag_Click);
            // 
            // DisableTeachPendant
            // 
            this.DisableTeachPendant.Location = new System.Drawing.Point(631, 52);
            this.DisableTeachPendant.Name = "DisableTeachPendant";
            this.DisableTeachPendant.Size = new System.Drawing.Size(95, 26);
            this.DisableTeachPendant.TabIndex = 37;
            this.DisableTeachPendant.Text = "Tắt tay teach";
            this.DisableTeachPendant.UseVisualStyleBackColor = true;
            this.DisableTeachPendant.Click += new System.EventHandler(this.DisableTeachPendant_Click);
            // 
            // EnableTeachPendant
            // 
            this.EnableTeachPendant.Location = new System.Drawing.Point(751, 52);
            this.EnableTeachPendant.Name = "EnableTeachPendant";
            this.EnableTeachPendant.Size = new System.Drawing.Size(95, 26);
            this.EnableTeachPendant.TabIndex = 38;
            this.EnableTeachPendant.Text = "Bật tay teach";
            this.EnableTeachPendant.UseVisualStyleBackColor = true;
            this.EnableTeachPendant.Click += new System.EventHandler(this.EnableTeachPendant_Click);
            // 
            // cboMoveType
            // 
            this.cboMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoveType.FormattingEnabled = true;
            this.cboMoveType.Items.AddRange(new object[] {
            "MoveL",
            "MoveJ"});
            this.cboMoveType.Location = new System.Drawing.Point(129, 226);
            this.cboMoveType.Name = "cboMoveType";
            this.cboMoveType.Size = new System.Drawing.Size(55, 21);
            this.cboMoveType.TabIndex = 39;
            // 
            // cboCoordinate
            // 
            this.cboCoordinate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoordinate.FormattingEnabled = true;
            this.cboCoordinate.Items.AddRange(new object[] {
            "Base",
            "World",
            "Tool",
            "WorkObject",
            "Flange"});
            this.cboCoordinate.Location = new System.Drawing.Point(1090, 52);
            this.cboCoordinate.Name = "cboCoordinate";
            this.cboCoordinate.Size = new System.Drawing.Size(87, 21);
            this.cboCoordinate.TabIndex = 40;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 41;
            this.textBox1.Text = "X    Y ,   Z,    A,    B,   C";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 691);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cboCoordinate);
            this.Controls.Add(this.cboMoveType);
            this.Controls.Add(this.EnableTeachPendant);
            this.Controls.Add(this.DisableTeachPendant);
            this.Controls.Add(this.Close_Drag);
            this.Controls.Add(this.PowerOff);
            this.Controls.Add(this.PowerOn);
            this.Controls.Add(this.RotateC_N);
            this.Controls.Add(this.RotateB_N);
            this.Controls.Add(this.RotateA_N);
            this.Controls.Add(this.Z_N);
            this.Controls.Add(this.Y_N);
            this.Controls.Add(this.X_N);
            this.Controls.Add(this.J6_P);
            this.Controls.Add(this.J5_P);
            this.Controls.Add(this.J4_P);
            this.Controls.Add(this.J3_P);
            this.Controls.Add(this.J2_P);
            this.Controls.Add(this.J1_P);
            this.Controls.Add(this.RotateC_P);
            this.Controls.Add(this.RotateB_P);
            this.Controls.Add(this.RotateA_P);
            this.Controls.Add(this.Z_P);
            this.Controls.Add(this.Y_P);
            this.Controls.Add(this.X_P);
            this.Controls.Add(this.J6_N);
            this.Controls.Add(this.J5_N);
            this.Controls.Add(this.J4_N);
            this.Controls.Add(this.J3_N);
            this.Controls.Add(this.J2_N);
            this.Controls.Add(this.J1_N);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.MovePosition);
            this.Controls.Add(this.StopPro);
            this.Controls.Add(this.StartPro);
            this.Controls.Add(this.btnOpenForm2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnEnableDrag);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.lblIpPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROKAE Cobot SR5 Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIpPrompt;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnEnableDrag;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnOpenForm2;
        private System.Windows.Forms.Button StartPro;
        private System.Windows.Forms.Button StopPro;
        private System.Windows.Forms.Button MovePosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Button J3_N;
        private System.Windows.Forms.Button J2_N;
        private System.Windows.Forms.Button J1_N;
        private System.Windows.Forms.Button J6_N;
        private System.Windows.Forms.Button J5_N;
        private System.Windows.Forms.Button J4_N;
        private System.Windows.Forms.Button RotateC_P;
        private System.Windows.Forms.Button RotateB_P;
        private System.Windows.Forms.Button RotateA_P;
        private System.Windows.Forms.Button Z_P;
        private System.Windows.Forms.Button Y_P;
        private System.Windows.Forms.Button X_P;
        private System.Windows.Forms.Button J6_P;
        private System.Windows.Forms.Button J5_P;
        private System.Windows.Forms.Button J4_P;
        private System.Windows.Forms.Button J3_P;
        private System.Windows.Forms.Button J2_P;
        private System.Windows.Forms.Button J1_P;
        private System.Windows.Forms.Button RotateC_N;
        private System.Windows.Forms.Button RotateB_N;
        private System.Windows.Forms.Button RotateA_N;
        private System.Windows.Forms.Button Z_N;
        private System.Windows.Forms.Button Y_N;
        private System.Windows.Forms.Button X_N;
        private System.Windows.Forms.Button PowerOn;
        private System.Windows.Forms.Button PowerOff;
        private System.Windows.Forms.Button Close_Drag;
        private System.Windows.Forms.Button DisableTeachPendant;
        private System.Windows.Forms.Button EnableTeachPendant;
        private System.Windows.Forms.ComboBox cboMoveType;
        private System.Windows.Forms.ComboBox cboCoordinate;
        private System.Windows.Forms.TextBox textBox1;
    }
}