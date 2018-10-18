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
        private Point pt;
        private Random R = new Random();
        public Form1()
        {

            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("По форме. Х = {0}, Y = {1}", e.X, e.Y);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pt = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Panel P = new Panel();
            if (pt.X < e.X&&pt.Y<e.Y)
            {
                
                if (sender is Panel)
                {
                    Control C = (Control)sender;
                    P.Top = pt.Y + C.Top;
                    P.Left = pt.X + C.Left;
                    P.Width = e.X + C.Left - P.Left;
                    P.Height = e.Y + C.Top - P.Top;

                }
                else
                {
                    P.Top = pt.Y;
                    P.Left = pt.X;
                    P.Width = e.X - P.Left;
                    P.Height = e.Y - P.Top;
                }
            }
            else if  (pt.X > e.X&&pt.Y>e.Y)
            {
                if (sender is Panel)
                {
                    Control C = (Control)sender;
                    P.Top = e.Y + C.Top;
                    P.Left = e.X + C.Left;
                    P.Width = pt.X + C.Left - P.Left;
                    P.Height = pt.Y + C.Top - P.Top;

                }
                else
                {
                    P.Top = e.Y;
                    P.Left = e.X;
                    P.Width = pt.X - P.Left;
                    P.Height = pt.Y - P.Top;
                }
            }
            else if (pt.Y < e.Y&&pt.X>e.X)
            {
                
                if (sender is Panel)
                {
                    Control C = (Control)sender;
                    P.Top = pt.Y + C.Top;
                    P.Left = e.X + C.Left;
                    P.Width = pt.X + C.Left - P.Left;
                    P.Height = e.Y + C.Top - P.Top;

                }
                else
                {
                    P.Top = pt.Y;
                    P.Left = e.X;
                    P.Width = pt.X - P.Left;
                    P.Height = e.Y - P.Top;
                }
            }
            else if (pt.Y > e.Y && pt.X < e.X)
            {
                if (sender is Panel)
                {
                    Control C = (Control)sender;
                    P.Top = e.Y + C.Top;
                    P.Left = pt.X + C.Left;
                    P.Width = e.X + C.Left - P.Left;
                    P.Height = pt.Y + C.Top - P.Top;

                }
                else
                {
                    P.Top = e.Y;
                    P.Left = pt.X;
                    P.Width = e.X - P.Left;
                    P.Height = pt.Y - P.Top;
                }
            }
            else
            {
                return;
            }


            P.BackColor = Color.FromArgb(255, R.Next(0, 255), R.Next(0, 255), R.Next(0, 255));
            P.MouseDown += P_MouseDown;
            P.MouseUp += this.Form1_MouseUp;
            this.Controls.Add(P);
            this.Controls.SetChildIndex(P, 0);
        }

        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            this.pt = e.Location;
        }
    }
}