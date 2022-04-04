using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    /// <summary>
    /// Class represents triangle
    /// </summary>
    public class Triangle : Polygon
    {
        private Random random = new Random();
        private Point[] points { get; set;} 

        /// <summary>
        /// Calculates the area of triangle
        /// </summary>
        /// <param name="points">Count of points</param>
        /// <returns>Returns the area of triangle</returns>
        public override sealed double GetArea(Point[] points)
        {
            Segments = new Segment[points.Length];
            var sumOfSegments = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                sumOfSegments += Segments[i].GetLength();
            }
            var p = sumOfSegments / 2;
            return (double)Math.Round(Math.Sqrt(p * (p - Segments[0].GetLength()) * (p - Segments[1].GetLength()) * (p - Segments[2].GetLength())),2);
        }

        /// <summary>
        /// Generates random coordinates for triangle
        /// </summary>
        /// <returns>Returns array with random points</returns>
        public Point[] GetRandomCoordinatesForTriangle()
        {
            points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                var randomPoint = new Point();
                randomPoint.X = random.GetRandom().X;
                randomPoint.Y = random.GetRandom().Y;
                if (i < 3 && !points.Contains(randomPoint))
                {
                    points[i].X = random.GetRandom().X;
                    points[i].Y = random.GetRandom().Y;
                }
            }
            return points;
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   Id == triangle.Id &&
                   EqualityComparer<Segment[]>.Default.Equals(Segments, triangle.Segments);
        }

        /// <summary>
        /// Gets hash code of value
        /// </summary>
        /// <returns>Returns Hash Code of value</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Segments);
        }

        /// <summary>
        /// Converts the value as a string
        /// </summary>
        /// <returns>Returns converted value</returns>
        /// 
        public override string ToString()
        {
            return String.Format($"Name: {nameof(Triangle)}, Area: {GetArea(points)}, Perimeter: {GetPerimeter(points)}");
        }
    }
}
