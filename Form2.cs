using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace 日曆
{
    public partial class Form2 : Form
    {
        private DateTime _selectedDate;
        private List<Expense> expenses = new List<Expense>();
        public Form2(DateTime selectedDate)
        {
            InitializeComponent();
            _selectedDate = selectedDate;
            dateTimePicker1.Value = selectedDate; // 設置日期選擇器的值為選擇的日期
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            string expenseName = accountNameTextBox.Text;
            decimal amount;
            bool isAmountValid = decimal.TryParse(initialBalanceTextBox.Text, out amount);

            if (isAmountValid)
            {
                Expense newExpense = new Expense(expenseName, amount, _selectedDate);
                expenses.Add(newExpense);
                UpdateDataGridView();
                accountNameTextBox.Text = string.Empty;
                initialBalanceTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("請輸入有效的金額。");
            }
        }


        private void balanceQueryButton_Click(object sender, EventArgs e)
        {
            decimal dailyTotal = expenses
                .Where(expense => expense.Date.Date == _selectedDate.Date)
                .Sum(expense => expense.Amount);

            MessageBox.Show($"當日總開銷: {dailyTotal:C}");
        }

        private void UpdateDataGridView()
        {
            accountsDataGridView.Rows.Clear();
            foreach (var expense in expenses)
            {
                accountsDataGridView.Rows.Add(expense.Name, expense.Amount);
            }
        }



        private void calculateButton_Click(object sender, EventArgs e)
        {
            double total = 0.0;
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                if (!row.IsNewRow && row.Cells["Amount"].Value != null && double.TryParse(row.Cells["Amount"].Value.ToString(), out double amount))
                {
                    total += amount;
                }
            }
            MessageBox.Show("總和：" + total.ToString("C"), "總和", MessageBoxButtons.OK, MessageBoxIcon.Information);
            double totalAmount = 0.0;
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                if (!row.IsNewRow && row.Cells["Amount"].Value != null)
                {
                    if (double.TryParse(row.Cells["Amount"].Value.ToString(), out double amount))
                    {
                        // 將成功轉換的值添加到總和
                        totalAmount += amount;
                    }
                    else
                    {
                        // 轉換失敗，您可以在這裡處理錯誤情況
                        MessageBox.Show($"無法將 '{row.Cells["Amount"].Value}' 解析為有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            List<accountingentery> accountingEntries = new List<accountingentery>();

            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                if (!row.IsNewRow) // 確保不包含新的空白行
                {
                    accountingentery entry = new accountingentery
                    {
                        Date = dateTimePicker1.Value,
                        ExpenseName = row.Cells["NameColumn"].Value.ToString(), // 假設名稱欄位的名稱是 "ColumnName"
                        Amount = Convert.ToDecimal(row.Cells["Amount"].Value) // 假設金額欄位的名稱是 "ColumnAmount"
                    };
                    accountingEntries.Add(entry);
                }
            }
            // 调用 DairyManager 中的 SaveDiary 方法保存日记
            DairyManager.accoutingSaveToFile(accountingEntries, _selectedDate);
            // 提示用户保存成功或其他操作
            MessageBox.Show("日记保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void OpenaccountingForm(DateTime _selectedDate)
        {
            // 生成文件名（可以使用日期作为文件名）
            string fileName = _selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 创建文件路径
            string filePath = Path.Combine(DairyManager.accountingFolder, fileName); // DiariesFolder 包含了 diaries 文件夹

            try
            {
                // 读取 JSON 文件内容
                string json = File.ReadAllText(filePath);

                // 将 JSON 反序列化为 accountingentery 对象的列表
                List<accountingentery> entries = JsonConvert.DeserializeObject<List<accountingentery>>(json);

                // 将反序列化的条目加载到 DataGridView 中
                foreach (var entry in entries)
                {
                    accountsDataGridView.Rows.Add(entry.ExpenseName, entry.Amount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开 JSON 文件时出错: {ex.Message}");
            }
        }

        
    }
}