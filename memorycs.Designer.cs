namespace 日曆
{
    partial class memorycs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            memoListBox = new ListBox();
            title = new TextBox();
            label1 = new Label();
            Memo = new TextBox();
            btnSave = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // memoListBox
            // 
            memoListBox.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            memoListBox.FormattingEnabled = true;
            memoListBox.ItemHeight = 35;
            memoListBox.Location = new Point(36, 77);
            memoListBox.Margin = new Padding(4, 5, 4, 5);
            memoListBox.Name = "memoListBox";
            memoListBox.Size = new Size(388, 459);
            memoListBox.TabIndex = 1;
            memoListBox.Click += MemoListBox_Click;
            this.Load += Form1_Load;
            // 
            // title
            // 
            title.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            title.Location = new Point(609, 38);
            title.Name = "title";
            title.Size = new Size(377, 37);
            title.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(504, 39);
            label1.Name = "label1";
            label1.Size = new Size(99, 36);
            label1.TabIndex = 4;
            label1.Text = "標題：";
            // 
            // Memo
            // 
            Memo.Font = new Font("Microsoft JhengHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Memo.Location = new Point(504, 99);
            Memo.Margin = new Padding(4);
            Memo.Multiline = true;
            Memo.Name = "Memo";
            Memo.Size = new Size(494, 432);
            Memo.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(685, 542);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(36, 15);
            button1.Name = "button1";
            button1.Size = new Size(52, 46);
            button1.TabIndex = 7;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 613);
            Controls.Add(button1);
            Controls.Add(btnSave);
            Controls.Add(Memo);
            Controls.Add(label1);
            Controls.Add(title);
            Controls.Add(memoListBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "備忘錄";
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox memoListBox;
        private TextBox title;
        private Label label1;
        private TextBox Memo;
        private Button btnSave;
        private Button button1;
    }
}