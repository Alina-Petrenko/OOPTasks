using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    public class Triangle : Polygon
    {
        private Random random = new Random();
        public sealed override double GetArea(Point[] _)
        {
            var sumOfSegments = 0d;
            for (int i = 0; i < Segment.Length; i++)
            {
                sumOfSegments += Segment[i].GetLength();
            }
            var p = sumOfSegments / 2;
            var area = Math.Sqrt(p * (p - Segment[0].GetLength()) * (p - Segment[1].GetLength()) * (p - Segment[2].GetLength()));
            return area;

        }
        public Point[] GetRandomCoordinatesForTriangle()
        {
            Point[] points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                points[i].X = random.GetRandom().X;
                points[i].Y = random.GetRandom().Y;
            }
            points = points.OrderBy(p => p.X).ToArray();
            return points;
        }
        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   Id == triangle.Id &&
                   EqualityComparer<Segment[]>.Default.Equals(Segment, triangle.Segment);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Segment);
        }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
