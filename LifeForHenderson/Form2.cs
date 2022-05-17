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

    public partial class Form2 : Form
    {
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        bool haskey = false;
        bool haskay1 = false;
        bool haskay2 = false;
        bool haskay3 = false;
        bool haskay4 = false;

        int jumpspeed = 10;
        int force = 8;

        int playspeed = 18;
        int backLeft = 8;
        public Form2()
        {
            InitializeComponent();
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            player.Top += jumpspeed;
            player.Refresh();
            if (jumping && force < 0)
            {
                jumping = false;
            }
            if (goleft&&player.Left>100)
            {
                player.Left -= playspeed;
                
            }
            if (goright&&player.Left + (player.Width + 100)< this.ClientSize.Width)
            {
                player.Left += playspeed;
                
            }
            if (jumping)
            {
                jumpspeed = -12;
                force -= 1;
            }
            else
            {
                jumpspeed = 12;
            }
            if (goright)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "door"|| x is PictureBox && x.Tag == "key")
                    {
                        x.Left -= backLeft;
                    }
                }
            }
            if (goleft)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "door"||x is PictureBox && x.Tag == "key")
                    {
                        x.Left += backLeft;
                    }
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }
                if (x is PictureBox && x.Tag == "key")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
                if
                (player.Bounds.IntersectsWith(door.Bounds) && haskey==true && haskay1==true && haskay2==true && haskay3==true && haskay4==true)
                {
                    timer1.Stop();
                this.Hide();
                var newform = new Form3();
                newform.Show();
            }
                if(haskey == true && haskay1 == true && haskay2 == true && haskay3 == true && haskay4 == true)
            {
                door.Image = Properties.Resources.door_open1;
            }
            if
                (player.Bounds.IntersectsWith(key.Bounds))
            {
                this.Controls.Remove(key);
                haskey = true;
            }
            if
                (player.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                this.Controls.Remove(pictureBox10);
                haskay1 = true;
            }
            if
                (player.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                this.Controls.Remove(pictureBox7);
                haskay2 = true;
            }
            if
                (player.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                this.Controls.Remove(pictureBox8);
                haskay3 = true;
            }
            if
                (player.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                this.Controls.Remove(pictureBox9);
                haskay4 = true;
            }
            if (player.Top + player.Height>this.ClientSize.Height+60)
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show("Желаете ли да играете отново?","You Died!",MessageBoxButtons.YesNo);
                if(dialog==DialogResult.Yes)
                {
                    timer1.Start();
                    Application.Restart();
                }
                if (dialog == DialogResult.No)
                {
                    Application.Exit();
                }
            }
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
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
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
            if(jumping)
            {
                jumping = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox7.BackColor = System.Drawing.Color.Transparent;

        }
    }
}
