namespace BudgetManagement.Client.Transaction
{
    partial class AddTransactionForm
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
            this.datePickerDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.ddlTransactionType = new System.Windows.Forms.ComboBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxNotes = new System.Windows.Forms.TextBox();
            this.numericExpenseAmount = new System.Windows.Forms.NumericUpDown();
            this.numericExpenseRate = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxExpenseValue = new System.Windows.Forms.TextBox();
            this.gpbExpense = new System.Windows.Forms.GroupBox();
            this.gpbIncome = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxIncomeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericIncomeAmount = new System.Windows.Forms.NumericUpDown();
            this.numericIncomeRate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseRate)).BeginInit();
            this.gpbExpense.SuspendLayout();
            this.gpbIncome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // datePickerDate
            // 
            this.datePickerDate.Location = new System.Drawing.Point(12, 25);
            this.datePickerDate.Name = "datePickerDate";
            this.datePickerDate.Size = new System.Drawing.Size(200, 20);
            this.datePickerDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 88);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(12, 48);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(87, 13);
            this.lblTransactionType.TabIndex = 3;
            this.lblTransactionType.Text = "TransactionType";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 127);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Notes";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 16);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(6, 94);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(6, 55);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 8;
            this.lblRate.Text = "Rate";
            // 
            // ddlTransactionType
            // 
            this.ddlTransactionType.FormattingEnabled = true;
            this.ddlTransactionType.Location = new System.Drawing.Point(12, 64);
            this.ddlTransactionType.Name = "ddlTransactionType";
            this.ddlTransactionType.Size = new System.Drawing.Size(219, 21);
            this.ddlTransactionType.TabIndex = 9;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(12, 104);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(219, 20);
            this.tbxDescription.TabIndex = 10;
            // 
            // tbxNotes
            // 
            this.tbxNotes.Location = new System.Drawing.Point(12, 143);
            this.tbxNotes.Multiline = true;
            this.tbxNotes.Name = "tbxNotes";
            this.tbxNotes.Size = new System.Drawing.Size(219, 70);
            this.tbxNotes.TabIndex = 11;
            // 
            // numericExpenseAmount
            // 
            this.numericExpenseAmount.Location = new System.Drawing.Point(6, 32);
            this.numericExpenseAmount.Name = "numericExpenseAmount";
            this.numericExpenseAmount.Size = new System.Drawing.Size(120, 20);
            this.numericExpenseAmount.TabIndex = 12;
            this.numericExpenseAmount.ValueChanged += new System.EventHandler(this.numericExpenseAmount_ValueChanged);
            // 
            // numericExpenseRate
            // 
            this.numericExpenseRate.DecimalPlaces = 2;
            this.numericExpenseRate.Location = new System.Drawing.Point(6, 71);
            this.numericExpenseRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericExpenseRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericExpenseRate.Name = "numericExpenseRate";
            this.numericExpenseRate.Size = new System.Drawing.Size(120, 20);
            this.numericExpenseRate.TabIndex = 13;
            this.numericExpenseRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericExpenseRate.ValueChanged += new System.EventHandler(this.numericExpenseRate_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(129, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(224, 403);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxExpenseValue
            // 
            this.tbxExpenseValue.Enabled = false;
            this.tbxExpenseValue.Location = new System.Drawing.Point(6, 110);
            this.tbxExpenseValue.Name = "tbxExpenseValue";
            this.tbxExpenseValue.Size = new System.Drawing.Size(121, 20);
            this.tbxExpenseValue.TabIndex = 16;
            // 
            // gpbExpense
            // 
            this.gpbExpense.Controls.Add(this.lblAmount);
            this.gpbExpense.Controls.Add(this.tbxExpenseValue);
            this.gpbExpense.Controls.Add(this.lblValue);
            this.gpbExpense.Controls.Add(this.lblRate);
            this.gpbExpense.Controls.Add(this.numericExpenseAmount);
            this.gpbExpense.Controls.Add(this.numericExpenseRate);
            this.gpbExpense.Location = new System.Drawing.Point(12, 219);
            this.gpbExpense.Name = "gpbExpense";
            this.gpbExpense.Size = new System.Drawing.Size(219, 150);
            this.gpbExpense.TabIndex = 17;
            this.gpbExpense.TabStop = false;
            this.gpbExpense.Text = "Expense";
            // 
            // gpbIncome
            // 
            this.gpbIncome.Controls.Add(this.label1);
            this.gpbIncome.Controls.Add(this.tbxIncomeValue);
            this.gpbIncome.Controls.Add(this.label2);
            this.gpbIncome.Controls.Add(this.label3);
            this.gpbIncome.Controls.Add(this.numericIncomeAmount);
            this.gpbIncome.Controls.Add(this.numericIncomeRate);
            this.gpbIncome.Location = new System.Drawing.Point(237, 219);
            this.gpbIncome.Name = "gpbIncome";
            this.gpbIncome.Size = new System.Drawing.Size(219, 150);
            this.gpbIncome.TabIndex = 18;
            this.gpbIncome.TabStop = false;
            this.gpbIncome.Text = "Income";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amount";
            // 
            // tbxIncomeValue
            // 
            this.tbxIncomeValue.Enabled = false;
            this.tbxIncomeValue.Location = new System.Drawing.Point(6, 110);
            this.tbxIncomeValue.Name = "tbxIncomeValue";
            this.tbxIncomeValue.Size = new System.Drawing.Size(121, 20);
            this.tbxIncomeValue.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rate";
            // 
            // numericIncomeAmount
            // 
            this.numericIncomeAmount.Location = new System.Drawing.Point(6, 32);
            this.numericIncomeAmount.Name = "numericIncomeAmount";
            this.numericIncomeAmount.Size = new System.Drawing.Size(120, 20);
            this.numericIncomeAmount.TabIndex = 12;
            this.numericIncomeAmount.ValueChanged += new System.EventHandler(this.numericIncomeAmount_ValueChanged);
            // 
            // numericIncomeRate
            // 
            this.numericIncomeRate.DecimalPlaces = 2;
            this.numericIncomeRate.Location = new System.Drawing.Point(6, 71);
            this.numericIncomeRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericIncomeRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericIncomeRate.Name = "numericIncomeRate";
            this.numericIncomeRate.Size = new System.Drawing.Size(120, 20);
            this.numericIncomeRate.TabIndex = 13;
            this.numericIncomeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericIncomeRate.ValueChanged += new System.EventHandler(this.numericIncomeRate_ValueChanged);
            // 
            // AddTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 450);
            this.Controls.Add(this.gpbIncome);
            this.Controls.Add(this.gpbExpense);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxNotes);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.ddlTransactionType);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.datePickerDate);
            this.Name = "AddTransactionForm";
            this.Text = "Add Transaction";
            this.Load += new System.EventHandler(this.AddTransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseRate)).EndInit();
            this.gpbExpense.ResumeLayout(false);
            this.gpbExpense.PerformLayout();
            this.gpbIncome.ResumeLayout(false);
            this.gpbIncome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePickerDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.ComboBox ddlTransactionType;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.TextBox tbxNotes;
        private System.Windows.Forms.NumericUpDown numericExpenseAmount;
        private System.Windows.Forms.NumericUpDown numericExpenseRate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxExpenseValue;
        private System.Windows.Forms.GroupBox gpbExpense;
        private System.Windows.Forms.GroupBox gpbIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxIncomeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericIncomeAmount;
        private System.Windows.Forms.NumericUpDown numericIncomeRate;
    }
}