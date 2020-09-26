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
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBudgets
            // 
            this.gridBudgets.Location = new System.Drawing.Point(28, 56);
            this.gridBudgets.Name = "gridBudgets";
            this.gridBudgets.Size = new System.Drawing.Size(733, 329);
            this.gridBudgets.TabIndex = 0;
            this.gridBudgets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBudgets_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridBudgets);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridBudgets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBudgets;
    }
}