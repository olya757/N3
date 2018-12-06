using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveAlgorithmHorse
{
    public partial class Form1 : Form
    {
        public static Graphics Graphics;
        public Form1()
        {
            InitializeComponent();
            Graphics = this.CreateGraphics();
          
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            if (Algorithm.Busy) return;
            if (X < Viewer.SquareSide || X > Viewer.Width - Viewer.SquareSide || Y < Viewer.SquareSide || Y > Viewer.Width - Viewer.SquareSide)
                return;
            X -= (int)Viewer.SquareSide;
            Y -= (int)Viewer.SquareSide;
            X = (int)(X / Viewer.SquareSide);
            Y = (int)(Y / Viewer.SquareSide);
            Algorithm.Init(X, Y);
            Viewer.WriteNum(Graphics, X, Y, 0);
            while (Algorithm.MoveToNextLevel(ref Graphics)) {
                Thread.Sleep(1000);
            }
            Algorithm.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Viewer.CreateTable(Graphics);
        }
    }
}
