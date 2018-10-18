using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                try
                {
                    float b = float.Parse(textBox1.Text) + float.Parse(textBox2.Text);
                    label4.Text = b.ToString();
                }
                catch
                {
                    MessageBox.Show("Ошибка!!! Заполните верно все поля!!!");
                }
            }
            else if (sender == button2)
            {
                try
                {
                    Int32 b = Int32.Parse(textBox1.Text) * Int32.Parse(textBox2.Text);
                    label4.Text = b.ToString();
                }
                catch
                {
                    MessageBox.Show("Ошибка!!! Заполните верно все поля!!!");
                }
            }
            else if (sender == button3)
            {
                if (float.Parse(textBox2.Text) > 0)
                {
                    try
                    {
                        float b = float.Parse(textBox1.Text) / float.Parse(textBox2.Text);
                        label4.Text = b.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!!! Заполните верно все поля!!!");
                    }
                }
                else
                    MessageBox.Show("Ошибка! На 0 делить нельзя!");
            }
            else if (sender == button4)
            {
                try
                {
                    float b = float.Parse(textBox1.Text) - float.Parse(textBox2.Text);
                    label4.Text = b.ToString();
                }
                catch
                {
                    MessageBox.Show("Ошибка!!! Заполните верно все поля!!!");
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

    }
}
