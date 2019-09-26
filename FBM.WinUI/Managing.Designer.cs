namespace FBM.WinUI
{
    partial class Managing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetFlags = new System.Windows.Forms.Button();
            this.lblSM4 = new System.Windows.Forms.Label();
            this.lblSM3 = new System.Windows.Forms.Label();
            this.lblSM2 = new System.Windows.Forms.Label();
            this.lblSM1 = new System.Windows.Forms.Label();
            this.pbM4 = new System.Windows.Forms.ProgressBar();
            this.lblM4 = new System.Windows.Forms.Label();
            this.sbM4 = new DevExpress.XtraEditors.HScrollBar();
            this.pbM3 = new System.Windows.Forms.ProgressBar();
            this.lblM3 = new System.Windows.Forms.Label();
            this.sbM3 = new DevExpress.XtraEditors.HScrollBar();
            this.pbM2 = new System.Windows.Forms.ProgressBar();
            this.lblM2 = new System.Windows.Forms.Label();
            this.sbM2 = new DevExpress.XtraEditors.HScrollBar();
            this.pbM1 = new System.Windows.Forms.ProgressBar();
            this.lblM1 = new System.Windows.Forms.Label();
            this.sbM1 = new DevExpress.XtraEditors.HScrollBar();
            this.btnGetMotor = new System.Windows.Forms.Button();
            this.btnSetMotor = new System.Windows.Forms.Button();
            this.btnMixOff = new System.Windows.Forms.Button();
            this.btnMixOn = new System.Windows.Forms.Button();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblLdr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetDeviceCounts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nudUnitNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetFlags
            // 
            this.btnGetFlags.Location = new System.Drawing.Point(302, 135);
            this.btnGetFlags.Name = "btnGetFlags";
            this.btnGetFlags.Size = new System.Drawing.Size(78, 65);
            this.btnGetFlags.TabIndex = 89;
            this.btnGetFlags.Text = "Flags";
            this.btnGetFlags.UseVisualStyleBackColor = true;
            this.btnGetFlags.Click += new System.EventHandler(this.GetFlags_Click);
            // 
            // lblSM4
            // 
            this.lblSM4.AutoSize = true;
            this.lblSM4.Location = new System.Drawing.Point(366, 487);
            this.lblSM4.Name = "lblSM4";
            this.lblSM4.Size = new System.Drawing.Size(13, 17);
            this.lblSM4.TabIndex = 88;
            this.lblSM4.Text = "-";
            // 
            // lblSM3
            // 
            this.lblSM3.AutoSize = true;
            this.lblSM3.Location = new System.Drawing.Point(366, 416);
            this.lblSM3.Name = "lblSM3";
            this.lblSM3.Size = new System.Drawing.Size(13, 17);
            this.lblSM3.TabIndex = 87;
            this.lblSM3.Text = "-";
            // 
            // lblSM2
            // 
            this.lblSM2.AutoSize = true;
            this.lblSM2.Location = new System.Drawing.Point(366, 341);
            this.lblSM2.Name = "lblSM2";
            this.lblSM2.Size = new System.Drawing.Size(13, 17);
            this.lblSM2.TabIndex = 86;
            this.lblSM2.Text = "-";
            // 
            // lblSM1
            // 
            this.lblSM1.AutoSize = true;
            this.lblSM1.Location = new System.Drawing.Point(366, 267);
            this.lblSM1.Name = "lblSM1";
            this.lblSM1.Size = new System.Drawing.Size(13, 17);
            this.lblSM1.TabIndex = 85;
            this.lblSM1.Text = "-";
            // 
            // pbM4
            // 
            this.pbM4.Location = new System.Drawing.Point(54, 524);
            this.pbM4.Maximum = 255;
            this.pbM4.Name = "pbM4";
            this.pbM4.Size = new System.Drawing.Size(258, 23);
            this.pbM4.TabIndex = 84;
            // 
            // lblM4
            // 
            this.lblM4.AutoSize = true;
            this.lblM4.Location = new System.Drawing.Point(366, 524);
            this.lblM4.Name = "lblM4";
            this.lblM4.Size = new System.Drawing.Size(13, 17);
            this.lblM4.TabIndex = 83;
            this.lblM4.Text = "-";
            // 
            // sbM4
            // 
            this.sbM4.Location = new System.Drawing.Point(39, 488);
            this.sbM4.Maximum = 255;
            this.sbM4.Name = "sbM4";
            this.sbM4.Size = new System.Drawing.Size(291, 21);
            this.sbM4.TabIndex = 82;
            this.sbM4.ValueChanged += new System.EventHandler(this.sbM4_ValueChanged);
            // 
            // pbM3
            // 
            this.pbM3.Location = new System.Drawing.Point(54, 447);
            this.pbM3.Maximum = 255;
            this.pbM3.Name = "pbM3";
            this.pbM3.Size = new System.Drawing.Size(258, 23);
            this.pbM3.TabIndex = 81;
            // 
            // lblM3
            // 
            this.lblM3.AutoSize = true;
            this.lblM3.Location = new System.Drawing.Point(366, 453);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(13, 17);
            this.lblM3.TabIndex = 80;
            this.lblM3.Text = "-";
            // 
            // sbM3
            // 
            this.sbM3.Location = new System.Drawing.Point(39, 411);
            this.sbM3.Maximum = 255;
            this.sbM3.Name = "sbM3";
            this.sbM3.Size = new System.Drawing.Size(291, 21);
            this.sbM3.TabIndex = 79;
            this.sbM3.ValueChanged += new System.EventHandler(this.sbM3_ValueChanged);
            // 
            // pbM2
            // 
            this.pbM2.Location = new System.Drawing.Point(54, 373);
            this.pbM2.Maximum = 255;
            this.pbM2.Name = "pbM2";
            this.pbM2.Size = new System.Drawing.Size(258, 23);
            this.pbM2.TabIndex = 78;
            // 
            // lblM2
            // 
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(366, 378);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(13, 17);
            this.lblM2.TabIndex = 77;
            this.lblM2.Text = "-";
            // 
            // sbM2
            // 
            this.sbM2.Location = new System.Drawing.Point(39, 337);
            this.sbM2.Maximum = 255;
            this.sbM2.Name = "sbM2";
            this.sbM2.Size = new System.Drawing.Size(291, 21);
            this.sbM2.TabIndex = 76;
            this.sbM2.ValueChanged += new System.EventHandler(this.sbM2_ValueChanged);
            // 
            // pbM1
            // 
            this.pbM1.Location = new System.Drawing.Point(54, 298);
            this.pbM1.Maximum = 255;
            this.pbM1.Name = "pbM1";
            this.pbM1.Size = new System.Drawing.Size(258, 23);
            this.pbM1.TabIndex = 75;
            this.pbM1.Value = 16;
            // 
            // lblM1
            // 
            this.lblM1.AutoSize = true;
            this.lblM1.Location = new System.Drawing.Point(366, 298);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(13, 17);
            this.lblM1.TabIndex = 74;
            this.lblM1.Text = "-";
            // 
            // sbM1
            // 
            this.sbM1.Location = new System.Drawing.Point(39, 262);
            this.sbM1.Maximum = 255;
            this.sbM1.Name = "sbM1";
            this.sbM1.Size = new System.Drawing.Size(291, 21);
            this.sbM1.TabIndex = 73;
            this.sbM1.Value = 16;
            this.sbM1.ValueChanged += new System.EventHandler(this.sbM1_ValueChanged);
            // 
            // btnGetMotor
            // 
            this.btnGetMotor.Location = new System.Drawing.Point(221, 135);
            this.btnGetMotor.Name = "btnGetMotor";
            this.btnGetMotor.Size = new System.Drawing.Size(75, 65);
            this.btnGetMotor.TabIndex = 72;
            this.btnGetMotor.Text = "Get Motor";
            this.btnGetMotor.UseVisualStyleBackColor = true;
            this.btnGetMotor.Click += new System.EventHandler(this.btnGetMotor_Click);
            // 
            // btnSetMotor
            // 
            this.btnSetMotor.Location = new System.Drawing.Point(140, 135);
            this.btnSetMotor.Name = "btnSetMotor";
            this.btnSetMotor.Size = new System.Drawing.Size(75, 65);
            this.btnSetMotor.TabIndex = 71;
            this.btnSetMotor.Text = "Set Motor";
            this.btnSetMotor.UseVisualStyleBackColor = true;
            this.btnSetMotor.Click += new System.EventHandler(this.btnSetMotor_Click);
            // 
            // btnMixOff
            // 
            this.btnMixOff.Location = new System.Drawing.Point(358, 46);
            this.btnMixOff.Name = "btnMixOff";
            this.btnMixOff.Size = new System.Drawing.Size(75, 74);
            this.btnMixOff.TabIndex = 70;
            this.btnMixOff.Text = "Mix Off";
            this.btnMixOff.UseVisualStyleBackColor = true;
            this.btnMixOff.Click += new System.EventHandler(this.btnMixOff_Click);
            // 
            // btnMixOn
            // 
            this.btnMixOn.Location = new System.Drawing.Point(277, 46);
            this.btnMixOn.Name = "btnMixOn";
            this.btnMixOn.Size = new System.Drawing.Size(75, 74);
            this.btnMixOn.TabIndex = 69;
            this.btnMixOn.Text = "Mix On";
            this.btnMixOn.UseVisualStyleBackColor = true;
            this.btnMixOn.Click += new System.EventHandler(this.btnMixOn_Click);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(225, 87);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(13, 17);
            this.lblDevice.TabIndex = 68;
            this.lblDevice.Text = "-";
            // 
            // lblLdr
            // 
            this.lblLdr.AutoSize = true;
            this.lblLdr.Location = new System.Drawing.Point(225, 51);
            this.lblLdr.Name = "lblLdr";
            this.lblLdr.Size = new System.Drawing.Size(13, 17);
            this.lblLdr.TabIndex = 67;
            this.lblLdr.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Ldr";
            // 
            // btnGetDeviceCounts
            // 
            this.btnGetDeviceCounts.Location = new System.Drawing.Point(39, 37);
            this.btnGetDeviceCounts.Name = "btnGetDeviceCounts";
            this.btnGetDeviceCounts.Size = new System.Drawing.Size(107, 92);
            this.btnGetDeviceCounts.TabIndex = 64;
            this.btnGetDeviceCounts.Text = "Get Device Counts";
            this.btnGetDeviceCounts.UseVisualStyleBackColor = true;
            this.btnGetDeviceCounts.Click += new System.EventHandler(this.device_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 65);
            this.button1.TabIndex = 90;
            this.button1.Text = "Relesae";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(432, 374);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 21);
            this.checkBox1.TabIndex = 91;
            this.checkBox1.Text = "Ball 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(432, 404);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(65, 21);
            this.checkBox2.TabIndex = 92;
            this.checkBox2.Text = "Ball 3";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(432, 431);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(82, 21);
            this.checkBox3.TabIndex = 93;
            this.checkBox3.Text = "Release";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(432, 458);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(50, 21);
            this.checkBox4.TabIndex = 94;
            this.checkBox4.Text = "Mix";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(622, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 95;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(719, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 96;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(602, 102);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 276);
            this.listBox1.TabIndex = 97;
            // 
            // nudUnitNumber
            // 
            this.nudUnitNumber.Location = new System.Drawing.Point(152, 12);
            this.nudUnitNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudUnitNumber.Name = "nudUnitNumber";
            this.nudUnitNumber.Size = new System.Drawing.Size(120, 22);
            this.nudUnitNumber.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 99;
            this.label3.Text = "Unit Number :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(622, 458);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 83);
            this.button4.TabIndex = 100;
            this.button4.Text = "Linear Motor Test Başla";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(719, 458);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 83);
            this.button5.TabIndex = 101;
            this.button5.Text = "Linear Motor Test Durdur";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 553);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 102;
            this.label4.Text = "-";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(694, 391);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 103;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(694, 420);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(619, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 105;
            this.label5.Text = "Max Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(619, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 106;
            this.label6.Text = "Min Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(619, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 107;
            this.label7.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 108;
            this.label8.Text = "label8";
            // 
            // Managing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 579);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudUnitNumber);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGetFlags);
            this.Controls.Add(this.lblSM4);
            this.Controls.Add(this.lblSM3);
            this.Controls.Add(this.lblSM2);
            this.Controls.Add(this.lblSM1);
            this.Controls.Add(this.pbM4);
            this.Controls.Add(this.lblM4);
            this.Controls.Add(this.sbM4);
            this.Controls.Add(this.pbM3);
            this.Controls.Add(this.lblM3);
            this.Controls.Add(this.sbM3);
            this.Controls.Add(this.pbM2);
            this.Controls.Add(this.lblM2);
            this.Controls.Add(this.sbM2);
            this.Controls.Add(this.pbM1);
            this.Controls.Add(this.lblM1);
            this.Controls.Add(this.sbM1);
            this.Controls.Add(this.btnGetMotor);
            this.Controls.Add(this.btnSetMotor);
            this.Controls.Add(this.btnMixOff);
            this.Controls.Add(this.btnMixOn);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.lblLdr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetDeviceCounts);
            this.Name = "Managing";
            this.Text = "Managing";
            this.Load += new System.EventHandler(this.Managing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetFlags;
        private System.Windows.Forms.Label lblSM4;
        private System.Windows.Forms.Label lblSM3;
        private System.Windows.Forms.Label lblSM2;
        private System.Windows.Forms.Label lblSM1;
        private System.Windows.Forms.ProgressBar pbM4;
        private System.Windows.Forms.Label lblM4;
        private DevExpress.XtraEditors.HScrollBar sbM4;
        private System.Windows.Forms.ProgressBar pbM3;
        private System.Windows.Forms.Label lblM3;
        private DevExpress.XtraEditors.HScrollBar sbM3;
        private System.Windows.Forms.ProgressBar pbM2;
        private System.Windows.Forms.Label lblM2;
        private DevExpress.XtraEditors.HScrollBar sbM2;
        private System.Windows.Forms.ProgressBar pbM1;
        private System.Windows.Forms.Label lblM1;
        private DevExpress.XtraEditors.HScrollBar sbM1;
        private System.Windows.Forms.Button btnGetMotor;
        private System.Windows.Forms.Button btnSetMotor;
        private System.Windows.Forms.Button btnMixOff;
        private System.Windows.Forms.Button btnMixOn;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblLdr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetDeviceCounts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown nudUnitNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}