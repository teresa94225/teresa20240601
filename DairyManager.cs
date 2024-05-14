using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace 日曆
{
    internal class DairyManager
    {
        public const string DiariesFolder = "diaries";
        
        public static bool DiaryExists(DateTime selectedDate)
        {
            // 生成文件名，格式为yyyyMMdd.json
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 组合文件路径
            string filePath = Path.Combine(DiariesFolder, fileName);

            // 检查文件是否存在
            return File.Exists(filePath);
        }
        public static void SaveToFile(DiaryEntry entry,DateTime selectedDate)
        {
            // 确保 "diaries" 文件夹存在
            InitializeDiariesFolder();

            

            // 将日记条目转换为 JSON 字符串
            string jsonString = JsonConvert.SerializeObject(entry);

            // 生成文件名（可以使用日期作为文件名）
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 创建文件路径
            string filePath = Path.Combine(DiariesFolder, fileName);

            // 将 JSON 字符串写入文件
            File.WriteAllText(filePath, jsonString);
        }

        

        private static void InitializeDiariesFolder()
        {
            // 检查 "diaries" 文件夹是否存在，如果不存在则创建它
            if (!Directory.Exists(DiariesFolder))
            {
                Directory.CreateDirectory(DiariesFolder);
            }
            string photosFolderPath = Path.Combine(DiariesFolder, "photos");
            if (!Directory.Exists(photosFolderPath))
            {
                Directory.CreateDirectory(photosFolderPath);
            }
        }
    }
}
