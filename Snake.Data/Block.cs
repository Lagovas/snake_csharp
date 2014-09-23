using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake.Data
{
    public class Block : IBlockDraw
    {
        Graphics graphics;

        public int Size { get; set; }

        public Block(Graphics g, int size)
        {
            graphics = g;
            this.Size = size;
        }

        void IBlockDraw.DrawBlock(Point block, Brush brush)
        {
            graphics.FillRectangle(brush, new Rectangle(block.X, block.Y, Size, Size));
        }
    }
}
