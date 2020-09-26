namespace BudgetManagement.Client
{
    partial class TransactionsByBudgetForm
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
            this.gridTransactions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTransactions
            // 
            this.gridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransactions.Location = new System.Drawing.Point(12, 114);
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.Size = new System.Drawing.Size(776, 324);
            this.gridTransactions.TabIndex = 0;
            // 
            // TransactionsByBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridTransactions);
            this.Name = "TransactionsByBudgetForm";
            this.Text = "TransactionsByBudgetForm";
            this.Load += new System.EventHandler(this.TransactionsByBudgetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTransactions;
    }
}