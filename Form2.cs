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
            // 初始化表單元件
            InitializeComponent();
            // 將選擇的日期賦值給私有變數 _selectedDate
            _selectedDate = selectedDate;
            // 設置日期選擇器 (dateTimePicker1) 的值為選擇的日期
            dateTimePicker1.Value = selectedDate; 
            // 打開並加載指定日期的記帳表單
            OpenaccountingForm(_selectedDate);
            // 初始化圓餅圖 (chart1)
            InitializeChart();
            // 更新圓餅圖顯示的資料
            UpdateChart();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            // 從介面中獲取帳戶名稱和初始金額
            string expenseName = accountNameTextBox.Text;
            decimal amount;
            bool isAmountValid = decimal.TryParse(initialBalanceTextBox.Text, out amount);
            // 檢查初始金額是否有效
            if (isAmountValid)
            {
                // 如果初始金額有效，則創建一個新的 Expense 對象
                Expense newExpense = new Expense(expenseName, amount, _selectedDate);
                // 將新的 Expense 對象添加到 expenses 列表中
                expenses.Add(newExpense);
                // 更新 DataGridView 控制項顯示的資料
                UpdateDataGridView();
                // 清空帳戶名稱和初始金額文本框
                accountNameTextBox.Text = string.Empty;
                initialBalanceTextBox.Text = string.Empty;
                // 更新 DataGridView 控制項和圖表顯示的資料
                UpdateDataGridView();
                UpdateChart();
            }
            else
            {
                // 如果初始金額無效，則顯示錯誤訊息
                MessageBox.Show("請輸入有效的金額。");
            }

        }

        private void UpdateDataGridView()
        {
            // 清空 DataGridView 中現有的行
            accountsDataGridView.Rows.Clear();
            // 遍歷 expenses 列表中的每個支出項目，並將其添加到 DataGridView 中
            foreach (var expense in expenses)
            {
                accountsDataGridView.Rows.Add(expense.Name, expense.Amount);
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 初始化總和變量
            double total = 0.0;
            // 遍歷 DataGridView 的每一行
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                // 檢查當前行是否不是新行且金額欄位不為空
                // 嘗試將金額欄位的值解析為 double
                if (!row.IsNewRow && row.Cells["Amount"].Value != null && double.TryParse(row.Cells["Amount"].Value.ToString(), out double amount))
                {
                    // 如果解析成功，將金額加到總和中
                    total += amount;//
                }
            }
            MessageBox.Show("總和：" + total.ToString("C"), "總和", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void savebutton_Click(object sender, EventArgs e)//參考ChatGPT
        {
            // 創建一個新的 List<accountingentery> 來存儲會計項目
            List<accountingentery> accountingEntries = new List<accountingentery>();
            // 遍歷 DataGridView 的每一行
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                // 排除新行
                if (!row.IsNewRow)
                {
                    // 創建一個新的 accountingentery 對象，將該行的數據添加到對象中
                    accountingentery entry = new accountingentery
                    {
                        Date = dateTimePicker1.Value,// 設置日期為 dateTimePicker1 的值
                        ExpenseName = row.Cells["NameColumn"].Value.ToString(),// 獲取名為 "NameColumn" 的列的值作為 ExpenseName
                        Amount = Convert.ToDecimal(row.Cells["Amount"].Value)// 將 "Amount" 列的值轉換為 decimal 並設置為 Amount
                    };
                    // 將創建的 accountingentery 對象添加到 List 中
                    accountingEntries.Add(entry);

                }
            }
            // 將會計項目保存到文件中
            DairyManager.accoutingSaveToFile(accountingEntries, _selectedDate);
            // 顯示保存成功的訊息框
            MessageBox.Show("記帳儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenaccountingForm(DateTime selectedDate)
        {
            // 構建文件路徑
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DairyManager.accountingFolder, fileName);

            try
            {
                // 檢查文件是否存在
                if (File.Exists(filePath))
                {
                    // 如果文件存在，讀取文件內容
                    string json = File.ReadAllText(filePath);
                    // 將 JSON 字符串轉換為 List<accountingentery> 對象
                    List<accountingentery> entries = JsonConvert.DeserializeObject<List<accountingentery>>(json);

                    // 清空現有資料
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                    // 將文件中的會計項目添加到 DataGridView 中
                    foreach (var entry in entries)
                    {
                        accountsDataGridView.Rows.Add(entry.ExpenseName, entry.Amount);
                    }
                    // 將文件中的會計項目轉換為 Expense 對象並添加到 expenses 列表中
                    expenses = entries.Select(entry => new Expense(entry.ExpenseName, entry.Amount, entry.Date)).ToList();
                    // 更新圖表
                    UpdateChart();
                }
                else
                {
                    // 如果文件不存在，清空現有資料並更新圖表
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                    UpdateChart();
                }
            }
            catch (Exception ex)
            {
                // 捕獲任何異常，如果有異常發生，可以在這裡進行處理
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // 更新 _selectedDate 變數為 DateTimePicker 控制項的值
            _selectedDate = dateTimePicker1.Value;
            // 調用 OpenaccountingForm 方法，打開選定日期的記帳表單
            OpenaccountingForm(_selectedDate);
        }

        private void deletebutton1_Click(object sender, EventArgs e)
        {
            // 遍歷所選行
            foreach (DataGridViewRow row in accountsDataGridView.SelectedRows)
            {
                // 檢查所選行是否不是新行
                if (!row.IsNewRow)
                {
                    // 獲取支出名稱
                    var expenseName = row.Cells["NameColumn"].Value.ToString();

                    // 從 DataGridView 中移除選定的行
                    accountsDataGridView.Rows.Remove(row);

                    // 從 expenses 列表中移除相應的資料
                    var expenseToRemove = expenses.FirstOrDefault(expense => expense.Name == expenseName);
                    if (expenseToRemove != null)
                    {
                        expenses.Remove(expenseToRemove);
                    }

                    // 從圓餅圖中移除相應的資料
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
            // 清空圓餅圖中現有的系列
            chart1.Series.Clear();
            // 添加一個名為 "Expenses" 的新系列
            Series series = chart1.Series.Add("Expenses");
            // 設置系列的圖表類型為圓餅圖
            series.ChartType = SeriesChartType.Pie;
            // 將數值顯示為標籤
            series.IsValueShownAsLabel = true;
        }

        private void UpdateChart()
        {
            // 清空圓餅圖中現有的資料點
            chart1.Series["Expenses"].Points.Clear();
            // 使用 LINQ 查詢計算每個支出名稱對應的總金額
            var expenseGroups = expenses.GroupBy(e => e.Name).Select(g => new
            {
                Name = g.Key,
                Total = g.Sum(e => e.Amount)
            });
            // 將計算的資料添加到圓餅圖中
            foreach (var group in expenseGroups)
            {
                chart1.Series["Expenses"].Points.AddXY(group.Name, group.Total);
            }
        }

        private void RemoveFromChart(string itemName)
        {
            // 查找並移除指定項目名稱對應的資料點
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
