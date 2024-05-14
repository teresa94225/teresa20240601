using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日曆
{
    internal class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Mood { get; set; }
        public string Weather { get; set; }
        public string Context { get; set; }
        public List<string> PhotoFileNames { get; set; }

        public override string ToString()
        {
            
            return $"日期: {Date}, 心情: {Mood}, 天氣: {Weather}, 內容: {Context}"; ;
            
        }

    }
}
