using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(comboBox1);
          
            comboBox1.Items.Add("Украина");
            comboBox1.Items.Add("Польша");
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Запорожье");
                comboBox2.Items.Add("Киев");
                comboBox2.Items.Add("Днепр");
                comboBox2.Items.Add("Львов");
                comboBox2.Items.Add("Донецк");
            }

           else if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Краков");
                comboBox2.Items.Add("Варшава");
                comboBox2.Items.Add("Гдыня");
                comboBox2.Items.Add("Лодзь");
                comboBox2.Items.Add("Люблин");
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.Text + " - " + comboBox2.Text;
        }
    }
}
