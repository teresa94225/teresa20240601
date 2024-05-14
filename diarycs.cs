using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Drawing.Drawing2D;
using System.Text;
using System.Globalization;
using static 日曆.Form1;
using System.Text.Json;
using Newtonsoft.Json;

namespace 日曆
{
    public partial class diarycs : Form
    {
        private DateTime selectedDate;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        
        public diarycs(Form1 mainForm, DateTime diaryDate)
        {

            InitializeComponent();
            selectedDate = diaryDate;
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            this.Controls.Add(pictureBox2);
            pictureBox2.Hide();
            button2.Hide();
            this.Controls.Add(pictureBox3);
            pictureBox3.Hide();
            button3.Hide();
            this.Controls.Add(pictureBox3);
            pictureBox4.Hide();
            button4.Hide();
            this.Controls.Add(pictureBox5);
            pictureBox5.Hide();
            button5.Hide();
            this.Controls.Add(pictureBox6);
            pictureBox6.Hide();
            button6.Hide();
        }

        private void moodcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox moodComboBox = new ComboBox();
            moodComboBox.Items.AddRange(new string[] { "😊", "😔", "😡", "😄", "😢" });
        }

        private void weathercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox weathercomboBox = new ComboBox();
            weathercomboBox.Items.AddRange(new string[] { "☀️", "☁️", "🌧️", "❄️", "🌈" });
        }

        int totalphoto = 0;
        private void addbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.Multiselect = false; // 僅允許選擇一個文件
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // 獲取所選圖片的路徑
                string selectedImagePath = openFileDialog.FileName;
                PictureBox emptyPictureBox = null;

                // 將所選圖片放入 PictureBox 中，並依次放入 PictureBox1, PictureBox2, PictureBox3, PictureBox4
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                    pictureBox2.Show();
                    button1.Show();
                }
                else if (pictureBox2.Image == null)
                {
                    pictureBox2.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                    pictureBox3.Show();
                    button2.Show();
                }
                else if (pictureBox3.Image == null)
                {
                    pictureBox3.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                    pictureBox4.Show();
                    button3.Show();
                }
                else if (pictureBox4.Image == null)
                {
                    pictureBox4.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                    pictureBox5.Show();
                    button4.Show();

                }
                else if (pictureBox5.Image == null)
                {
                    pictureBox5.Image = Image.FromFile(selectedImagePath);
                    totalphoto++;
                    pictureBox6.Show();
                    button5.Show();

                }
                else if (pictureBox6.Image == null)
                {
                    totalphoto++;
                    pictureBox6.Image = Image.FromFile(selectedImagePath);
                    button6.Show();

                }
                else
                {
                    totalphoto++;
                    emptyPictureBox.Image = Image.FromFile(selectedImagePath);
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox1.Image = null;
                pictureBox1.Image = pictureBox2.Image;
                pictureBox2.Image = pictureBox3.Image;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox2.Image = null;
                pictureBox2.Image = pictureBox3.Image;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox3.Image = null;
                pictureBox3.Image = pictureBox4.Image;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox4.Image = null;
                pictureBox4.Image = pictureBox5.Image;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox5.Image = null;
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要移除照片嗎？", "移除照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                totalphoto--;
                pictureBox6.Image = null;
                if (totalphoto == 5)
                {
                    pictureBox6.Show();
                }
                if (totalphoto == 4)
                {
                    pictureBox5.Show();
                    pictureBox6.Hide();
                    button6.Hide();
                }
                if (totalphoto == 3)
                {
                    pictureBox4.Show();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                }
                if (totalphoto == 2)
                {
                    pictureBox3.Show();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                }
                if (totalphoto == 1)
                {
                    pictureBox2.Show();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                }
                if (totalphoto == 0)
                {
                    pictureBox1.Show();
                    pictureBox2.Hide();
                    pictureBox3.Hide();
                    pictureBox4.Hide();
                    pictureBox5.Hide();
                    pictureBox6.Hide();
                    button6.Hide();
                    button5.Hide();
                    button4.Hide();
                    button3.Hide();
                    button2.Hide();
                }
                
            }
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 設定視窗的背景色為水平漸層
                this.BackColor = Color.White; // 起始顏色，這裡假設是白色
                this.Paint += (s, pe) =>
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.White, colorDialog.Color, LinearGradientMode.Horizontal))
                    {
                        pe.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                };
            }
        }


        public void SetDateTimePickerValue(DateTime date)
        {
            dateTimePicker1.Value = date;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            // 创建日记条目对象
            DiaryEntry entry = new DiaryEntry
            {
                Date = dateTimePicker1.Value,
                Mood = moodcomboBox.SelectedItem?.ToString(),
                Weather = weathercomboBox.SelectedItem?.ToString(),
                Context = context.Text,
                PhotoFileNames = new List<string>()
                // 还需要添加照片路径的逻辑，例如：entry.PhotoPaths = GetPhotoPaths();
            };
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                PictureBox pictureBox = pictureBoxes[i];
                if (pictureBox.Image != null)
                {
                    string photoFileName = $"{entry.Date.ToString("yyyy-MM-dd")}_photo{i + 1}.jpg"; // 图片编号从 1 开始
                    string photoFilePath = Path.Combine(DairyManager.DiariesFolder, "photos", photoFileName);
                    pictureBox.Image.Save(photoFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    entry.PhotoFileNames.Add(photoFileName); // 将照片文件名添加到 PhotoFileNames 列表中
                }
            }
            // 调用 DairyManager 中的 SaveDiary 方法保存日记
            DairyManager.SaveToFile(entry, selectedDate);
            // 提示用户保存成功或其他操作
            MessageBox.Show("日记保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenDiaryForm(DateTime selectedDate)
        {
            
            // 生成文件名（可以使用日期作为文件名）
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";

            // 创建文件路径
            string filePath = Path.Combine(DairyManager.DiariesFolder, fileName); // DiariesFolder 包含了 diaries 文件夹

            try
            {
                // 读取 JSON 文件内容
                string json = File.ReadAllText(filePath);

                // 将 JSON 反序列化为 DiaryEntry 对象
                DiaryEntry diaryEntry = JsonConvert.DeserializeObject<DiaryEntry>(json);
                
                //MessageBox.Show($"日期: {diaryEntry.Date}, 内容: {diaryEntry.Context}, 心情: {diaryEntry.Mood}, 天气: {diaryEntry.Weather}");
                
                dateTimePicker1.Value = diaryEntry.Date;
                moodcomboBox.SelectedItem = diaryEntry.Mood;
                weathercomboBox.SelectedItem = diaryEntry.Weather;
                context.Text = diaryEntry.Context;



                for (int i = 1; i < diaryEntry.PhotoFileNames.Count; i++)
                {
                    string photoFileName = $"{selectedDate.Date.ToString("yyyy-MM-dd")}_photo-{i + 1}.jpg";
                    string photoFilePath = Path.Combine(DairyManager.DiariesFolder, "photos", photoFileName);
                    if (File.Exists(photoFilePath))
                    {
                        Image image = Image.FromFile(photoFilePath);
                        pictureBoxes[i].Show();
                        pictureBoxes[i + 1].Show();
                        pictureBoxes[i].Image = image;
                        Controls[$"button{i + 1}"].Show();
                    }
                    else
                    {
                        pictureBoxes[i].Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开 JSON 文件时出错: {ex.Message}");
            }
        }

       
    }
}

