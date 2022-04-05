using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstTask
{
    /// <summary>
    /// Class represents triangle
    /// </summary>
    public class Triangle : Polygon
    {
        // TODO: could be readonly field
        private Point[] points { get; set; }

        // TODO: Create constructor in which need to limit count of sent lines (3 - for triangle, 6 - for hexagon)
        public Triangle(Segment[] segments)
        {
            if (segments.Length != 3)
            {
                throw new InvalidOperationException("Wrong count of sides.");
            }
            this.Segments = segments;
        }

        public Triangle(Triangle triangle)
        {
            this.Segments = triangle.Segments;
        }

        public static implicit operator Triangle(Segment[] segments)
        {
            return new Triangle(segments);
        }

        public static explicit operator Segment[](Triangle triangle)
        {
            return triangle.Segments;
        }

        public Triangle(Point[] points)
        {
            if (points.Length != 3)
            {
                throw new InvalidOperationException("");
            }

            this.Segments = new Segment[3];
            for (var i = 0; i < points.Length - 1; i++)
            {
                this.Segments[i] = new Segment(points[i], points[i + 1]);
            }

            this.Segments[points.Length - 1] = new Segment(points[^1], points[0]);
        }

        /// <summary>
        /// Calculates the area of triangle
        /// </summary>
        /// <param name="points">Count of points</param>
        /// <returns>Returns the area of triangle</returns>
        /// TODO: order of modifiers like "public override sealed" is wrong
        /// TODO: https://stackoverflow.com/questions/191929/is-there-a-convention-to-the-order-of-modifiers-in-c
        public sealed override double GetArea()
        {
            var sumOfSegments = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                sumOfSegments += Segments[i].GetLength();
            }
            var p = sumOfSegments / 2;
            return (double)Math.Round(Math.Sqrt(p * (p - Segments[0].GetLength()) * (p - Segments[1].GetLength()) * (p - Segments[2].GetLength())), 2);
        }

        /// <summary>
        /// Generates random coordinates for triangle
        /// </summary>
        /// <returns>Returns array with random points</returns>
        public static Point[] GetRandomCoordinatesForTriangle()
        {
            var random = new Random();
            var points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                var randomPoint = new Point();
                randomPoint.X = random.GetRandom().X;
                randomPoint.Y = random.GetRandom().Y;
                // TODO: "i" will be always less than 3
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
                   // TODO: Another option is to use LINQ method .SequenceEqual()
                   Segments.SequenceEqual(triangle.Segments) &&
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

        public override string ToString()
        {
            return String.Format($"Name: {nameof(Triangle)}, Area: {GetArea(points)}, Perimeter: {GetPerimeter(points)}");
        }

        /// TODO: usually ToString uses to represent an object as string.
        /// TODO: in case of Triangle it should be like this
        public string ToString2()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {nameof(Triangle)}");
            for (int i = 0; i < points.Length; i++)
            {
                // TODO: better to create override ToString in Point class
                stringBuilder.AppendLine($"Point #{i + 1}: X = {points[i].X}, Y = {points[i].Y}.");
            }

            for (int i = 0; i < this.Segments.Length; i++)
            {
                // TODO: better to create override ToString in Point class
                stringBuilder.AppendLine($"Point #{i + 1}: X = {this.Segments[i].A.X}, Y = {this.Segments[i].A.Y}.");
            }
            return stringBuilder.ToString();
        }
    }
}
