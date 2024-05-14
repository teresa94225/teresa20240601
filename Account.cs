namespace 日曆
{
    internal class Expense
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
