using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日曆
{
    internal class getset
    {
        public string title { get; set; }
        public string Memo { get; set; }
        public DateTime Date { get; set; } // 添加日期属性
        public override string ToString()
        {

            return $"標題: {title}，說明: {Memo}"; ;
        }
    }
}
