namespace BudgetManagement.Client.SalaryEntry
{
    partial class SalaryEntriesForm
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
            this.gridSalaryEntries = new System.Windows.Forms.DataGridView();
            this.btnAddSalaryEntry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSalaryEntries
            // 
            this.gridSalaryEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSalaryEntries.Location = new System.Drawing.Point(12, 71);
            this.gridSalaryEntries.Name = "gridSalaryEntries";
            this.gridSalaryEntries.Size = new System.Drawing.Size(776, 367);
            this.gridSalaryEntries.TabIndex = 0;
            this.gridSalaryEntries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalaryEntries_CellContentClick);
            // 
            // btnAddSalaryEntry
            // 
            this.btnAddSalaryEntry.Location = new System.Drawing.Point(662, 12);
            this.btnAddSalaryEntry.Name = "btnAddSalaryEntry";
            this.btnAddSalaryEntry.Size = new System.Drawing.Size(126, 23);
            this.btnAddSalaryEntry.TabIndex = 3;
            this.btnAddSalaryEntry.Text = "Add Salary Entry";
            this.btnAddSalaryEntry.UseVisualStyleBackColor = true;
            this.btnAddSalaryEntry.Click += new System.EventHandler(this.btnAddSalaryEntry_Click);
            // 
            // SalaryEntriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddSalaryEntry);
            this.Controls.Add(this.gridSalaryEntries);
            this.Name = "SalaryEntriesForm";
            this.Text = "Salary Entries";
            this.Load += new System.EventHandler(this.SalaryEntriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSalaryEntries;
        private System.Windows.Forms.Button btnAddSalaryEntry;
    }
}