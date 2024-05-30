using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 日曆
{
    public partial class Form1 : Form
    {
        private string fullText = "哈囉你好,歡迎來到我們的應用程式 !!!";
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            monthCalendar1.DateSelected += monthCalendar1_DateChanged;

        }
        private void InitializeCustomComponents()
        {
            // 初始化 Timer
            timer2.Interval = 100; // 設置定時器間隔，單位是毫秒
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // 檢查是否還有未顯示的字符
            if (currentIndex < fullText.Length)
            {
                label2.Text += fullText[currentIndex];
                currentIndex++;
            }
            else
            {
                timer2.Stop(); // 如果所有字符都已顯示，停止定時器
            }
        }


        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start != e.End)
            {
                DateTime selectedDate = monthCalendar1.SelectionStart;
                choice choiceForm = new choice(selectedDate);
                choiceForm.ShowDialog();
            }
        }

        private void memory_Click(object sender, EventArgs e)
        {
            memorycs memoryForm = new memorycs();
            memoryForm.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 設定背景顏色為 #003D79
            this.BackColor = ColorTranslator.FromHtml("#003D79");

            Random rand = new Random();
            int numMeteors = 30; // 設定流星數量

            for (int i = 0; i < numMeteors; i++)
            {
                int startX = rand.Next(this.Width); // 流星起始位置 X 座標
                int startY = rand.Next(this.Height); // 流星起始位置 Y 座標
                int length = rand.Next(10, 50); // 流星的長度
                int speed = rand.Next(1, 5); // 流星的速度

                Pen pen = new Pen(Color.White); // 流星的顏色

                // 繪製流星的軌跡
                e.Graphics.DrawLine(pen, startX, startY, startX + length, startY + length);

                // 讓流星以速度移動
                startX += speed;
                startY += speed;
            }
        }

        
    }
}