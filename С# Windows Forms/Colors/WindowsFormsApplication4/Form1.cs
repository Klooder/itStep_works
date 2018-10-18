using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        int red;
        int blue;
        int green;
        public Form1()
        {
            InitializeComponent();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            red= (checkBox1.Checked)? 255 : 0;
            green = (checkBox2.Checked) ? 255 : 0;
            blue = (checkBox3.Checked) ? 255 : 0;
            this.BackColor = Color.FromArgb(red, green, blue);
            this.ForeColor = Color.FromArgb((red == 0) ? 255 : 0, (green == 0) ? 255 : 0, (blue == 0) ? 255 : 0);

        }

    }
}
