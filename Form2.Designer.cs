namespace 日曆
{
    partial class Form2
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
            addAccountButton = new Button();
            balanceQueryButton = new Button();
            label1 = new Label();
            accountsDataGridView = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            accountNameTextBox = new TextBox();
            initialBalanceTextBox = new TextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            savebutton = new Button();
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // addAccountButton
            // 
            addAccountButton.Location = new Point(466, 216);
            addAccountButton.Margin = new Padding(2);
            addAccountButton.Name = "addAccountButton";
            addAccountButton.Size = new Size(92, 27);
            addAccountButton.TabIndex = 0;
            addAccountButton.Text = "添加項目";
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += addAccountButton_Click;
            // 
            // balanceQueryButton
            // 
            balanceQueryButton.Location = new Point(27, 305);
            balanceQueryButton.Margin = new Padding(2);
            balanceQueryButton.Name = "balanceQueryButton";
            balanceQueryButton.Size = new Size(92, 27);
            balanceQueryButton.TabIndex = 2;
            balanceQueryButton.Text = "查詢餘額";
            balanceQueryButton.UseVisualStyleBackColor = true;
            balanceQueryButton.Click += balanceQueryButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(361, 86);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 19);
            label1.TabIndex = 3;
            label1.Text = "日常開銷名稱：";
            // 
            // accountsDataGridView
            // 
            accountsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsDataGridView.Columns.AddRange(new DataGridViewColumn[] { NameColumn, Amount });
            accountsDataGridView.Location = new Point(27, 20);
            accountsDataGridView.Margin = new Padding(2);
            accountsDataGridView.Name = "accountsDataGridView";
            accountsDataGridView.RowHeadersWidth = 62;
            accountsDataGridView.RowTemplate.Height = 32;
            accountsDataGridView.Size = new Size(313, 261);
            accountsDataGridView.TabIndex = 4;
            // 
            // NameColumn
            // 
            NameColumn.HeaderText = "開銷名稱";
            NameColumn.MinimumWidth = 8;
            NameColumn.Name = "NameColumn";
            NameColumn.Width = 150;
            // 
            // Amount
            // 
            Amount.HeaderText = "金額";
            Amount.MinimumWidth = 8;
            Amount.Name = "Amount";
            Amount.Width = 150;
            // 
            // accountNameTextBox
            // 
            accountNameTextBox.Location = new Point(506, 83);
            accountNameTextBox.Margin = new Padding(2);
            accountNameTextBox.Name = "accountNameTextBox";
            accountNameTextBox.Size = new Size(123, 27);
            accountNameTextBox.TabIndex = 5;
            // 
            // initialBalanceTextBox
            // 
            initialBalanceTextBox.Location = new Point(506, 140);
            initialBalanceTextBox.Margin = new Padding(2);
            initialBalanceTextBox.Name = "initialBalanceTextBox";
            initialBalanceTextBox.Size = new Size(123, 27);
            initialBalanceTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(394, 142);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 10;
            label3.Text = "初始餘額:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(383, 30);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(246, 27);
            dateTimePicker1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(137, 304);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 28);
            button1.TabIndex = 12;
            button1.Text = "總和";
            button1.UseVisualStyleBackColor = true;
            button1.Click += calculateButton_Click;
            // 
            // savebutton
            // 
            savebutton.Location = new Point(248, 304);
            savebutton.Margin = new Padding(2);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(92, 27);
            savebutton.TabIndex = 13;
            savebutton.Text = "儲存";
            savebutton.UseVisualStyleBackColor = true;
            savebutton.Click += savebutton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 356);
            Controls.Add(savebutton);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(initialBalanceTextBox);
            Controls.Add(accountNameTextBox);
            Controls.Add(accountsDataGridView);
            Controls.Add(label1);
            Controls.Add(balanceQueryButton);
            Controls.Add(addAccountButton);
            Margin = new Padding(2);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addAccountButton;
        private Button balanceQueryButton;
        private Label label1;
        private DataGridView accountsDataGridView;
        private TextBox accountNameTextBox;
        private TextBox initialBalanceTextBox;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn Amount;
        private Button savebutton;
    }
}