using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Snake.Data
{
    public class Game
    {
        #region Public fields
        public delegate void GameOverHanlder();
        public event GameOverHanlder OnGameOver;
        public delegate void PointsChangedHandler(int points);
        public event PointsChangedHandler OnPointsChanged;
        public delegate void SnakeBlockCountHandler(int length);
        public event SnakeBlockCountHandler OnSnakeBlockCountChanged;
        public Snake snake;
        public int Points
        {
            get
            {
                return points;
            }
            
            set
            {
                points = value;
                OnPointsChanged(points);
            }
        }
        #endregion

        #region Protected fields
        protected delegate bool CheckEventHandler();
        protected delegate void DoIfCheckEvent();
        protected int points;
        #endregion

        #region Private fields
        Dictionary<CheckEventHandler, DoIfCheckEvent> eventHandlers;
        Timer moveTime;
        Queue<Snake.direction> pressedDirections;
        Point block;
        Point mapStart;
        Brush BackGround { get; set; }
        Brush SnakeColor { get; set; }
        Brush BlockColor { get; set; }
        IBlockDraw blockDraw;
        int eatPoints = 100;
        #endregion

        #region Constructors
        public Game(Point MapStart, int width, int height, IBlockDraw BlockDraw)
        {
            eventHandlers = new Dictionary<CheckEventHandler, DoIfCheckEvent>();
            eventHandlers.Add(IsNewBlock, AddNewBlock);
            blockDraw = BlockDraw;
            mapStart = MapStart;
            moveTime = new Timer();
            moveTime.Interval = 100;
            moveTime.Tick += new EventHandler(Move);
            snake = new Snake(width, height);
            snake.OnBlockAddFinish += new Snake.BlockAddFinishHandler(AddSnakeBlockFinish);
            BackGround = SystemBrushes.Control;
            SnakeColor = Brushes.Blue;
            BlockColor = Brushes.Red;
            pressedDirections = new Queue<Snake.direction>();
        }
        #endregion

        #region Public methods
        public void RefreshBlock()
        {
            DrawBlock(block);
        }

        //think about change
        public void KeyPressHandle(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                case 'W':
                    pressedDirections.Enqueue(Snake.direction.Top);
                    break;
                case 'a':
                case 'A':
                    pressedDirections.Enqueue(Snake.direction.Left);
                    break;
                case 's':
                case 'S':
                    pressedDirections.Enqueue(Snake.direction.Bottom);
                    break;
                case 'd':
                case 'D':
                    pressedDirections.Enqueue(Snake.direction.Right);
                    break;
            }
        }

        public void Start()
        {
            snake.Reset();
            Points = 0;
            moveTime.Enabled = true;
            OnSnakeBlockCountChanged(snake.CountBlocks);
            NewBlock();
        }

        public void End()
        {
            moveTime.Enabled = false;
        }

        public void SetSnakeColor(Brush color)
        {
            SnakeColor = color;
        }

        public void SetBlockColor(Brush color)
        {
            BlockColor = color;
        }

        public void SetBackGroundColor(Brush color)
        {
            BackGround = color;
        }
        #endregion

        #region Protected methods
        protected void AddEventHandler(CheckEventHandler checkEvent, DoIfCheckEvent doIfCheck)
        {
            eventHandlers.Add(checkEvent, doIfCheck);
        }

        protected bool IsNewBlock()
        {
            if (snake.Head == block)
            {
                return true;
            }
            return false;
        }

        protected void AddNewBlock()
        {
            snake.AddBlock();
            Points += eatPoints;
            NewBlock();
            OnSnakeBlockCountChanged(snake.CountBlocks);
        }
        #endregion

        #region Private methods
        private void Move(object sender, EventArgs e)
        {
            Move();
        }

        private bool Move()
        {
            if (pressedDirections.Count > 0)
            {
                snake.ChangeDirection(pressedDirections.Dequeue());
            }

            ClearBlock(snake.Tail);
            if (!snake.Move())
            {
                OnGameOver();
                return false;
            }


            foreach (CheckEventHandler check in eventHandlers.Keys)
            {
                if (check())
                {
                    eventHandlers[check]();
                }
            }

            if (IsNewBlock())
            {
                AddNewBlock();
            }
            DrawSnakeBlock(snake.Head);
            return true;
        }

        private void NewBlock()
        {
            Random ran = new Random();
            bool contains = false;
            do 
            {
                contains = false;
                block = new Point(ran.Next(0, snake.Width), ran.Next(0, snake.Height));
                if (snake.BlockPositions.Contains(block))
                {
                    contains = true;
                }
            } while (contains);
            DrawBlock(block);
        }

        private void ClearBlock(Point p)
        {
            Draw(p, BackGround);
        }

        private void DrawSnakeBlock(Point p)
        {
            Draw(p, SnakeColor);
        }

        private void DrawBlock(Point p)
        {
            Draw(p, BlockColor);
        }

        private void Draw(Point p, Brush color)
        {
            Point block = new Point(p.X*blockDraw.Size + mapStart.X, p.Y*blockDraw.Size + mapStart.Y);
            blockDraw.DrawBlock(block, color);
        }

        private void AddSnakeBlockFinish(Point block)
        {
            DrawSnakeBlock(snake.Tail);
        }
        #endregion

    }
}
