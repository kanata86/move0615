using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        private static Random rand = new Random();
        Label[] labls = new Label[20];
        int[] vx = new int[50];
        int[] vy = new int[50];
        int count = 0, time = 0;

        Point msp;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 20; i++)
            {
                labls[i] = new Label();
                labls[i].Text = "★";
                labls[i].ForeColor = label1.ForeColor;
                labls[i].Font = label1.Font;
                labls[i].AutoSize = true;
                Controls.Add(labls[i]);
                vx[i] = rand.Next(10, 20);
                vy[i] = rand.Next(10, 20);
            }
            label2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            msp = MousePosition;
            msp = PointToClient(msp);
            label1.Text = "" + time;
            time += 1;

            for (int i = 0; i < 20; i++)
            {
                labls[i].Left = labls[i].Left + vx[i];
                labls[i].Top = labls[i].Top + vy[i];
                if (labls[i].Left < 0)
                {
                    vx[i] = rand.Next(10, 20); ;
                }
                if (labls[i].Left > ClientSize.Width - labls[i].Width)
                {
                    vx[i] = rand.Next(10, 20) * -1;
                }
                if (labls[i].Top < 0)
                {
                    vy[i] = rand.Next(10, 20);
                }
                if (labls[i].Top > ClientSize.Height - labls[i].Height)
                {
                    vy[i] = rand.Next(10, 20) * -1;
                }
                if ((msp.X > labls[i].Left) && (msp.X < labls[i].Right) && (msp.Y > labls[i].Top) && (msp.Y < labls[i].Bottom))
                {
                    {
                        labls[i].Visible = false;
                        labls[i].Left += 100000000;
                        labls[i].Top += 100000000;
                        vx[i] = 0;
                        vy[i] = 0;
                        count += 1;
                    }
                }
            }
            if (count == 20)
            {
                timer1.Enabled = false;
                label2.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
