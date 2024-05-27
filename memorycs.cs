using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    public partial class memorycs : Form
    {
        public memorycs()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InitializeDiariesFolder();
            getset entry = new getset
            {
                title = this.title.Text,
                Memo = Memo.Text
            };

            // 创建存储文件夹的路径
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夹不存在，则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 创建文件路径
            string filePath = Path.Combine(folderPath, this.title.Text + ".json");

            // 创建 JSON 格式的字符串
            string json = JsonConvert.SerializeObject(entry);

            // 写入文件
            File.WriteAllText(filePath, json);

            // 提示用户保存成功
            MessageBox.Show("Saved successfully.");

            memoListBox.Items.Add(this.title.Text);

            this.title.Text = "";
            Memo.Text = "";
        }

        public const string memoryfolder = "memory";
        private static void InitializeDiariesFolder()
        {

            if (!Directory.Exists(memoryfolder))
            {
                Directory.CreateDirectory(memoryfolder);
            }
        }



        private void MemoListBox_Click(object sender, EventArgs e)
        {
            if (memoListBox.SelectedItem != null)
            {
                string selectedTitle = memoListBox.SelectedItem.ToString();
                string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");
                string filePath = Path.Combine(folderPath, selectedTitle + ".json");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    getset entry = JsonConvert.DeserializeObject<getset>(json);

                    // 在此处使用 entry 对象，例如显示到 UI 中
                    this.title.Text = entry.title;
                    Memo.Text = entry.Memo;
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.title.Text = "";
            Memo.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 创建存储文件夹的路径
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夹存在，则加载其中的文件
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.json");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    memoListBox.Items.Add(fileName);
                }
            }
        }
    }
}
