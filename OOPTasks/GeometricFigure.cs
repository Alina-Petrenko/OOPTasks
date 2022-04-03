using System;

namespace FirstTask
{
    public abstract class GeometricFigure
    {
        public int Id { get; set; }
        public Segment[] Segment { get; set; }
        private Random random = new Random();

        public void GetPerimetr()
        {
            var perimetr = 0d;
            for (int i = 0; i < Segment.Length; i++)
            {
                perimetr += Segment[i].GetLength();
            }
        }
        public abstract double GetArea(Point[] points);
    }
}

