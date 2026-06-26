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
        private System.Windows.Forms.Label labelInputDateTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerInputDateTime;
        private System.Windows.Forms.CheckBox checkBoxDaylightSavings;
        private System.Windows.Forms.Button buttonConvertTime;
        private System.Windows.Forms.Label labelConversionResult;

        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSourceTimezone = new System.Windows.Forms.Label();
            this.comboBoxSourceTimezone = new System.Windows.Forms.ComboBox();
            this.labelTargetTimezone = new System.Windows.Forms.Label();
            this.comboBoxTargetTimezone = new System.Windows.Forms.ComboBox();
            this.labelInputDateTime = new System.Windows.Forms.Label();
            this.dateTimePickerInputDateTime = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDaylightSavings = new System.Windows.Forms.CheckBox();
            this.buttonConvertTime = new System.Windows.Forms.Button();
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
            // labelInputDateTime
            // 
            this.labelInputDateTime.AutoSize = true;
            this.labelInputDateTime.Location = new System.Drawing.Point(26, 160);
            this.labelInputDateTime.Name = "labelInputDateTime";
            this.labelInputDateTime.Size = new System.Drawing.Size(59, 15);
            this.labelInputDateTime.TabIndex = 5;
            this.labelInputDateTime.Text = "Input date & time:";
            // 
            // dateTimePickerInputDateTime
            // 
            this.dateTimePickerInputDateTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerInputDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerInputDateTime.Location = new System.Drawing.Point(150, 155);
            this.dateTimePickerInputDateTime.Name = "dateTimePickerInputDateTime";
            this.dateTimePickerInputDateTime.ShowUpDown = true;
            this.dateTimePickerInputDateTime.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerInputDateTime.TabIndex = 6;
            // 
            // checkBoxDaylightSavings
            // 
            this.checkBoxDaylightSavings.AutoSize = true;
            this.checkBoxDaylightSavings.Location = new System.Drawing.Point(26, 200);
            this.checkBoxDaylightSavings.Name = "checkBoxDaylightSavings";
            this.checkBoxDaylightSavings.Size = new System.Drawing.Size(143, 19);
            this.checkBoxDaylightSavings.TabIndex = 7;
            this.checkBoxDaylightSavings.Text = "Daylight savings apply";
            this.checkBoxDaylightSavings.UseVisualStyleBackColor = true;
            // 
            // buttonConvertTime
            // 
            this.buttonConvertTime.Location = new System.Drawing.Point(26, 245);
            this.buttonConvertTime.Name = "buttonConvertTime";
            this.buttonConvertTime.Size = new System.Drawing.Size(120, 30);
            this.buttonConvertTime.TabIndex = 8;
            this.buttonConvertTime.Text = "Convert";
            this.buttonConvertTime.UseVisualStyleBackColor = true;
            this.buttonConvertTime.Click += new System.EventHandler(this.buttonConvertTime_Click);
            // 
            // labelConversionResult
            // 
            this.labelConversionResult.AutoSize = true;
            this.labelConversionResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelConversionResult.Location = new System.Drawing.Point(26, 295);
            this.labelConversionResult.Name = "labelConversionResult";
            this.labelConversionResult.Size = new System.Drawing.Size(39, 19);
            this.labelConversionResult.TabIndex = 9;
            this.labelConversionResult.Text = "Result will appear here.";
            // 
            // TimeConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 380);
            this.Controls.Add(this.labelConversionResult);
            this.Controls.Add(this.buttonConvertTime);
            this.Controls.Add(this.checkBoxDaylightSavings);
            this.Controls.Add(this.dateTimePickerInputDateTime);
            this.Controls.Add(this.labelInputDateTime);
            this.Controls.Add(this.comboBoxTargetTimezone);
            this.Controls.Add(this.labelTargetTimezone);
            this.Controls.Add(this.comboBoxSourceTimezone);
            this.Controls.Add(this.labelSourceTimezone);
            this.Controls.Add(this.labelHeader);
            this.Name = "TimeConverterForm";
            this.Text = "Time Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

