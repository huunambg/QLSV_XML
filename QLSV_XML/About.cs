using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_XML
{
    public partial class About : Form
    {

        private List<Ball> balls;
        private Timer timer;

        public About()
        {
            InitializeComponent();
            InitializePictureBoxes();
            InitializeTimer();
        }

        private void InitializePictureBoxes()
        {
            balls = new List<Ball>
            {
                new Ball(pictureBox1, GetRandomVelocity(), GetRandomVelocity()),
                new Ball(pictureBox2, GetRandomVelocity(), GetRandomVelocity()),
                new Ball(pictureBox3, GetRandomVelocity(), GetRandomVelocity()),
                new Ball(pictureBox4, GetRandomVelocity(), GetRandomVelocity()),
                new Ball(pictureBox5, GetRandomVelocity(), GetRandomVelocity())
            };

            foreach (var ball in balls)
            {
                ball.PictureBox.BackColor = Color.Transparent;
                ball.PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ball.PictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 50; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.PictureBox.Left = (int)(ball.PictureBox.Left + ball.VelocityX);
                ball.PictureBox.Top = (int)(ball.PictureBox.Top + ball.VelocityY);

                CheckCollisionWithBorders(ball);
                CheckCollisionWithOtherBalls(ball);
            }
        }

        private void CheckCollisionWithBorders(Ball ball)
        {
            if (ball.PictureBox.Right >= pictureBox6.Right || ball.PictureBox.Left <= pictureBox6.Left)
            {
                ball.VelocityX = -ball.VelocityX; // Đảo ngược vận tốc ngang
            }

            if (ball.PictureBox.Bottom >= pictureBox6.Bottom || ball.PictureBox.Top <= pictureBox6.Top)
            {
                ball.VelocityY = -ball.VelocityY; // Đảo ngược vận tốc dọc
            }
        }

        private void CheckCollisionWithOtherBalls(Ball currentBall)
        {
            foreach (var otherBall in balls)
            {
                if (currentBall != otherBall && currentBall.PictureBox.Bounds.IntersectsWith(otherBall.PictureBox.Bounds))
                {
                    // Đảo ngược vận tốc của cả hai ball khi va chạm
                    double tempVelocityX = currentBall.VelocityX;
                    double tempVelocityY = currentBall.VelocityY;

                    currentBall.VelocityX = otherBall.VelocityX;
                    currentBall.VelocityY = otherBall.VelocityY;

                    otherBall.VelocityX = tempVelocityX;
                    otherBall.VelocityY = tempVelocityY;
                }
            }
        }

        private double GetRandomVelocity()
        {
            Random random = new Random();
            return random.NextDouble() * 15 - 5; // Vận tốc ngẫu nhiên từ -5 đến 5
        }

        private class Ball
        {
            public PictureBox PictureBox { get; set; }
            public double VelocityX { get; set; }
            public double VelocityY { get; set; }

            public Ball(PictureBox pictureBox, double velocityX, double velocityY)
            {
                PictureBox = pictureBox;
                VelocityX = velocityX;
                VelocityY = velocityY;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
