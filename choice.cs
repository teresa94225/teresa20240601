using System;
using System.Windows.Forms;

namespace 日曆
{
    public partial class choice : Form
    {
        private DateTime selectedDate;

        public choice( DateTime diaryDate)
        {
            InitializeComponent();
            selectedDate = diaryDate;

        }

        private void accountingbutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.AccountingExists(selectedDate))
            {
                Form2 accounting = new Form2(selectedDate);
                accounting.Owner = this;
                accounting.OpenaccountingForm(selectedDate);
                accounting.ShowDialog();
            }
            else
            {
                Form2 accountingForm = new Form2(selectedDate);
                accountingForm.Show();
            }
        }

        private void diarybutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.DiaryExists(selectedDate))
            {
                diarycs diarycs = new diarycs(selectedDate);
                diarycs.Owner = this;
                diarycs.OpenDiaryForm(selectedDate);
                diarycs.ShowDialog();
            }
            else
            {
                OpenNewDiaryForm(selectedDate);
            }
        }

        public void OpenNewDiaryForm(DateTime selectedDate)
        {
            diarycs diaryForm = new diarycs(selectedDate);
            diaryForm.Owner = this;
            diaryForm.SetDateTimePickerValue(selectedDate);
            diaryForm.ShowDialog();
        }

        public static class DiaryManager
        {
            private static Dictionary<DateTime, string> diaryEntries = new Dictionary<DateTime, string>();

            public static string DiariesFolder { get; internal set; }

            public static string GetDiaryContent(DateTime date)
            {
                if (diaryEntries.ContainsKey(date))
                {
                    return diaryEntries[date];
                }
                else
                {
                    return null;
                }
            }

            public static void AddDiaryEntry(DateTime date, string content)
            {
                diaryEntries[date] = content;
            }
        }
    }
}
