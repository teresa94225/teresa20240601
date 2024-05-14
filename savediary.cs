using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    internal class savediary
    {
        // 讀取日記的方法
        public static DiaryEntry LoadDiary(string fileName)
        {
            // 检查日记文件是否存在
            if (File.Exists(fileName))
            {
                // 读取日记文件内容
                string json = File.ReadAllText(fileName);

                // 将JSON反序列化为DiaryEntry对象
                return JsonConvert.DeserializeObject<DiaryEntry>(json);
            }
            else
            {
                // 如果日记文件不存在，则返回空
                return null;
            }
        }
    }
}
