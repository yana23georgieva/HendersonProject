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
    public partial class Form6 : Form
    {
        bool goup;
        bool godown;
        int speed = 8;
        Random rand = new Random();
        int playerSpeed = 7;
        int index = 0,n;
        public Form6()
        {
            InitializeComponent();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void gametick(object sender, EventArgs e)
        {
            pictureBox2.Left -= speed;
            pictureBox3.Left -= speed;
            pictureBox1.Left -= speed;
            pictureBox4.Left -= speed;
            pictureBox5.Left -= speed;
            pictureBox6.Left -= speed;

            if (goup)
            {
                player.Top -= playerSpeed;
            }
            if (godown)
            {
                player.Top += playerSpeed;
            }
            if(pictureBox2.Left<-150)
            {
                pictureBox2.Left = 900;
            }
            if (pictureBox3.Left < -150)
            {
                pictureBox3.Left = 1000;
            }
            if (pictureBox1.Left < -150)
            {
                pictureBox1.Left = 1100;
            }
            if (pictureBox4.Left < -150)
            {
                pictureBox4.Left = 1200;
            }
            if (pictureBox5.Left < -150)
            {
                pictureBox5.Left = 1300;
            }
            if (pictureBox6.Left < -150)
            {
                pictureBox6.Left = 1400;
            }
            if(player.Top + player.Height>this.ClientSize.Height+20)
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show("Желаете ли да играете отново?", "You Lose!", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    timer1.Start();
                    this.Close();
                    var newform = new Form6();
                    newform.Show();

                }
                if (dialog == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if (player.Top + player.Height < this.ClientSize.Height-350)
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show("Желаете ли да играете отново?", "You Lose!", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    timer1.Start();
                    this.Close();
                    var newform = new Form6();
                    newform.Show();

                }
                if (dialog == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if (player.Bounds.IntersectsWith(pictureBox2.Bounds) || player.Bounds.IntersectsWith(pictureBox3.Bounds) || player.Bounds.IntersectsWith(pictureBox1.Bounds) || player.Bounds.IntersectsWith(pictureBox4.Bounds) || player.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show("Желаете ли да играете отново?", "You Lose!", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    timer1.Start();
                    this.Close();
                    var newform = new Form6();
                    newform.Show();

                }
                if (dialog == DialogResult.No)
                {
                    Application.Exit();
                }

            }
            else index++;
            if(index==1000)
            {
                pictureBox6.Visible = true;
            }
            if (player.Bounds.IntersectsWith(pictureBox6.Bounds) && pictureBox6.Visible==true)
            {
                timer1.Stop();
                this.Hide();
                var newform = new Form7();
                newform.Show();
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
        }
    }
}
