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
                MessageBox.Show("You click me!!!");
            }
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursor = button1.Parent.PointToClient(Cursor.Position);
            Point button = button1.Location;

            if (cursor.X < button.X + 10)
                button.X += 5;
            if (cursor.X + 10 > button.X + button1.Width) button.X += -5;
            if (cursor.Y < button.Y + 10)
                button.Y += 5;
            if (cursor.Y + 10 > button.Y + button1.Height) button.Y += -5;

            button1.Location = new Point(button.X, button.Y);

            if (button1.Left < 0)
            { button1.Left = 50; }
            if ((button1.Left + button1.Width) > this.ClientSize.Width)
            { button1.Left = this.ClientSize.Width - button1.Width * 2; }
            if (button1.Top < 0)
            { button1.Top = 50; }
            if ((button1.Top + button1.Height) > this.ClientSize.Height)
            { button1.Top = this.ClientSize.Height - button1.Height * 2; }
        }
    }
}
