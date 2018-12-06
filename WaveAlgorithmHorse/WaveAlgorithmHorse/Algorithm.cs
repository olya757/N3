using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveAlgorithmHorse
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
    public static class Algorithm
    {
        public static int[,] matrix = new int[8,8];
        public static int startX { get; set; }
        public static int startY { get; set; }
        public static int[] Xs = { -2, -1, 1, 2, 2, 1, -1, -2 };
        public static int[] Ys = { 1, 2, 2, 1, -1, -2, -2, -1 };
        public static int Level { get; set; }
        public static void Init(int X,int Y)
        {
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = -1;
                }
            }
            matrix[X - 1, Y - 1] = 0;
            Level = 1;
        }

        public static List<Point> NextPointsFrom(int X,int Y)
        {
            List<Point> result = new List<Point>();
            
            for (int i = 0; i < 8; i++)
            {
                int tmpX = X + Xs[i];
                int tmpY = Y + Ys[i];
                if (tmpX >= 0 && tmpX < 8 && tmpY >= 0 && tmpY < 8)
                {
                    if (matrix[tmpX,tmpY]<0)
                        result.Add(new Point(tmpX,tmpY));
                }
            }
            return result;
        }

        public static bool MoveToNextLevel(Graphics grafics)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == Level)
                    {
                        points.Concat<Point>(NextPointsFrom(i, j));
                    }
                }
            }
            if (points.Count == 0)
                return false;
            Level++;
            foreach(var p in points)
            {
                matrix[p.X, p.Y] = Level;
                Viewer.WriteNum(grafics, p.X, p.Y,Level);
            }
            return true;
        }
    }
}
