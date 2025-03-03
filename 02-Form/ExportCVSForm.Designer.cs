namespace Sample_Project._02_Form
{
    partial class ExportCVSForm
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.path_button = new System.Windows.Forms.Button();
            this.path_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AllDate_checkBox = new System.Windows.Forms.CheckBox();
            this.AllDev_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.End_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Exp_button = new System.Windows.Forms.Button();
            this.begin_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.MName_comboBox = new System.Windows.Forms.ComboBox();
            this.CSV_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Epre_label = new System.Windows.Forms.Label();
            this.Exp_progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // path_button
            // 
            this.path_button.Location = new System.Drawing.Point(290, 214);
            this.path_button.Name = "path_button";
            this.path_button.Size = new System.Drawing.Size(35, 23);
            this.path_button.TabIndex = 41;
            this.path_button.Text = "……";
            this.path_button.UseVisualStyleBackColor = true;
            // 
            // path_textBox
            // 
            this.path_textBox.Location = new System.Drawing.Point(130, 214);
            this.path_textBox.Name = "path_textBox";
            this.path_textBox.Size = new System.Drawing.Size(154, 21);
            this.path_textBox.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "存放在：";
            // 
            // AllDate_checkBox
            // 
            this.AllDate_checkBox.AutoSize = true;
            this.AllDate_checkBox.Location = new System.Drawing.Point(130, 179);
            this.AllDate_checkBox.Name = "AllDate_checkBox";
            this.AllDate_checkBox.Size = new System.Drawing.Size(72, 16);
            this.AllDate_checkBox.TabIndex = 38;
            this.AllDate_checkBox.Text = "全部日期";
            this.AllDate_checkBox.UseVisualStyleBackColor = true;
            // 
            // AllDev_checkBox
            // 
            this.AllDev_checkBox.AutoSize = true;
            this.AllDev_checkBox.Location = new System.Drawing.Point(130, 70);
            this.AllDev_checkBox.Name = "AllDev_checkBox";
            this.AllDev_checkBox.Size = new System.Drawing.Size(72, 16);
            this.AllDev_checkBox.TabIndex = 37;
            this.AllDev_checkBox.Text = "所有设备";
            this.AllDev_checkBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "设备名称";
            // 
            // End_dateTimePicker
            // 
            this.End_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.End_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.End_dateTimePicker.Location = new System.Drawing.Point(130, 151);
            this.End_dateTimePicker.Name = "End_dateTimePicker";
            this.End_dateTimePicker.Size = new System.Drawing.Size(151, 21);
            this.End_dateTimePicker.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "结束日期：";
            // 
            // Exp_button
            // 
            this.Exp_button.Location = new System.Drawing.Point(250, 285);
            this.Exp_button.Name = "Exp_button";
            this.Exp_button.Size = new System.Drawing.Size(75, 23);
            this.Exp_button.TabIndex = 33;
            this.Exp_button.Text = "导出";
            this.Exp_button.UseVisualStyleBackColor = true;
            // 
            // begin_dateTimePicker
            // 
            this.begin_dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.begin_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.begin_dateTimePicker.Location = new System.Drawing.Point(130, 109);
            this.begin_dateTimePicker.Name = "begin_dateTimePicker";
            this.begin_dateTimePicker.Size = new System.Drawing.Size(154, 21);
            this.begin_dateTimePicker.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "开始日期";
            // 
            // MName_comboBox
            // 
            this.MName_comboBox.FormattingEnabled = true;
            this.MName_comboBox.Location = new System.Drawing.Point(130, 44);
            this.MName_comboBox.Name = "MName_comboBox";
            this.MName_comboBox.Size = new System.Drawing.Size(151, 20);
            this.MName_comboBox.TabIndex = 30;
            // 
            // Epre_label
            // 
            this.Epre_label.AutoSize = true;
            this.Epre_label.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Epre_label.Location = new System.Drawing.Point(36, 291);
            this.Epre_label.Name = "Epre_label";
            this.Epre_label.Size = new System.Drawing.Size(41, 12);
            this.Epre_label.TabIndex = 43;
            this.Epre_label.Text = "label5";
            // 
            // Exp_progressBar
            // 
            this.Exp_progressBar.Location = new System.Drawing.Point(37, 262);
            this.Exp_progressBar.Name = "Exp_progressBar";
            this.Exp_progressBar.Size = new System.Drawing.Size(190, 23);
            this.Exp_progressBar.TabIndex = 42;
            this.Exp_progressBar.Visible = false;
            // 
            // ExportCVSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 323);
            this.Controls.Add(this.path_button);
            this.Controls.Add(this.path_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AllDate_checkBox);
            this.Controls.Add(this.AllDev_checkBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.End_dateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Exp_button);
            this.Controls.Add(this.begin_dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MName_comboBox);
            this.Controls.Add(this.Epre_label);
            this.Controls.Add(this.Exp_progressBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportCVSForm";
            this.Text = "导出采样数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button path_button;
        private System.Windows.Forms.TextBox path_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox AllDate_checkBox;
        private System.Windows.Forms.CheckBox AllDev_checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker End_dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Exp_button;
        private System.Windows.Forms.DateTimePicker begin_dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MName_comboBox;
        private System.Windows.Forms.SaveFileDialog CSV_saveFileDialog;
        public System.Windows.Forms.Label Epre_label;
        public System.Windows.Forms.ProgressBar Exp_progressBar;
    }
}