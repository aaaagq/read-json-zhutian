
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace 读取json分析修改
{
    public partial class Form1 : Form
    {
        MyJsonTool myJsonTool = new MyJsonTool();

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string str = listBox1.Items[i].ToString();
                if (myJsonTool.jsonDesc.ContainsKey(str))
                {
                    listBox1.SelectedIndex = i;
                    button2_Click(sender, e);
                }

            }
        }
        void init()
        {
            Directory.CreateDirectory(MyZIP.path1);
            Directory.CreateDirectory(MyZIP.path2);
            Directory.CreateDirectory(MyZIP.path3);
            myJsonTool.init();
            listBox1.Items.Clear();

            string[] fns = Directory.GetFiles(myJsonTool.inputFilePath, "*.json");
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
            foreach (string fn in fns)
            {
                if (myJsonTool.jsonDesc.ContainsKey(fn))
                    listBox1.Items.Add(fn);
                else
                    listBox1.Items.Add(fn);

            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();
            string str = listBox1.Items[e.Index].ToString();
            if (myJsonTool.jsonDesc.ContainsKey(str))
                e.Graphics.DrawString(str, e.Font, Brushes.Blue, new PointF(e.Bounds.X, e.Bounds.Y));
            else
                e.Graphics.DrawString(str, e.Font, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            // 如果需要，可以自定义其他绘制逻辑

            //e.Graphics.DrawRectangle(Pens.Black, e.Bounds);

            e.DrawFocusRectangle();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems == null) return;
            string FileName = listBox1.SelectedItems[0]?.ToString() ?? "";
            DataTable dt = myJsonTool.jsonGetdt(FileName);
            dataGridView1.DataSource = dt;

            if (myJsonTool.jsonDesc.ContainsKey(FileName))
            {
                textBox1.Text = myJsonTool.getJsonSetdesc(FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Directory.CreateDirectory(myJsonTool.outputFilePath);
            string FileName = listBox1.SelectedItem?.ToString() ?? "";
            myJsonTool.runCOM(FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            init();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file1 = MyZIP.path1 + "gg.json";
            string file2 = MyZIP.path3 + "gg.json";
            if (File.Exists(file1))
            {
                MyZIP.ExtractGG();
                string str1 = File.ReadAllText(file1);
                string str2 = File.ReadAllText(file2);
                if (str1 == str2)
                {
                    var getJson = MessageBox.Show(
                        "只有首次或者才更新游戏才需要重新获取json。\r\n不建议再次获取json。\r\n点击【确认】后确认获取json。",
                        "警告", MessageBoxButtons.OKCancel);
                    if (getJson.ToString() != "OK") return;
                }
            }
            MyZIP.ExtractToFile();
            init();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyZIP.Update();
            MessageBox.Show("已保存！");
        }
    }


}
