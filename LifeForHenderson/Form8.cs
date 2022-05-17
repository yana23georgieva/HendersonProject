using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form8 : Form
    {
        bool goleft;
        bool goright;
        int speed = 8;
        int score = 0;
        int missed = 0;
        Random rndY = new Random();
        Random rndX = new Random();
        PictureBox splash = new PictureBox();

        public Form8()
        {
            InitializeComponent();
            reset();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void gametick(object sender, EventArgs e)
        {
            label1.Text = "Събран боклук: " + score;
            label2.Text = "Пропуснат боклук: " + missed;
            if (goleft == true && chicken.Left > 0)
            {
                chicken.Left -= 12;
            }
            if (goright == true && chicken.Left + chicken.Width < this.ClientSize.Width)
            {
                chicken.Left += 12;
            }
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Tag == "Eggs")
                {
                    X.Top += speed;
                    if (X.Top + X.Height > this.ClientSize.Height)
                    {
                        splash.Location = X.Location;
                        splash.Height = 59;
                        splash.Width = 60;
                        splash.BackColor = System.Drawing.Color.Transparent;

                        this.Controls.Add(splash);

                        X.Top = rndY.Next(80, 300) * -1;
                        X.Left = rndX.Next(5, this.ClientSize.Width - X.Width);
                        missed++;
                    }
                    if (X.Bounds.IntersectsWith(chicken.Bounds))
                    {
                        X.Top = rndY.Next(100, 300) * -1;
                        X.Left = rndX.Next(5, this.ClientSize.Width - X.Width);
                        score++;
                    }
                    if (score >= 20)
                    {
                        speed = 13;
                    }
                    if (missed > 5)
                    {
                        timer1.Stop();
                        MessageBox.Show("Край на играта! Ти успя да събереш: " + score + " пластмасови бутилки и помогна за опазването на Световния океан.  Натисни OK за НОВА ИГРА! или Exit за ИЗХОД");
                        reset();
                    }
                }
            }
        }
        private void reset()
        {
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Tag == "Eggs")
                {
                    X.Top = rndY.Next(80, 300) * -1;
                    X.Left = rndX.Next(5, this.ClientSize.Width - X.Width);
                }
            }
            chicken.Left = this.ClientSize.Width / 2;

            score = 0;
            speed = 8;
            missed = 0;

            goleft = false;
            goright = false;
            timer1.Start();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
