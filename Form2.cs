using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            InitializeChart();
            UpdateChart();
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
                UpdateDataGridView();
                UpdateChart();
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
            MessageBox.Show("記帳儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    UpdateChart();
                }
                else
                {
                    // 如果文件不存在，清空现有数据
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                    UpdateChart();
                }
            }
            catch (Exception ex)
            {

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
                    var expenseName = row.Cells["NameColumn"].Value.ToString();

                    // 从 DataGridView 中移除选定的行
                    accountsDataGridView.Rows.Remove(row);

                    // 从 expenses 列表中移除相应的数据
                    var expenseToRemove = expenses.FirstOrDefault(expense => expense.Name == expenseName);
                    if (expenseToRemove != null)
                    {
                        expenses.Remove(expenseToRemove);
                    }

                    // 从圆饼图中移除相应的数据
                    RemoveFromChart(expenseName);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

            accountsDataGridView.Rows.Clear(); // 清除 DataGridView 內容
            expenses.Clear(); // 清空 expenses 列表
            InitializeChart(); // 更新圖表
        }
        private void InitializeChart()
        {
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Expenses");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
        }

        private void UpdateChart()
        {
            chart1.Series["Expenses"].Points.Clear();
            var expenseGroups = expenses.GroupBy(e => e.Name).Select(g => new
            {
                Name = g.Key,
                Total = g.Sum(e => e.Amount)
            });

            foreach (var group in expenseGroups)
            {
                chart1.Series["Expenses"].Points.AddXY(group.Name, group.Total);
            }
        }

        private void RemoveFromChart(string itemName)
        {
            // 查找并移除指定项目的点
            var pointToRemove = chart1.Series["Expenses"].Points.FirstOrDefault(point => point.AxisLabel == itemName);
            if (pointToRemove != null)
            {
                chart1.Series["Expenses"].Points.Remove(pointToRemove);
            }
        }
        public class Expense
        {
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }

            public Expense(string name, decimal amount, DateTime date)
            {
                Name = name;
                Amount = amount;
                Date = date;
            }
        }


    }
}
