using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace 日曆
{
    public partial class diarycs : Form
    {
        private DateTime selectedDate;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        public diarycs(DateTime diaryDate)
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
            this.Controls.Add(pictureBox4);
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
                //UpdatePictureBoxVisibility();
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
                //UpdatePictureBoxVisibility();
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
                //UpdatePictureBoxVisibility();
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
                //UpdatePictureBoxVisibility();
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
                //UpdatePictureBoxVisibility();
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
                //UpdatePictureBoxVisibility();
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
                SelectedColor = selectedColor,
                PhotoFileNames = new List<string>()
            };

            for (int i = 0; i < totalphoto; i++)
            {
                string photoFileName = $"{entry.Date.ToString("yyyy-MM-dd")}_photo{(i + 1)}.jpg";
                string photoFilePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), photoFileName);

                if (File.Exists(photoFilePath))
                {
                    // 如果照片文件已存在，先刪除再保存
                    File.Delete(photoFilePath);
                    
                }

                try
                {
                    pictureBoxes[i].Image.Save(photoFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    entry.PhotoFileNames.Add(photoFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存照片失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            DairyManager.SaveToFile(entry, selectedDate);
            MessageBox.Show("日记保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenDiaryForm(DateTime selectedDate)
        {
            // 清空现有数据
            moodcomboBox.SelectedItem = null;
            weathercomboBox.SelectedItem = null;
            context.Text = string.Empty;
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
                pictureBox.Hide();
            }
            BackColor = SystemColors.Control; // 重置背景色

            // 显示添加照片按钮
            addbutton.Show();

            // 生成文件名（可以使用日期作为文件名）
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    // 读取 JSON 文件内容
                    string json = File.ReadAllText(filePath);

                    // 将 JSON 反序列化为 DiaryEntry 对象
                    DiaryEntry diaryEntry = JsonConvert.DeserializeObject<DiaryEntry>(json);

                    dateTimePicker1.Value = diaryEntry.Date;
                    moodcomboBox.SelectedItem = diaryEntry.Mood;
                    weathercomboBox.SelectedItem = diaryEntry.Weather;
                    context.Text = diaryEntry.Context;
                    BackColor = diaryEntry.SelectedColor;

                    for (int i = 0; i < diaryEntry.PhotoFileNames.Count && i < pictureBoxes.Count; i++)
                    {
                        string photoFileName = diaryEntry.PhotoFileNames[i];
                        string photoFilePath = Path.Combine(DairyManager.DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), photoFileName);
                        if (File.Exists(photoFilePath))
                        {
                            Image image = Image.FromFile(photoFilePath);
                            pictureBoxes[i].Show(); // 显示对应的 PictureBox
                            pictureBoxes[i].Image = image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开 JSON 文件时出错: {ex.Message}");
            }
        }

        public Color selectedColor;

        private void colorbutton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                this.BackColor = Color.White;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.White, selectedColor, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedDate != dateTimePicker1.Value)
            {
                selectedDate = dateTimePicker1.Value;
                if (DairyManager.DiaryExists(selectedDate))
                {
                    selectedDate = dateTimePicker1.Value;
                    OpenDiaryForm(selectedDate);
                }
                else
                {
                    this.Close();
                    choice choice = new choice(selectedDate);
                    choice.OpenNewDiaryForm(selectedDate);
                }
            }
        }
    }
}
