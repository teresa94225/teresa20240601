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
        public const string accountingFolder = "accounting";
        public static bool DiaryExists(DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate);
            // 生成文件名，格式为yyyyMMdd.json
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 组合文件路径
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);

            // 检查文件是否存在
            return File.Exists(filePath);
        }

        public static bool accountingExists(DateTime selectedDate)
        {
            InitializeaccountingFolder(selectedDate);
            // 生成文件名，格式为yyyyMMdd.json
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 组合文件路径
            string filePath = Path.Combine(accountingFolder, fileName);

            // 检查文件是否存在
            return File.Exists(filePath);
        }


        public static void SaveToFile(DiaryEntry entry,DateTime selectedDate)
        {
            // 确保 "diaries" 文件夹存在
            InitializeDiariesFolder(selectedDate);

            

            // 将日记条目转换为 JSON 字符串
            string jsonString = JsonConvert.SerializeObject(entry);

            // 生成文件名（可以使用日期作为文件名）
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 创建文件路径
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);

            // 将 JSON 字符串写入文件
            File.WriteAllText(filePath, jsonString);
        }

        public static void accoutingSaveToFile(List<accountingentery> entries, DateTime _selectedDate)
        {
            // 确保 "diaries" 文件夹存在
            InitializeaccountingFolder(_selectedDate);



            // 将日记条目转换为 JSON 字符串
            string jsonString = JsonConvert.SerializeObject(entries);

            // 生成文件名（可以使用日期作为文件名）
            string fileName = _selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 创建文件路径
            string filePath = Path.Combine(accountingFolder, fileName);

            // 将 JSON 字符串写入文件
            File.WriteAllText(filePath, jsonString);
        }

        private static void InitializeDiariesFolder(DateTime selectedDate)
        {
            // 構建以 selectedDate 命名的資料夾路徑
            string folderPath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"));

            // 如果資料夾不存在，則創建它
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }
        }

        private static void InitializeaccountingFolder(DateTime selectedDate)
        {
            // 構建以 selectedDate 命名的資料夾路徑
            string folderPath = Path.Combine(accountingFolder);

            // 如果資料夾不存在，則創建它
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }
        }
    }
}
