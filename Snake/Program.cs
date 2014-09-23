using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //List<Point> l = new List<Point>();
            //l.Add(new Point(0,0));
            //l.Add(new Point(1,0));
            //l.Add(new Point(2,0));
            //string s = "";
            //s = l.Contains(new Point(0, 0)).ToString();
            //MessageBox.Show(s);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
