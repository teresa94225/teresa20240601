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

        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 获取所选日期
            DateTime selectedDate = monthCalendar1.SelectionStart;



            // 检查是否有日记文件
            if (DairyManager.DiaryExists(selectedDate))
            {
                diarycs diarycs = new diarycs(this, selectedDate);
                diarycs.Owner = this;
                // 如果存在日记文件，则打开现有日记窗口
                diarycs.OpenDiaryForm(selectedDate);
                diarycs.ShowDialog();
            }
            else
            {
                // 如果不存在日记文件，则打开新的日记窗口
                OpenNewDiaryForm(selectedDate);
            }
        }

        private void OpenNewDiaryForm(DateTime selectedDate)
        {
            diarycs diaryForm = new diarycs(this, selectedDate);
            diaryForm.Owner = this;
            // 設置 diaryForm 的 dateTimePicker1 控件的值為所選日期
            diaryForm.SetDateTimePickerValue(selectedDate);
            diaryForm.ShowDialog();
        }


        // 假設 DiaryManager 是用於管理日記內容的類別
        public static class DiaryManager
        {
            private static Dictionary<DateTime, string> diaryEntries = new Dictionary<DateTime, string>();

            public static string DiariesFolder { get; internal set; }

            // 假設 GetDiaryContent 方法用於根據日期獲取日記內容
            public static string GetDiaryContent(DateTime date)
            {
                // 在這裡實現根據日期獲取日記內容的邏輯
                // 假設 diaryEntries 是一個字典，保存了日期與日記內容的對應關係
                if (diaryEntries.ContainsKey(date))
                {
                    return diaryEntries[date];
                }
                else
                {
                    return null;
                }
            }
            // 假設 AddDiaryEntry 方法用於添加新的日記內容
            public static void AddDiaryEntry(DateTime date, string content)
            {
                // 在這裡實現添加日記內容的邏輯
                // 假設 diaryEntries 是一個字典，保存了日期與日記內容的對應關係
                diaryEntries[date] = content;
            }
        }

        private void accountingbutton_Click(object sender, EventArgs e)
        {
            Form2 accountingForm = new Form2(DateTime.Now);
            accountingForm.Show();

        }
    }
}