using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public int speed_left = 30;
        public int speed_top = 30;
        public int speed_point = 0;

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide(); //hide the cruzor

            this.FormBorderStyle = FormBorderStyle.None; //remove any border
            this.TopMost = true; //bring the from to the front
            //this.Bounds = Screen.PrimaryScreen.Bounds; //full screen
            racket.Top = palyground.Bottom - (palyground.Bottom / 10); //beállítája a labdát
            label2.Visible = false;
            label4.Visible = false;

        }

   
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //quit
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //pause 
            if(e.KeyCode == Keys.Space)
            {
                if(timer1.Enabled == true)
                {
                    timer1.Stop();
                }else if(timer1.Enabled == false)
                {
                    timer1.Start();
                }
            }
            if(e.KeyCode == Keys.F1)
            {
                ball.Left = 50;
                ball.Top = 50;
                speed_left = 30;
                speed_top = 30;
                speed_point = 0;
                label1.Text = "0";
                timer1.Enabled = true;
                label2.Visible = false;
            }
            if(e.KeyCode == Keys.F2)
            {
                ball.Left = 50;
                ball.Top = 50;
                speed_left = 50;
                speed_top = 50;
                speed_point = 0;
                label1.Text = "0";
                timer1.Enabled = true;
                label2.Visible = false;
            }
            if (e.KeyCode == Keys.F3)
            {
                ball.Left = 50;
                ball.Top = 50;
                speed_left = 70;
                speed_top = 70;
                speed_point = 0;
                label1.Text = "0";
                timer1.Enabled = true;
                label2.Visible = false;
            }
            if(e.KeyCode == Keys.F6)
            {
                ball.Left = 50;
                ball.Top = 50;
                speed_left = 30;
                speed_top = 30;
                speed_point = 0;
                label1.Text = "0";
                timer1.Enabled = true;
                label2.Visible = false;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (ball.Width / 2); //set the center of the racket  to the pos. of the cursor
            ball.Left += speed_left; //move the ball
            ball.Top += speed_top;

            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom
                && ball.Right >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top; //change direction
                speed_point += 1;
                label1.Text = speed_point.ToString();
            }
            if(ball.Left <= palyground.Left)
            {
                speed_left = -speed_left;
            }

            if(ball.Right >= palyground.Right)
            {
                speed_left = -speed_left;
            }

            if(ball.Top <= palyground.Top)
            {
                speed_top = -speed_top;

            }

            if(ball.Bottom >= palyground.Bottom)
            {
                timer1.Enabled = false;
                label2.Visible = true;
                if(progressBar1.Value >= 3 && progressBar1.Value <= 5)
                {
                    label4.Visible = true;
                    label4.Text = "You won a bottle of bier";
                }else if(progressBar1.Value > 5)
                {
                    label4.Visible = true;
                    label4.Text = "Nyertél akármit";
                }

            }

            progressBar1.Value = speed_point;

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
