using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HwGame
{
    public partial class Form2 : Form
    {
        List<int> button = new List<int>();
        int number = 0;
        public Form2()
        {
            InitializeComponent();
            this.Controls.Add(comboBox1);

            this.timer1.Tick += Timer1_Tick;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            comboBox1.Items.Add("Школьник");
            comboBox1.Items.Add("Студент");
            comboBox1.TabStop = false;

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 45;
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            if (this.progressBar1.Value < this.progressBar1.Maximum)
                this.progressBar1.Value++;
            else
            {
                this.timer1.Stop();
                MessageBox.Show("Время закончилось! Попробуйте еще.");
                tableLayoutPanel2.Controls.Clear();
                number = 0;
                button.Clear();
                progressBar1.Value = 0;
            }

        }

        private void Start_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            tableLayoutPanel2.Controls.Clear();
            number = 0;
            button.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                this.timer1.Interval = 1000;
                this.timer1.Start();
                tableLayoutPanel2.Controls.Clear();
                comboBox1.TabStop = false;
                tableLayoutPanel2.ColumnCount = 7;

                Random R = new Random();

                while (button.Count < 35)
                {
                    int n = R.Next(1, 36);
                    while (button.Contains(n))
                        n = R.Next(1, 36);
                    button.Add(n);
                    Button B = new Button();
                    B.Name = n.ToString();
                    B.Text = n.ToString();
                    B.Size = new Size(45, 45);
                    B.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    tableLayoutPanel2.Controls.Add(B);
                    B.Click += B_Click;
                    B.TabStop = false;
                }
            }

            if (comboBox1.SelectedIndex == 1)
            {
                this.timer1.Interval = 4000;
                this.timer1.Start();
                tableLayoutPanel2.Controls.Clear();
                comboBox1.TabStop = false;
                tableLayoutPanel2.ColumnCount = 10;

                Random R = new Random();

                while (button.Count < 70)
                {
                    int n = R.Next(1, 71);
                    while (button.Contains(n))
                        n = R.Next(1, 71);
                    button.Add(n);
                    Button B = new Button();
                    B.Name = n.ToString();
                    B.Text = n.ToString();
                    B.Size = new Size(30, 30);
                    B.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    tableLayoutPanel2.Controls.Add(B);
                    B.Click += B_Click;
                    B.TabStop = false;

                }
            }

        }

        private void B_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Name == (number + 1).ToString())
            {
                clickedButton.Enabled = false;
                number++;
                if (clickedButton.Name == button.Count.ToString())
                {
                    this.timer1.Stop();
                    MessageBox.Show("Победа!!!");
                    tableLayoutPanel2.Controls.Clear();
                    number = 0;
                    button.Clear();
                    this.progressBar1.Value = 0;
                }

            }

            else
            {
                this.timer1.Stop();
                MessageBox.Show("Вы проиграли! Попробуйте еще раз.");
                tableLayoutPanel2.Controls.Clear();
                number = 0;
                button.Clear();
                this.progressBar1.Value = 0;

            }
        }

    }
}
