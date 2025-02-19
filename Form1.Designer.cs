namespace PinPonGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            player = new PictureBox();
            computer = new PictureBox();
            ball = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)computer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // player
            // 
            player.Anchor = AnchorStyles.Left;
            player.BackColor = Color.Black;
            player.Image = Properties.Resources.player;
            player.Location = new Point(-3, 129);
            player.Name = "player";
            player.Size = new Size(30, 106);
            player.SizeMode = PictureBoxSizeMode.Zoom;
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // computer
            // 
            computer.BackColor = Color.Black;
            computer.Image = Properties.Resources.computer;
            computer.Location = new Point(773, 129);
            computer.Name = "computer";
            computer.Size = new Size(30, 106);
            computer.SizeMode = PictureBoxSizeMode.Zoom;
            computer.TabIndex = 1;
            computer.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.Transparent;
            ball.Enabled = false;
            ball.Image = Properties.Resources.ball;
            ball.Location = new Point(373, 159);
            ball.Name = "ball";
            ball.Size = new Size(50, 44);
            ball.SizeMode = PictureBoxSizeMode.Zoom;
            ball.TabIndex = 2;
            ball.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 397);
            Controls.Add(ball);
            Controls.Add(computer);
            Controls.Add(player);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PingPong Game    |     Player: 0 -- Computer: 0";
            TopMost = true;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)computer).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox player;
        private PictureBox computer;
        private PictureBox ball;
        private System.Windows.Forms.Timer GameTimer;
    }
}