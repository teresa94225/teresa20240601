using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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
            dateTimePicker1.Value = _selectedDate; // 設置日期選擇器的值為選擇的日期
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

    }
}