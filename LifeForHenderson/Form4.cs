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
    public partial class Form4 : Form
    {
        int  m=0 ; 


        private void button3_Click(object sender, EventArgs e)
        {
            

            if (m==0)
            {
                listBox1.Items.Add(1);
                m++;
                listBox1.ForeColor = Color.Red;
            }
            else if (m ==1)
            {
                listBox2.Items.Add(1);
                m++;
                listBox2.ForeColor = Color.Red;
            }
            else if (m ==2)
            {
                listBox3.Items.Add(1);
                m++;
                listBox3.ForeColor = Color.Green;
            }
            else if (m ==3)
            {
                listBox4.Items.Add(1);
                m++;
                listBox4.ForeColor = Color.Red;
            }
            else if (m ==4)
            {
                listBox5.Items.Add(1);
                m = 0;
                listBox5.ForeColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m == 0)
            {
                listBox1.Items.Add(8);
                m++;
                listBox1.ForeColor = Color.Red;
            }
            else if (m == 1)
            {
                listBox2.Items.Add(8);
                m++;
                listBox2.ForeColor = Color.Red;
            }
            else if (m == 2)
            {
                listBox3.Items.Add(8);
                m++;
                listBox3.ForeColor = Color.Red;
            }
            else if (m == 3)
            {
                listBox4.Items.Add(8);
                m++;
                listBox4.ForeColor = Color.Red;
            }
            else if (m == 4)
            {
                listBox5.Items.Add(8);
                m = 0;
                listBox5.ForeColor = Color.Green;
                if(listBox1.ForeColor==Color.Blue && listBox2.ForeColor == Color.Green && listBox3.ForeColor == Color.Green && listBox4.ForeColor == Color.Blue && listBox5.ForeColor == Color.Green)
                {
                    this.Hide();
                    var newform = new Form5();
                    newform.Show();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m == 0)
            {
                listBox1.Items.Add(4);
                m++;
                listBox1.ForeColor = Color.Red;
            }
            else if (m == 1)
            {
                listBox2.Items.Add(4);
                m++;
                listBox2.ForeColor = Color.Green;
            }
            else if (m == 2)
            {
                listBox3.Items.Add(4);
                m++;
                listBox3.ForeColor = Color.Red;
            }
            else if (m == 3)
            {
                listBox4.Items.Add(4);
                m++;
                listBox4.ForeColor = Color.Red;
            }
            else if (m == 4)
            {
                listBox5.Items.Add(4);
                m = 0;
                listBox5.ForeColor = Color.Red;
            }
        }

        public Form4()
        {
            InitializeComponent();
        }
        private void Number1_mouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Number1_Click(object sender, EventArgs e)
        {
            

            if (m==0)
            {
                listBox1.Items.Add(2);
                m++;
                    listBox1.ForeColor = Color.Blue;
            }
            else if (m==1)
            {
                listBox2.Items.Add(2);
                m++;
                listBox2.ForeColor = Color.Red;
            }
            else if (m ==2)
            {
                listBox3.Items.Add(2);
                m++;
                listBox3.ForeColor = Color.Red;
            }
            else if (m ==3)
            {
                listBox4.Items.Add(2);
                m++;
                listBox4.ForeColor = Color.Blue;
            }
            else if (m ==4)
            {
                listBox5.Items.Add(2);
                m = 0;
                listBox5.ForeColor = Color.Red;
            }

        }
    }
}
