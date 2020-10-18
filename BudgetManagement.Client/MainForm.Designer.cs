using System.ComponentModel;

namespace BudgetManagement.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.gridBudgets = new System.Windows.Forms.DataGridView();
            this.btnAddSalaryEntry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBudgets
            // 
            this.gridBudgets.Location = new System.Drawing.Point(12, 50);
            this.gridBudgets.Name = "gridBudgets";
            this.gridBudgets.Size = new System.Drawing.Size(847, 329);
            this.gridBudgets.TabIndex = 0;
            this.gridBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBudgets_CellContentClick);
            // 
            // btnAddSalaryEntry
            // 
            this.btnAddSalaryEntry.Location = new System.Drawing.Point(733, 12);
            this.btnAddSalaryEntry.Name = "btnAddSalaryEntry";
            this.btnAddSalaryEntry.Size = new System.Drawing.Size(126, 23);
            this.btnAddSalaryEntry.TabIndex = 2;
            this.btnAddSalaryEntry.Text = "Add Salary Entry";
            this.btnAddSalaryEntry.UseVisualStyleBackColor = true;
            this.btnAddSalaryEntry.Click += new System.EventHandler(this.btnAddSalaryEntry_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 391);
            this.Controls.Add(this.btnAddSalaryEntry);
            this.Controls.Add(this.gridBudgets);
            this.Name = "MainForm";
            this.Text = "Budgets";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBudgets;
        private System.Windows.Forms.Button btnAddSalaryEntry;
    }
}