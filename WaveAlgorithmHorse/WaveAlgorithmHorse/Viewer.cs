using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveAlgorithmHorse
{
    public static class Viewer
    {

        public static float Width { get; set; }
        public static float SquareSide{get;set;}

        private static void DrawSquare(Graphics graphics, float X, float Y, Color color)
        {
            Brush brush = new SolidBrush(color);
                      
            graphics.FillRectangle(brush, X, Y, SquareSide, SquareSide);
        }
        public static void CreateTable(Graphics grafics)
        {
            grafics.Clear(SystemColors.Control);
            float dif = 50;
            Width = 500;
            float X = dif;
            float Y = dif;
            SquareSide = dif;
            for (int i = 0; i < 8; i++)
            {
                X = dif;
                for (int j = 0; j < 8; j++)
                {
                    Color color = (i + j) % 2 == 0 ? Color.Gray : Color.White;
                    DrawSquare(grafics, X, Y, color);
                    X += dif;
                }
                Y += dif;
            }
        }

        public static void WriteNum(Graphics graphics, int X, int Y,int Num)
        {
            float x = SquareSide + SquareSide * X + SquareSide / 2;
            float y = SquareSide + SquareSide * Y + SquareSide / 2;

            Brush brush = new SolidBrush(Color.Black);
            graphics.DrawString(Num.ToString(), new Font(FontFamily.GenericSansSerif, 10), brush, x, y);
        }
    }
}
