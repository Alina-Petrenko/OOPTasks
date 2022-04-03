using System;

namespace FirstTask
{
    public struct Segment
    {
        public Point A { get; set; }
        public Point B { get; set; }
 
        public Segment(Point a, Point b)
        {
            A = new Point();
            B = new Point();
        }
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
    }
}
