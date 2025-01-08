namespace 读取json分析修改
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel4 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(0, 43);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(228, 384);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(234, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(736, 553);
            dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 553);
            panel1.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(234, 43);
            panel4.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(181, 11);
            button3.Name = "button3";
            button3.Size = new Size(47, 23);
            button3.TabIndex = 5;
            button3.Text = "刷新";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 4);
            button2.Name = "button2";
            button2.Size = new Size(69, 36);
            button2.TabIndex = 3;
            button2.Text = "指定修改";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(78, 4);
            button1.Name = "button1";
            button1.Size = new Size(67, 36);
            button1.TabIndex = 4;
            button1.Text = "全修改";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 427);
            panel3.Name = "panel3";
            panel3.Size = new Size(234, 126);
            panel3.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(228, 120);
            textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 553);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private TextBox textBox1;
        private Panel panel4;
        private Button button3;
    }
}
