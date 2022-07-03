namespace GSApp1
{
    partial class KASHIWA
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KASHIWA));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClode = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.tbxRxData = new System.Windows.Forms.TextBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.rbCRLF = new System.Windows.Forms.RadioButton();
            this.rbLF = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.tbxTxData = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnScan
            // 
            this.btnScan.AccessibleName = "";
            this.btnScan.Location = new System.Drawing.Point(58, 40);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(118, 51);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "再スキャン";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(489, 40);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(118, 51);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "開く";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClode
            // 
            this.btnClode.Enabled = false;
            this.btnClode.Location = new System.Drawing.Point(616, 40);
            this.btnClode.Name = "btnClode";
            this.btnClode.Size = new System.Drawing.Size(118, 51);
            this.btnClode.TabIndex = 2;
            this.btnClode.Text = "閉じる";
            this.btnClode.UseVisualStyleBackColor = true;
            this.btnClode.Click += new System.EventHandler(this.btnClode_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(616, 113);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(118, 51);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "送信";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(616, 185);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 51);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(182, 56);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(163, 20);
            this.cmbCOMPort.TabIndex = 5;
            this.cmbCOMPort.Text = "-COMを選択-";
            // 
            // tbxRxData
            // 
            this.tbxRxData.Location = new System.Drawing.Point(58, 185);
            this.tbxRxData.Multiline = true;
            this.tbxRxData.Name = "tbxRxData";
            this.tbxRxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRxData.Size = new System.Drawing.Size(549, 237);
            this.tbxRxData.TabIndex = 7;
            this.tbxRxData.TextChanged += new System.EventHandler(this.tbxRxData_TextChanged);
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200"});
            this.cmbBaud.Location = new System.Drawing.Point(355, 56);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(121, 20);
            this.cmbBaud.TabIndex = 8;
            this.cmbBaud.Text = "-ボーレート選択-";
            this.cmbBaud.SelectedIndexChanged += new System.EventHandler(this.cmbBaud_SelectedIndexChanged);
            // 
            // rbCRLF
            // 
            this.rbCRLF.AutoSize = true;
            this.rbCRLF.Checked = true;
            this.rbCRLF.Location = new System.Drawing.Point(331, 148);
            this.rbCRLF.Name = "rbCRLF";
            this.rbCRLF.Size = new System.Drawing.Size(52, 16);
            this.rbCRLF.TabIndex = 9;
            this.rbCRLF.TabStop = true;
            this.rbCRLF.Text = "CRLF";
            this.rbCRLF.UseVisualStyleBackColor = true;
            // 
            // rbLF
            // 
            this.rbLF.AutoSize = true;
            this.rbLF.Location = new System.Drawing.Point(425, 148);
            this.rbLF.Name = "rbLF";
            this.rbLF.Size = new System.Drawing.Size(36, 16);
            this.rbLF.TabIndex = 10;
            this.rbLF.Text = "LF";
            this.rbLF.UseVisualStyleBackColor = true;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(519, 148);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(49, 16);
            this.rbNone.TabIndex = 11;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // tbxTxData
            // 
            this.tbxTxData.Location = new System.Drawing.Point(58, 113);
            this.tbxTxData.Mask = "AA AA AA AA AA AA AA AA AA AA AA AA AA AA";
            this.tbxTxData.Name = "tbxTxData";
            this.tbxTxData.Size = new System.Drawing.Size(549, 19);
            this.tbxTxData.TabIndex = 12;
            this.tbxTxData.Text = "0000000000000000000000000000";
            // 
            // KASHIWA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxTxData);
            this.Controls.Add(this.rbNone);
            this.Controls.Add(this.rbLF);
            this.Controls.Add(this.rbCRLF);
            this.Controls.Add(this.cmbBaud);
            this.Controls.Add(this.tbxRxData);
            this.Controls.Add(this.cmbCOMPort);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClode);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KASHIWA";
            this.Text = "KASHIWA-GS-APP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClode;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbCOMPort;
        private System.Windows.Forms.TextBox tbxRxData;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.RadioButton rbCRLF;
        private System.Windows.Forms.RadioButton rbLF;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.MaskedTextBox tbxTxData;
    }
}

