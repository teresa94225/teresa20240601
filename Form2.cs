using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            dateTimePicker1.Value = selectedDate; // 设置日期选择器的值为选择的日期
            OpenaccountingForm(_selectedDate); // 加载现有的记账数据
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
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            List<accountingentery> accountingEntries = new List<accountingentery>();

            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    accountingentery entry = new accountingentery
                    {
                        Date = dateTimePicker1.Value,
                        ExpenseName = row.Cells["NameColumn"].Value.ToString(),
                        Amount = Convert.ToDecimal(row.Cells["Amount"].Value)
                    };
                    accountingEntries.Add(entry);
                }
            }

            DairyManager.accoutingSaveToFile(accountingEntries, _selectedDate);
            MessageBox.Show("記賬保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenaccountingForm(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DairyManager.accountingFolder, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    List<accountingentery> entries = JsonConvert.DeserializeObject<List<accountingentery>>(json);

                    // 清空现有数据
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();

                    foreach (var entry in entries)
                    {
                        accountsDataGridView.Rows.Add(entry.ExpenseName, entry.Amount);
                    }

                    expenses = entries.Select(entry => new Expense(entry.ExpenseName, entry.Amount, entry.Date)).ToList();
                }
                else
                {
                    // 如果文件不存在，清空现有数据
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开 JSON 文件时出错: {ex.Message}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _selectedDate = dateTimePicker1.Value;
            OpenaccountingForm(_selectedDate);
        }

        private void deletebutton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in accountsDataGridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    accountsDataGridView.Rows.Remove(row);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            accountNameTextBox.Text = string.Empty;
            initialBalanceTextBox.Text = string.Empty;
        }
    }
}
