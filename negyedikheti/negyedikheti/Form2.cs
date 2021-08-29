using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negyedikheti
{
    public partial class Form2 : Form
    {
        bool goRight;
        bool goLeft;
        int speed = 10;

        int ballx = 5;
        int bally = 5;

        int score = 0;

        private Random rnd = new Random();
        Model model;
        public Form2(Model mod)
        {
            model = mod;
            InitializeComponent();
            player.BackColor = Color.White;
            player.Enabled = false;
            player.Text = "player";
            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && item.Tag == "block")
                {
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    item.BackColor = randomColor;
                }
            }
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Left && player.Left > 0)
                {
                    goLeft = true;
                }
                if (e.KeyCode == Keys.Right && player.Left + player.Width < 900)
                {
                    goRight = true;
                }
            };
            KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Left)
                {
                    goLeft = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    goRight = false;
                }
            };
            timer1.Tick += (s, e) =>
            {
                ball.Left += ballx;
                ball.Top += bally;
                label1.Text = "Score: " + score;
                if (goLeft)
                {
                    player.Left -= speed;
                }
                if (goRight)
                {
                    player.Left += speed;
                }


                if (player.Left < 1)
                {
                    goLeft = false;
                }
                else if (player.Left + player.Width > 900)
                {
                    goRight = false;
                }

                if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
                {
                    ballx = -ballx;
                }
                if (ball.Top < 0 || ball.Bounds.IntersectsWith(player.Bounds))
                {
                    bally = -bally;
                }
                if (ball.Top + ball.Height > ClientSize.Height)
                {
                    timer1.Stop();
                    MessageBox.Show("You died.");
                    mod.PontExport(Convert.ToString(score));
                    this.Close();
                }
                foreach (Control item in this.Controls)
                {
                    if(item is PictureBox && item.Tag=="block")
                    {
                        if(ball.Bounds.IntersectsWith(item.Bounds))
                        {
                            this.Controls.Remove(item);
                            bally = -bally;
                            score++;
                        }
                    }
                }
                if(score>24)
                {
                    timer1.Stop();
                    MessageBox.Show("You Win");
                    mod.PontExport(Convert.ToString(score));
                    this.Close();
                }
            };
        }
    }
}
