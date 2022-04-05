using System;

namespace FirstTask
{
    /// <summary>
    /// Class represents polygon
    /// </summary>
    public abstract class Polygon: GeometricFigure
    {
        // TODO: we already have Segments in GeometricFigure class. We should operate them.
        private Point[] points { get; }
        /// <summary>
        /// Calculates the area of polygon
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the area</returns>
        public abstract override double GetArea(Point[]points);

        // TODO: possible implementation
        /// <summary>
        /// Calculate square of figure
        /// Formula: https://ru.wikipedia.org/wiki/%D0%9C%D0%BD%D0%BE%D0%B3%D0%BE%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA
        /// </summary>
        /// <param name="points">Array of points from which figure consists</param>
        /// <returns>Square of figure</returns>
        public double GetArea2(Point[] points)
        {
            double sum = 0;

            for (var iterator = 0; iterator < points.Length - 1; iterator++)
            {
                sum += (points[iterator].X + points[iterator+1].X) *
                       (points[iterator].Y - points[iterator+1].Y);
            }

            sum += (points[points.Length].X + points[0].X) *
                   (points[points.Length].Y - points[0].Y);

            var square = 0.5f * Math.Abs(sum);
            return square;
        }

        /// <summary>
        /// Calculates the perimeter of polygon
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the perimeter</returns>
        /// TODO: "new" not need here.
        /// TODO: original method has another signature
        /// TODO: double GetPerimeter(Point[] points)
        public new double GetPerimeter()
        {
            Segments = new Segment[points.Length];
            int i = 0;
            for (; i < points.Length - 1; i++)
            {
                Segments[i].A = points[i];
                Segments[i].B = points[i + 1];
            }
            Segments[i].A = points[i];
            Segments[i].B = points[0];
            var perimeter = 0d;
            for (i = 0; i < Segments.Length; i++)
            {
                perimeter += Segments[i].GetLength();
            }
            return Math.Round(perimeter, 2);
        }
    }
}
