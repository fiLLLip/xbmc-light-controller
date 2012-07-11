namespace xbmclightsharp
{
    partial class Settings
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.trackDimLevelPause = new System.Windows.Forms.TrackBar();
            this.trackDimLevelPlay = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.trackDimLevelStop = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDimStop = new System.Windows.Forms.Label();
            this.lblDimPlay = new System.Windows.Forms.Label();
            this.lblDimPause = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioEden = new System.Windows.Forms.RadioButton();
            this.radioDharma = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelStop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(75, 64);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(186, 20);
            this.txtIP.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(186, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(75, 116);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(186, 20);
            this.txtUser.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(75, 90);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(186, 20);
            this.txtPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(186, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dimlevel\r\non Pause";
            // 
            // trackDimLevelPause
            // 
            this.trackDimLevelPause.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackDimLevelPause.LargeChange = 20;
            this.trackDimLevelPause.Location = new System.Drawing.Point(75, 171);
            this.trackDimLevelPause.Maximum = 100;
            this.trackDimLevelPause.Name = "trackDimLevelPause";
            this.trackDimLevelPause.Size = new System.Drawing.Size(147, 42);
            this.trackDimLevelPause.SmallChange = 10;
            this.trackDimLevelPause.TabIndex = 4;
            this.trackDimLevelPause.TickFrequency = 10;
            this.trackDimLevelPause.Value = 50;
            this.trackDimLevelPause.ValueChanged += new System.EventHandler(this.trackDimLevelPause_ValueChanged);
            // 
            // trackDimLevelPlay
            // 
            this.trackDimLevelPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackDimLevelPlay.LargeChange = 20;
            this.trackDimLevelPlay.Location = new System.Drawing.Point(75, 212);
            this.trackDimLevelPlay.Maximum = 100;
            this.trackDimLevelPlay.Name = "trackDimLevelPlay";
            this.trackDimLevelPlay.Size = new System.Drawing.Size(147, 42);
            this.trackDimLevelPlay.SmallChange = 10;
            this.trackDimLevelPlay.TabIndex = 5;
            this.trackDimLevelPlay.TickFrequency = 10;
            this.trackDimLevelPlay.Value = 50;
            this.trackDimLevelPlay.ValueChanged += new System.EventHandler(this.trackDimLevelPlay_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Dimlevel\r\non Play";
            // 
            // trackDimLevelStop
            // 
            this.trackDimLevelStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackDimLevelStop.LargeChange = 20;
            this.trackDimLevelStop.Location = new System.Drawing.Point(75, 255);
            this.trackDimLevelStop.Maximum = 100;
            this.trackDimLevelStop.Name = "trackDimLevelStop";
            this.trackDimLevelStop.Size = new System.Drawing.Size(147, 42);
            this.trackDimLevelStop.SmallChange = 10;
            this.trackDimLevelStop.TabIndex = 6;
            this.trackDimLevelStop.TickFrequency = 10;
            this.trackDimLevelStop.Value = 50;
            this.trackDimLevelStop.ValueChanged += new System.EventHandler(this.trackDimLevelStop_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Dimlevel\r\non Stop";
            // 
            // lblDimStop
            // 
            this.lblDimStop.AutoSize = true;
            this.lblDimStop.Location = new System.Drawing.Point(231, 259);
            this.lblDimStop.Name = "lblDimStop";
            this.lblDimStop.Size = new System.Drawing.Size(21, 13);
            this.lblDimStop.TabIndex = 18;
            this.lblDimStop.Text = "0%";
            // 
            // lblDimPlay
            // 
            this.lblDimPlay.AutoSize = true;
            this.lblDimPlay.Location = new System.Drawing.Point(231, 216);
            this.lblDimPlay.Name = "lblDimPlay";
            this.lblDimPlay.Size = new System.Drawing.Size(21, 13);
            this.lblDimPlay.TabIndex = 17;
            this.lblDimPlay.Text = "0%";
            // 
            // lblDimPause
            // 
            this.lblDimPause.AutoSize = true;
            this.lblDimPause.Location = new System.Drawing.Point(231, 175);
            this.lblDimPause.Name = "lblDimPause";
            this.lblDimPause.Size = new System.Drawing.Size(21, 13);
            this.lblDimPause.TabIndex = 16;
            this.lblDimPause.Text = "0%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioEden);
            this.groupBox1.Controls.Add(this.radioDharma);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 45);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XBCM Version";
            // 
            // radioEden
            // 
            this.radioEden.AutoSize = true;
            this.radioEden.Location = new System.Drawing.Point(98, 20);
            this.radioEden.Name = "radioEden";
            this.radioEden.Size = new System.Drawing.Size(77, 17);
            this.radioEden.TabIndex = 1;
            this.radioEden.Text = "Eden (v11)";
            this.radioEden.UseVisualStyleBackColor = true;
            this.radioEden.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioDharma
            // 
            this.radioDharma.AutoSize = true;
            this.radioDharma.Checked = true;
            this.radioDharma.Location = new System.Drawing.Point(7, 20);
            this.radioDharma.Name = "radioDharma";
            this.radioDharma.Size = new System.Drawing.Size(89, 17);
            this.radioDharma.TabIndex = 0;
            this.radioDharma.TabStop = true;
            this.radioDharma.Text = "Dharma (v10)";
            this.radioDharma.UseVisualStyleBackColor = true;
            this.radioDharma.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDimStop);
            this.Controls.Add(this.lblDimPlay);
            this.Controls.Add(this.lblDimPause);
            this.Controls.Add(this.trackDimLevelStop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackDimLevelPlay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackDimLevelPause);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtIP);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimLevelStop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackDimLevelPause;
        private System.Windows.Forms.TrackBar trackDimLevelPlay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackDimLevelStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDimStop;
        private System.Windows.Forms.Label lblDimPlay;
        private System.Windows.Forms.Label lblDimPause;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioEden;
        private System.Windows.Forms.RadioButton radioDharma;
    }
}