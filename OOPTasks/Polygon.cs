using System;

namespace FirstTask
{
    /// <summary>
    /// Class represents polygon
    /// </summary>
    public abstract class Polygon: GeometricFigure
    {
        private Point[] points { get; }
        /// <summary>
        /// Calculates the area of polygon
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the area</returns>
        public abstract override double GetArea(Point[]points);

        /// <summary>
        /// Calculates the perimeter of polygon
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the perimeter</returns>
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
