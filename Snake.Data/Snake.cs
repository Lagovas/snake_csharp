using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace Snake.Data
{
    public class Snake
    {
        #region Fields
        public delegate void BlockAddFinishHandler(Point block);
        public event BlockAddFinishHandler OnBlockAddFinish;
        public enum direction { Left,Right,Top,Bottom, Empty};
        private Queue<Point> addedBlocks;
        #endregion
        
        #region Properties

        public Point Tail
        {
            get
            {
                return BlockPositions[Length - 1];
            }
        }
        public Point Head
        {
            get
            {
                return BlockPositions[0];
            }
            private set
            {
                BlockPositions[0] = value;
            }
        }
        public int CountBlocks
        {
            get
            {
                return BlockPositions.Count + addedBlocks.Count;
            }
        }
        public int Length
        {
            get
            {
                return BlockPositions.Count;
            }
        }
        public List<Point> BlockPositions { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public direction Direction { get; set; }
        #endregion

        public Snake(int width, int height)
        {
            BlockPositions = new List<Point>();
            addedBlocks = new Queue<Point>();
            BlockPositions.Add(new Point(2, 0));
            BlockPositions.Add(new Point(1, 0));
            BlockPositions.Add(new Point(0, 0));
            Height = height;
            Width = width;
            Direction = Snake.direction.Right;
        }

        private void MoveBlocks()
        {
            Point tail = Tail;
            bool newBlock = false;
            //position of new block equal tail position
            if (addedBlocks.Count > 0 && Tail == addedBlocks.Peek())
            {
                newBlock = true;
            }
            //каждая ячейка перемещается на позицию предшествующей ей
            for (int i = Length - 1; i != 0; i--)
            {
                BlockPositions[i] = BlockPositions[i - 1];
            }

            if (newBlock)
            {
                BlockPositions.Add(addedBlocks.Dequeue());
                OnBlockAddFinish(Tail);
            }
        }

        public void Reset()
        {
            BlockPositions.Clear();
            addedBlocks.Clear();
            BlockPositions.Add(new Point(2, 0));
            BlockPositions.Add(new Point(1, 0));
            BlockPositions.Add(new Point(0, 0));
            Direction = direction.Right;
        }

        public void Left()
        {
            Point p = Head;
            if (p.X == 0)//если граница поля, то появляемся с другой стороны
            {
                p.X = Width;
            }
            else
            {
                --p.X;
            }
            if (p == BlockPositions[1])
            {
                return;
            }
            Head = p;
        }

        public void Right()
        {
            Point p = Head;
            if (p.X == Width)//если граница поля, то появляемся с другой стороны
            {
                p.X = 0;
            }
            else
            {
                ++p.X;
            }
            if (p == BlockPositions[1])
            {
                return;
            }
            Head = p;
        }

        public void Top()
        {
            Point p = Head;
            if (p.Y == 0)//если граница поля, то появляемся с другой стороны
            {
                p.Y = Height;
            }
            else
            {
                --p.Y;
            }
            if (p == BlockPositions[1])
            {
                return;
            }
            Head = p;
        }

        public void Bottom()
        {
            Point p = Head;
            if (p.Y == Height)//если граница поля, то появляемся с другой стороны
            {
                p.Y = 0;
            }
            else
            {
                ++p.Y;
            }
            if (p == BlockPositions[1])
            {
                return;
            }
            Head = p;
        }

        public bool Move()
        {
            MoveBlocks();
            switch (Direction)
            {
                case direction.Left:
                    Left();
            	    break;
                case direction.Right:
                    Right();
                    break;
                case direction.Bottom:
                    Bottom();
                    break;
                case direction.Top:
                    Top();
                    break;
            }
            return isCollisionOfSnake();
        }
        
        private bool isCollisionOfSnake()
        {
            for (int i = 1; i < Length; i++)
            {
                if (Head == BlockPositions[i])
                {

                    return false;
                }
            }
            return true;
        }

        public void AddBlock()
        {
            addedBlocks.Enqueue(Head);
        }

        public void ChangeDirection(direction direct)
        {
            if ((Direction == direction.Left && direct == direction.Right) || (Direction == direction.Right && direct == direction.Left))
            {
                return;
            }
            if ((Direction == direction.Top && direct == direction.Bottom) || (Direction == direction.Bottom && direct == direction.Top))
            {
                return;
            }
            Direction = direct;
        }
    }
}
