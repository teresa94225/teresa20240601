using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace 日曆
{
    internal class DairyManager
    {
        public const string DiariesFolder = "diaries";
        public const string accountingFolder = "accounting";

        static DairyManager()
        {
            InitializeFolder(DiariesFolder);
            InitializeFolder(accountingFolder);
        }

        public static bool DiaryExists(DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate);
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);
            return File.Exists(filePath);
        }

        public static bool AccountingExists(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(accountingFolder, fileName);
            return File.Exists(filePath);
        }

        public static void SaveToFile(DiaryEntry entry, DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate);
            string jsonString = JsonConvert.SerializeObject(entry);
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);
            File.WriteAllText(filePath, jsonString);
        }

        public static void accoutingSaveToFile(List<accountingentery> entries, DateTime selectedDate)
        {
            InitializeFolder(accountingFolder);
            string jsonString = JsonConvert.SerializeObject(entries, Formatting.Indented);
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(accountingFolder, fileName);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<accountingentery> LoadFromFile(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(accountingFolder, fileName);
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<accountingentery>>(json);
            }
            return new List<accountingentery>();
        }

        private static void InitializeDiariesFolder(DateTime selectedDate)
        {
            string folderPath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private static void InitializeFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
