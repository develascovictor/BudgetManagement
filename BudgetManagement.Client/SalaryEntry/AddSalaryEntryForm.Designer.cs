namespace BudgetManagement.Client.SalaryEntry
{
    partial class AddSalaryEntryForm
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.numericAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.datePickerDate = new System.Windows.Forms.DateTimePicker();
            this.numericRate = new System.Windows.Forms.NumericUpDown();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbxValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 48);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(12, 87);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 8;
            this.lblRate.Text = "Rate";
            // 
            // numericAmount
            // 
            this.numericAmount.Location = new System.Drawing.Point(12, 64);
            this.numericAmount.Name = "numericAmount";
            this.numericAmount.Size = new System.Drawing.Size(120, 20);
            this.numericAmount.TabIndex = 12;
            this.numericAmount.ValueChanged += new System.EventHandler(this.numericAmount_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "Date";
            // 
            // datePickerDate
            // 
            this.datePickerDate.Location = new System.Drawing.Point(12, 25);
            this.datePickerDate.Name = "datePickerDate";
            this.datePickerDate.Size = new System.Drawing.Size(200, 20);
            this.datePickerDate.TabIndex = 19;
            // 
            // numericRate
            // 
            this.numericRate.DecimalPlaces = 2;
            this.numericRate.Location = new System.Drawing.Point(12, 103);
            this.numericRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericRate.Name = "numericRate";
            this.numericRate.Size = new System.Drawing.Size(120, 20);
            this.numericRate.TabIndex = 13;
            this.numericRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRate.ValueChanged += new System.EventHandler(this.numericRate_ValueChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 126);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value";
            // 
            // tbxValue
            // 
            this.tbxValue.Enabled = false;
            this.tbxValue.Location = new System.Drawing.Point(12, 142);
            this.tbxValue.Name = "tbxValue";
            this.tbxValue.Size = new System.Drawing.Size(121, 20);
            this.tbxValue.TabIndex = 16;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(167, 176);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(71, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSalaryEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 211);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tbxValue);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.numericRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.datePickerDate);
            this.Controls.Add(this.numericAmount);
            this.Name = "AddSalaryEntryForm";
            this.Text = "Add Salary Entry";
            this.Load += new System.EventHandler(this.AddSalaryEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.NumericUpDown numericAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker datePickerDate;
        private System.Windows.Forms.NumericUpDown numericRate;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbxValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}