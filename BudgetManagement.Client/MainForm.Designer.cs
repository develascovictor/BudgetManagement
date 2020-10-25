using System.ComponentModel;
using System.Windows.Forms;

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
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGoToSalaryEntries = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBudgets
            // 
            this.gridBudgets.Location = new System.Drawing.Point(13, 140);
            this.gridBudgets.Name = "gridBudgets";
            this.gridBudgets.Size = new System.Drawing.Size(847, 329);
            this.gridBudgets.TabIndex = 0;
            this.gridBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBudgets_CellContentClick);
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(12, 114);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(230, 20);
            this.tbxFilter.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(248, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGoToSalaryEntries
            // 
            this.btnGoToSalaryEntries.Location = new System.Drawing.Point(732, 12);
            this.btnGoToSalaryEntries.Name = "btnGoToSalaryEntries";
            this.btnGoToSalaryEntries.Size = new System.Drawing.Size(127, 23);
            this.btnGoToSalaryEntries.TabIndex = 5;
            this.btnGoToSalaryEntries.Text = "Salary Entries";
            this.btnGoToSalaryEntries.UseVisualStyleBackColor = true;
            this.btnGoToSalaryEntries.Click += new System.EventHandler(this.btnGoToSalaryEntries_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 481);
            this.Controls.Add(this.btnGoToSalaryEntries);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.gridBudgets);
            this.Name = "MainForm";
            this.Text = "Budgets";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBudgets;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Button btnSearch;
        private Button btnGoToSalaryEntries;
    }
}