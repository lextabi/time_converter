namespace time_converter_app
{
    partial class TimeConverterForm
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
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSourceTimezone;
        private System.Windows.Forms.ComboBox comboBoxSourceTimezone;
        private System.Windows.Forms.Label labelTargetTimezone;
        private System.Windows.Forms.ComboBox comboBoxTargetTimezone;
        private System.Windows.Forms.Label labelDateLegend;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelTimeLegend;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Button buttonRefreshDateTime;
        private System.Windows.Forms.CheckBox checkBoxDaylightSavings;
        private System.Windows.Forms.Button buttonConvertTime;
        private System.Windows.Forms.Button buttonResetForm;
        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.Label labelConversionResult;

        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSourceTimezone = new System.Windows.Forms.Label();
            this.comboBoxSourceTimezone = new System.Windows.Forms.ComboBox();
            this.labelTargetTimezone = new System.Windows.Forms.Label();
            this.comboBoxTargetTimezone = new System.Windows.Forms.ComboBox();
            this.labelDateLegend = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelTimeLegend = new System.Windows.Forms.Label();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.buttonRefreshDateTime = new System.Windows.Forms.Button();
            this.checkBoxDaylightSavings = new System.Windows.Forms.CheckBox();
            this.buttonConvertTime = new System.Windows.Forms.Button();
            this.buttonResetForm = new System.Windows.Forms.Button();
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.labelConversionResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.Location = new System.Drawing.Point(26, 22);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(310, 21);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Convert a time from one time zone to another";
            // 
            // labelSourceTimezone
            // 
            this.labelSourceTimezone.AutoSize = true;
            this.labelSourceTimezone.Location = new System.Drawing.Point(26, 70);
            this.labelSourceTimezone.Name = "labelSourceTimezone";
            this.labelSourceTimezone.Size = new System.Drawing.Size(79, 15);
            this.labelSourceTimezone.TabIndex = 1;
            this.labelSourceTimezone.Text = "Your timezone:";
            // 
            // comboBoxSourceTimezone
            // 
            this.comboBoxSourceTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSourceTimezone.FormattingEnabled = true;
            this.comboBoxSourceTimezone.Location = new System.Drawing.Point(150, 67);
            this.comboBoxSourceTimezone.Name = "comboBoxSourceTimezone";
            this.comboBoxSourceTimezone.Size = new System.Drawing.Size(500, 23);
            this.comboBoxSourceTimezone.TabIndex = 2;
            // 
            // labelTargetTimezone
            // 
            this.labelTargetTimezone.AutoSize = true;
            this.labelTargetTimezone.Location = new System.Drawing.Point(26, 115);
            this.labelTargetTimezone.Name = "labelTargetTimezone";
            this.labelTargetTimezone.Size = new System.Drawing.Size(74, 15);
            this.labelTargetTimezone.TabIndex = 3;
            this.labelTargetTimezone.Text = "Convert to:";
            // 
            // comboBoxTargetTimezone
            // 
            this.comboBoxTargetTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTargetTimezone.FormattingEnabled = true;
            this.comboBoxTargetTimezone.Location = new System.Drawing.Point(150, 112);
            this.comboBoxTargetTimezone.Name = "comboBoxTargetTimezone";
            this.comboBoxTargetTimezone.Size = new System.Drawing.Size(500, 23);
            this.comboBoxTargetTimezone.TabIndex = 4;
            // 
            // labelDateLegend
            // 
            this.labelDateLegend.AutoSize = true;
            this.labelDateLegend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDateLegend.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelDateLegend.Location = new System.Drawing.Point(26, 160);
            this.labelDateLegend.Name = "labelDateLegend";
            this.labelDateLegend.Size = new System.Drawing.Size(35, 15);
            this.labelDateLegend.TabIndex = 5;
            this.labelDateLegend.Text = "Date:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(70, 155);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerDate.TabIndex = 6;
            // 
            // labelTimeLegend
            // 
            this.labelTimeLegend.AutoSize = true;
            this.labelTimeLegend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeLegend.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTimeLegend.Location = new System.Drawing.Point(210, 160);
            this.labelTimeLegend.Name = "labelTimeLegend";
            this.labelTimeLegend.Size = new System.Drawing.Size(39, 15);
            this.labelTimeLegend.TabIndex = 7;
            this.labelTimeLegend.Text = "Time:";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.CustomFormat = "HH:mm";
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Location = new System.Drawing.Point(255, 155);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(80, 23);
            this.dateTimePickerTime.TabIndex = 8;
            // 
            // buttonRefreshDateTime
            // 
            this.buttonRefreshDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonRefreshDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshDateTime.ForeColor = System.Drawing.Color.White;
            this.buttonRefreshDateTime.Location = new System.Drawing.Point(355, 152);
            this.buttonRefreshDateTime.Name = "buttonRefreshDateTime";
            this.buttonRefreshDateTime.Size = new System.Drawing.Size(120, 27);
            this.buttonRefreshDateTime.TabIndex = 9;
            this.buttonRefreshDateTime.Text = "Refresh now";
            this.buttonRefreshDateTime.UseVisualStyleBackColor = false;
            this.buttonRefreshDateTime.Click += new System.EventHandler(this.buttonRefreshDateTime_Click);
            // 
            // checkBoxDaylightSavings
            // 
            this.checkBoxDaylightSavings.AutoSize = true;
            this.checkBoxDaylightSavings.Location = new System.Drawing.Point(26, 200);
            this.checkBoxDaylightSavings.Name = "checkBoxDaylightSavings";
            this.checkBoxDaylightSavings.Size = new System.Drawing.Size(143, 19);
            this.checkBoxDaylightSavings.TabIndex = 8;
            this.checkBoxDaylightSavings.Text = "Daylight savings apply";
            this.checkBoxDaylightSavings.UseVisualStyleBackColor = true;
            // 
            // buttonConvertTime
            // 
            this.buttonConvertTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonConvertTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConvertTime.ForeColor = System.Drawing.Color.White;
            this.buttonConvertTime.Location = new System.Drawing.Point(200, 245);
            this.buttonConvertTime.Name = "buttonConvertTime";
            this.buttonConvertTime.Size = new System.Drawing.Size(100, 32);
            this.buttonConvertTime.TabIndex = 10;
            this.buttonConvertTime.Text = "Convert";
            this.buttonConvertTime.UseVisualStyleBackColor = false;
            this.buttonConvertTime.Click += new System.EventHandler(this.buttonConvertTime_Click);
            // 
            // buttonResetForm
            // 
            this.buttonResetForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.buttonResetForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetForm.ForeColor = System.Drawing.Color.White;
            this.buttonResetForm.Location = new System.Drawing.Point(310, 245);
            this.buttonResetForm.Name = "buttonResetForm";
            this.buttonResetForm.Size = new System.Drawing.Size(100, 32);
            this.buttonResetForm.TabIndex = 11;
            this.buttonResetForm.Text = "Reset";
            this.buttonResetForm.UseVisualStyleBackColor = false;
            this.buttonResetForm.Click += new System.EventHandler(this.buttonResetForm_Click);
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.buttonExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitApp.ForeColor = System.Drawing.Color.White;
            this.buttonExitApp.Location = new System.Drawing.Point(420, 245);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(100, 32);
            this.buttonExitApp.TabIndex = 12;
            this.buttonExitApp.Text = "Exit";
            this.buttonExitApp.UseVisualStyleBackColor = false;
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);
            // 
            // labelConversionResult
            // 
            this.labelConversionResult.AutoSize = false;
            this.labelConversionResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelConversionResult.Location = new System.Drawing.Point(20, 295);
            this.labelConversionResult.Name = "labelConversionResult";
            this.labelConversionResult.Size = new System.Drawing.Size(680, 50);
            this.labelConversionResult.TabIndex = 13;
            this.labelConversionResult.Text = "Result will appear here.";
            this.labelConversionResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelConversionResult.Padding = new System.Windows.Forms.Padding(6);
            this.labelConversionResult.BackColor = System.Drawing.Color.White;
            this.labelConversionResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(720, 365);
            this.Controls.Add(this.labelConversionResult);
            this.Controls.Add(this.buttonExitApp);
            this.Controls.Add(this.buttonResetForm);
            this.Controls.Add(this.buttonConvertTime);
            this.Controls.Add(this.checkBoxDaylightSavings);
            this.Controls.Add(this.buttonRefreshDateTime);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.labelTimeLegend);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.labelDateLegend);
            this.Controls.Add(this.comboBoxTargetTimezone);
            this.Controls.Add(this.labelTargetTimezone);
            this.Controls.Add(this.comboBoxSourceTimezone);
            this.Controls.Add(this.labelSourceTimezone);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeConverterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

