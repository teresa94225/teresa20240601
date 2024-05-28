using System;

namespace 日曆
{
    internal class accountingentery
    {
        public DateTime Date { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"日期: {Date}, 項目: {ExpenseName}, 價錢: {Amount:C}";
        }
    }

}
