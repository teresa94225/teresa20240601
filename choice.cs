using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    public partial class choice : Form
    {
        private DateTime selectedDate;
        public choice(Form1 mainForm, DateTime diaryDate)
        {
            InitializeComponent();
            selectedDate = diaryDate;
        }

        private void accountingbutton_Click(object sender, EventArgs e)
        {
            //Form2 accountingForm = new Form2(selectedDate);
            //accountingForm.Show();
            if (DairyManager.accountingExists(selectedDate))
            {
                Form2 accounting = new Form2(selectedDate);
                accounting.Owner = this;
                // 如果存在日记文件，则打开现有日记窗口
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

            // 检查是否有日记文件
            if (DairyManager.DiaryExists(selectedDate))
            {
                diarycs diarycs = new diarycs(selectedDate);
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
            diarycs diaryForm = new diarycs(selectedDate);
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


    }
}
