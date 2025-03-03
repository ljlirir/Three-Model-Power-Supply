namespace eTommensDC
{
    partial class ComSetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.recordChangeValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.recodeChange_checkBox = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ComWriteTimeOut_textBox = new System.Windows.Forms.TextBox();
            this.ComReadTimeOut_textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.com_baudRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_HostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_SampRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protect_V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.ComDelay_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com_PortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.protect_W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMWSname_comboBox = new System.Windows.Forms.ComboBox();
            this.COMBaudRate_comboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.COMDEL_button = new System.Windows.Forms.Button();
            this.ComADD_button = new System.Windows.Forms.Button();
            this.COMSampRate_textBox = new System.Windows.Forms.TextBox();
            this.protect_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_WSname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.COMPortName_comboBox = new System.Windows.Forms.ComboBox();
            this.COMHostAddress_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.com_ReadTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_WriteTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.COMdataGridView = new System.Windows.Forms.DataGridView();
            this.com_DelayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.COMdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // recordChangeValue
            // 
            this.recordChangeValue.DataPropertyName = "recordChangeValue";
            this.recordChangeValue.HeaderText = "记录变化数据";
            this.recordChangeValue.Name = "recordChangeValue";
            this.recordChangeValue.ReadOnly = true;
            this.recordChangeValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.recordChangeValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.recordChangeValue.Width = 110;
            // 
            // recodeChange_checkBox
            // 
            this.recodeChange_checkBox.AutoSize = true;
            this.recodeChange_checkBox.Checked = true;
            this.recodeChange_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recodeChange_checkBox.Location = new System.Drawing.Point(24, 104);
            this.recodeChange_checkBox.Name = "recodeChange_checkBox";
            this.recodeChange_checkBox.Size = new System.Drawing.Size(120, 16);
            this.recodeChange_checkBox.TabIndex = 36;
            this.recodeChange_checkBox.Text = "只记录变化的采样";
            this.recodeChange_checkBox.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(750, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(23, 12);
            this.label24.TabIndex = 26;
            this.label24.Text = "Hex";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(755, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "毫秒";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(392, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 24;
            this.label16.Text = "毫秒";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(581, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 23;
            this.label15.Text = "毫秒";
            // 
            // ComWriteTimeOut_textBox
            // 
            this.ComWriteTimeOut_textBox.Location = new System.Drawing.Point(691, 67);
            this.ComWriteTimeOut_textBox.Name = "ComWriteTimeOut_textBox";
            this.ComWriteTimeOut_textBox.Size = new System.Drawing.Size(58, 21);
            this.ComWriteTimeOut_textBox.TabIndex = 22;
            this.ComWriteTimeOut_textBox.Text = "500";
            // 
            // ComReadTimeOut_textBox
            // 
            this.ComReadTimeOut_textBox.Location = new System.Drawing.Point(516, 67);
            this.ComReadTimeOut_textBox.Name = "ComReadTimeOut_textBox";
            this.ComReadTimeOut_textBox.Size = new System.Drawing.Size(57, 21);
            this.ComReadTimeOut_textBox.TabIndex = 21;
            this.ComReadTimeOut_textBox.Text = "500";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "写超时";
            // 
            // com_baudRate
            // 
            this.com_baudRate.DataPropertyName = "BaudRate";
            this.com_baudRate.HeaderText = "波特率";
            this.com_baudRate.Name = "com_baudRate";
            this.com_baudRate.ReadOnly = true;
            this.com_baudRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_baudRate.Width = 60;
            // 
            // com_HostAddress
            // 
            this.com_HostAddress.DataPropertyName = "HostAddress";
            dataGridViewCellStyle1.Format = "X2";
            this.com_HostAddress.DefaultCellStyle = dataGridViewCellStyle1;
            this.com_HostAddress.HeaderText = "主机地址";
            this.com_HostAddress.Name = "com_HostAddress";
            this.com_HostAddress.ReadOnly = true;
            this.com_HostAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_HostAddress.Width = 60;
            // 
            // com_SampRate
            // 
            this.com_SampRate.DataPropertyName = "SampRate";
            this.com_SampRate.HeaderText = "采样频率";
            this.com_SampRate.Name = "com_SampRate";
            this.com_SampRate.ReadOnly = true;
            this.com_SampRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_SampRate.Width = 60;
            // 
            // protect_V
            // 
            this.protect_V.DataPropertyName = "protect_V";
            this.protect_V.HeaderText = "过压保护";
            this.protect_V.Name = "protect_V";
            this.protect_V.ReadOnly = true;
            this.protect_V.Visible = false;
            this.protect_V.Width = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "读超时：";
            // 
            // ComDelay_textBox
            // 
            this.ComDelay_textBox.Location = new System.Drawing.Point(319, 67);
            this.ComDelay_textBox.Name = "ComDelay_textBox";
            this.ComDelay_textBox.Size = new System.Drawing.Size(67, 21);
            this.ComDelay_textBox.TabIndex = 18;
            this.ComDelay_textBox.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "延迟：";
            // 
            // com_PortName
            // 
            this.com_PortName.DataPropertyName = "PortName";
            this.com_PortName.HeaderText = "端口";
            this.com_PortName.Name = "com_PortName";
            this.com_PortName.ReadOnly = true;
            this.com_PortName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_PortName.Width = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "毫秒/次";
            // 
            // protect_W
            // 
            this.protect_W.DataPropertyName = "protect_W";
            this.protect_W.HeaderText = "过功率保护";
            this.protect_W.Name = "protect_W";
            this.protect_W.ReadOnly = true;
            this.protect_W.Visible = false;
            this.protect_W.Width = 90;
            // 
            // COMWSname_comboBox
            // 
            this.COMWSname_comboBox.FormattingEnabled = true;
            this.COMWSname_comboBox.Location = new System.Drawing.Point(96, 29);
            this.COMWSname_comboBox.Name = "COMWSname_comboBox";
            this.COMWSname_comboBox.Size = new System.Drawing.Size(143, 20);
            this.COMWSname_comboBox.TabIndex = 15;
            this.COMWSname_comboBox.Text = "默认设备";
            // 
            // COMBaudRate_comboBox
            // 
            this.COMBaudRate_comboBox.FormattingEnabled = true;
            this.COMBaudRate_comboBox.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.COMBaudRate_comboBox.Location = new System.Drawing.Point(516, 29);
            this.COMBaudRate_comboBox.Name = "COMBaudRate_comboBox";
            this.COMBaudRate_comboBox.Size = new System.Drawing.Size(93, 20);
            this.COMBaudRate_comboBox.TabIndex = 14;
            this.COMBaudRate_comboBox.Text = "9600";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(436, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "波特率：";
            // 
            // COMDEL_button
            // 
            this.COMDEL_button.Location = new System.Drawing.Point(655, 139);
            this.COMDEL_button.Name = "COMDEL_button";
            this.COMDEL_button.Size = new System.Drawing.Size(75, 23);
            this.COMDEL_button.TabIndex = 11;
            this.COMDEL_button.Text = "删除";
            this.COMDEL_button.UseVisualStyleBackColor = true;
            // 
            // ComADD_button
            // 
            this.ComADD_button.Location = new System.Drawing.Point(559, 139);
            this.ComADD_button.Name = "ComADD_button";
            this.ComADD_button.Size = new System.Drawing.Size(75, 23);
            this.ComADD_button.TabIndex = 10;
            this.ComADD_button.Text = "添加配置";
            this.ComADD_button.UseVisualStyleBackColor = true;
            // 
            // COMSampRate_textBox
            // 
            this.COMSampRate_textBox.Location = new System.Drawing.Point(96, 67);
            this.COMSampRate_textBox.Name = "COMSampRate_textBox";
            this.COMSampRate_textBox.Size = new System.Drawing.Size(91, 21);
            this.COMSampRate_textBox.TabIndex = 9;
            this.COMSampRate_textBox.Text = "60";
            // 
            // protect_A
            // 
            this.protect_A.DataPropertyName = "protect_A";
            this.protect_A.HeaderText = "过流保护";
            this.protect_A.Name = "protect_A";
            this.protect_A.ReadOnly = true;
            this.protect_A.Visible = false;
            this.protect_A.Width = 80;
            // 
            // com_WSname
            // 
            this.com_WSname.DataPropertyName = "WSname";
            this.com_WSname.HeaderText = "设备名称";
            this.com_WSname.Name = "com_WSname";
            this.com_WSname.ReadOnly = true;
            this.com_WSname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_WSname.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recodeChange_checkBox);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.ComWriteTimeOut_textBox);
            this.groupBox1.Controls.Add(this.ComReadTimeOut_textBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ComDelay_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.COMWSname_comboBox);
            this.groupBox1.Controls.Add(this.COMBaudRate_comboBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.COMDEL_button);
            this.groupBox1.Controls.Add(this.ComADD_button);
            this.groupBox1.Controls.Add(this.COMSampRate_textBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.COMPortName_comboBox);
            this.groupBox1.Controls.Add(this.COMHostAddress_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 173);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "采样频率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "端口：";
            // 
            // COMPortName_comboBox
            // 
            this.COMPortName_comboBox.FormattingEnabled = true;
            this.COMPortName_comboBox.Location = new System.Drawing.Point(319, 29);
            this.COMPortName_comboBox.Name = "COMPortName_comboBox";
            this.COMPortName_comboBox.Size = new System.Drawing.Size(99, 20);
            this.COMPortName_comboBox.TabIndex = 6;
            this.COMPortName_comboBox.Text = "COM1";
            // 
            // COMHostAddress_textBox
            // 
            this.COMHostAddress_textBox.Location = new System.Drawing.Point(691, 29);
            this.COMHostAddress_textBox.Name = "COMHostAddress_textBox";
            this.COMHostAddress_textBox.Size = new System.Drawing.Size(58, 21);
            this.COMHostAddress_textBox.TabIndex = 5;
            this.COMHostAddress_textBox.Text = "01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(627, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "硬件地址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备名称：";
            // 
            // com_ReadTimeOut
            // 
            this.com_ReadTimeOut.DataPropertyName = "ReadTimeOut";
            this.com_ReadTimeOut.HeaderText = "读超时";
            this.com_ReadTimeOut.Name = "com_ReadTimeOut";
            this.com_ReadTimeOut.ReadOnly = true;
            this.com_ReadTimeOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_ReadTimeOut.Width = 60;
            // 
            // com_WriteTimeOut
            // 
            this.com_WriteTimeOut.DataPropertyName = "WriteTimeOut";
            this.com_WriteTimeOut.HeaderText = "写超时";
            this.com_WriteTimeOut.Name = "com_WriteTimeOut";
            this.com_WriteTimeOut.ReadOnly = true;
            this.com_WriteTimeOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_WriteTimeOut.Width = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.COMdataGridView);
            this.groupBox2.Location = new System.Drawing.Point(-2, -27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 304);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已有的配置";
            // 
            // COMdataGridView
            // 
            this.COMdataGridView.AllowUserToAddRows = false;
            this.COMdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.COMdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.COMdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.COMdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.com_WSname,
            this.recordChangeValue,
            this.com_PortName,
            this.com_baudRate,
            this.com_HostAddress,
            this.com_SampRate,
            this.protect_V,
            this.protect_A,
            this.protect_W,
            this.com_DelayTime,
            this.com_ReadTimeOut,
            this.com_WriteTimeOut});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.COMdataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.COMdataGridView.Location = new System.Drawing.Point(24, 38);
            this.COMdataGridView.MultiSelect = false;
            this.COMdataGridView.Name = "COMdataGridView";
            this.COMdataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.COMdataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.COMdataGridView.RowTemplate.Height = 23;
            this.COMdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.COMdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.COMdataGridView.Size = new System.Drawing.Size(718, 266);
            this.COMdataGridView.TabIndex = 0;
            // 
            // com_DelayTime
            // 
            this.com_DelayTime.DataPropertyName = "DelayTime";
            this.com_DelayTime.HeaderText = "延迟时间";
            this.com_DelayTime.Name = "com_DelayTime";
            this.com_DelayTime.ReadOnly = true;
            this.com_DelayTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.com_DelayTime.Width = 70;
            // 
            // CollecteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollecteForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.COMdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewCheckBoxColumn recordChangeValue;
        private System.Windows.Forms.CheckBox recodeChange_checkBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ComWriteTimeOut_textBox;
        private System.Windows.Forms.TextBox ComReadTimeOut_textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_baudRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_HostAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_SampRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn protect_V;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ComDelay_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_PortName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn protect_W;
        private System.Windows.Forms.ComboBox COMWSname_comboBox;
        private System.Windows.Forms.ComboBox COMBaudRate_comboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button COMDEL_button;
        private System.Windows.Forms.Button ComADD_button;
        private System.Windows.Forms.TextBox COMSampRate_textBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn protect_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_WSname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox COMPortName_comboBox;
        private System.Windows.Forms.TextBox COMHostAddress_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_ReadTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_WriteTimeOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView COMdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_DelayTime;
    }
}