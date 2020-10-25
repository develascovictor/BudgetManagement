namespace BudgetManagement.Client.SalaryEntry
{
    partial class AssignSalaryEntryForm
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
            this.cbxBudgets = new System.Windows.Forms.ComboBox();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.tbxAvailable = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxBudgets
            // 
            this.cbxBudgets.FormattingEnabled = true;
            this.cbxBudgets.Location = new System.Drawing.Point(218, 24);
            this.cbxBudgets.Name = "cbxBudgets";
            this.cbxBudgets.Size = new System.Drawing.Size(156, 21);
            this.cbxBudgets.TabIndex = 0;
            // 
            // numericValue
            // 
            this.numericValue.Location = new System.Drawing.Point(218, 51);
            this.numericValue.Name = "numericValue";
            this.numericValue.Size = new System.Drawing.Size(156, 20);
            this.numericValue.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(218, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(299, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(12, 9);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(50, 13);
            this.lblAvailable.TabIndex = 24;
            this.lblAvailable.Text = "Available";
            // 
            // tbxAvailable
            // 
            this.tbxAvailable.Enabled = false;
            this.tbxAvailable.Location = new System.Drawing.Point(12, 25);
            this.tbxAvailable.Name = "tbxAvailable";
            this.tbxAvailable.Size = new System.Drawing.Size(87, 20);
            this.tbxAvailable.TabIndex = 25;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(55, 156);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 26;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(209, 156);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 27;
            // 
            // AssignSalaryEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 335);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tbxAvailable);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numericValue);
            this.Controls.Add(this.cbxBudgets);
            this.Name = "AssignSalaryEntryForm";
            this.Text = "AssignSalaryEntryForm";
            this.Load += new System.EventHandler(this.AssignSalaryEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxBudgets;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.TextBox tbxAvailable;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox listBox1;
    }
}