using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 日曆
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            monthCalendar1.DateSelected += monthCalendar1_DateChanged;
        }
        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start != e.End)
            {
                DateTime selectedDate = monthCalendar1.SelectionStart;
                choice choiceForm = new choice(selectedDate);
                choiceForm.ShowDialog();
            }
        }

        private void memory_Click(object sender, EventArgs e)
        {
            memorycs memoryForm = new memorycs();
            memoryForm.Show();
        }
    }
}