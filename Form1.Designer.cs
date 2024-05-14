namespace 日曆
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            monthCalendar1 = new MonthCalendar();
            accountingbutton = new Button();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(228, 78);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateSelected;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // accountingbutton
            // 
            accountingbutton.Location = new Point(613, 46);
            accountingbutton.Name = "accountingbutton";
            accountingbutton.Size = new Size(94, 29);
            accountingbutton.TabIndex = 1;
            accountingbutton.Text = "記帳";
            accountingbutton.UseVisualStyleBackColor = true;
            accountingbutton.Click += accountingbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(accountingbutton);
            Controls.Add(monthCalendar1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private Button accountingbutton;
    }
}