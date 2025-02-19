using System;
using System.Windows.Forms;

namespace PinPonGame
{
    public partial class Form1 : Form
    {
        private int ballXspeed = 4;
        private int ballYspeed = 4;
        private const int SpeedChangeInterval = 50;
        private int speed = 2;
        private int computerSpeedChange = SpeedChangeInterval;
        private int playerScore = 0;
        private int computerScore = 0;
        private const int PlayerSpeed = 8;
        private bool goDown, goUp;
        private readonly Random rand = new Random();
        private readonly int[] speedOptions = { 5, 6, 8, 9 };
        private readonly int[] ballSpeedOptions = { 10, 9, 8, 11, 12 };

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) goDown = true;
            if (e.KeyCode == Keys.Up) goUp = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) goDown = false;
            if (e.KeyCode == Keys.Up) goUp = false;
        }

        private void CheckCollision(PictureBox ball, PictureBox paddle, int offset)
        {
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                ball.Left = offset;
                ballXspeed = (ballXspeed < 0 ? 1 : -1) * ballSpeedOptions[rand.Next(ballSpeedOptions.Length)];
                ballYspeed = (ballYspeed < 0 ? -1 : 1) * ballSpeedOptions[rand.Next(ballSpeedOptions.Length)];
            }
        }

        private void ResetGame(string message)
        {
            GameTimer.Stop();
            MessageBox.Show(message, "Oyun Sonucu");
            playerScore = 0;
            computerScore = 0;
            ballXspeed = ballYspeed = 4;
            computerSpeedChange = SpeedChangeInterval;
            ball.Left = this.ClientSize.Width / 2;
            ball.Top = this.ClientSize.Height / 2;
            GameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;
            this.Text = $"Player Score: {playerScore} -- Computer Score: {computerScore}";

            // Duvar çarpýþmalarý
            if (ball.Top <= 0 || ball.Bottom >= this.ClientSize.Height)
                ballYspeed = -ballYspeed;

            // Sol kenarý geçtiyse (bilgisayar puan kazandý)
            if (ball.Left <= 0)
            {
                ball.Left = this.ClientSize.Width / 2;
                ballXspeed = -ballXspeed;
                computerScore++;
            }
            // Sað kenarý geçtiyse (oyuncu puan kazandý)
            if (ball.Right >= this.ClientSize.Width)
            {
                ball.Left = this.ClientSize.Width / 2;
                ballXspeed = -ballXspeed;
                playerScore++;
            }

            // Bilgisayar hareketleri
            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > this.ClientSize.Width / 2)
                computer.Top -= speed;
            else if (ball.Top > computer.Top + (computer.Height / 2) && ball.Left > this.ClientSize.Width / 2)
                computer.Top += speed;

            computerSpeedChange--;
            if (computerSpeedChange <= 0)
            {
                speed = speedOptions[rand.Next(speedOptions.Length)];
                computerSpeedChange = SpeedChangeInterval;
            }

            // Oyuncu hareketleri
            if (goDown && player.Bottom < this.ClientSize.Height)
                player.Top += PlayerSpeed;
            if (goUp && player.Top > 0)
                player.Top -= PlayerSpeed;

            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);

            // Oyun bitiþ kontrolü
            if (computerScore >= 5)
                ResetGame("Üzgünüm, Kaybettiniz!");
            else if (playerScore >= 5)
                ResetGame("Tebrikler, Kazandýnýz!");
        }
    }
}
