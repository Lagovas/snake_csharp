using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake.Data
{
    public interface IBlockDraw
    {
        void DrawBlock(Point block, Brush brush);
        int Size { get; set; }
    }
}
