using System;

namespace FirstTask
{
    /// <summary>
    /// Class represents Segment
    /// </summary>
    public struct Segment
    {
        // TODO: Better to name "FirstPoint" and "SecondPoint". "A" and "B" is not obvious
        public Point A { get; set; }
        public Point B { get; set; }
        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Calculates length of segment
        /// </summary>
        /// <returns>Returns length of segment</returns>
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
    }
}
