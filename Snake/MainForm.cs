using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snake.Data;

namespace Snake
{
    public partial class MainForm : Form
    {
        Snake.Data.Game game;
        Snake.Data.Block block;
        Graphics graphics;
        public MainForm()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            block = new Block(graphics, 20);
            game = new Snake.Data.Game(new Point(1,1),10,10,block);
            game.OnGameOver += new Snake.Data.Game.GameOverHanlder(GameOver);
            game.OnPointsChanged += new Snake.Data.Game.PointsChangedHandler(ChangePointsLabel);
            game.OnSnakeBlockCountChanged += new Snake.Data.Game.SnakeBlockCountHandler(ChangeSnakeLengthLabel);
            game.Start();
        }

        private void GameOver()
        {
            game.End();
            if (MessageBox.Show("You lose, wanna restart?", "Lose", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                graphics.Clear(SystemColors.Control);
                graphics.DrawRectangle(new Pen(Brushes.Blue), new Rectangle(0, 0, 20 * 11 + 1, 20 * 11 + 1));
                game.Start();
            }
            else
            {
                this.Close();
            }
        }

        private void ChangePointsLabel(int points)
        {
            this.pointsLabel.Text = points.ToString();
        }

        private void ChangeSnakeLengthLabel(int length)
        {
            this.snakeLengthLabel.Text = length.ToString();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            game.KeyPressHandle(e);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawRectangle(new Pen(Brushes.Blue), new Rectangle(0, 0, 20 * 11 + 1, 20 * 11 + 1));
            game.RefreshBlock();
        }
    }
}
