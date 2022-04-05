using System;

namespace FirstTask
{
    /// <summary>
    /// Class represents geometric figure
    /// </summary>
    public abstract class GeometricFigure
    {
        public int Id { get; set; }
        public Segment[] Segments { get; set; }

        /// <summary>
        /// Calculates the perimeter of geometric figure
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the perimeter</returns>
        public virtual double GetPerimeter(Point[] points)
        {
            Segments = new Segment[points.Length];
            var i = 0;
            for (; i < points.Length - 1; i++)
            {
                Segments[i].A = points[i];
                Segments[i].B = points[i + 1];
            }
            Segments[i].A = points[i];
            Segments[i].B = points[0];
            var perimeter = 0d;
            // TODO: unnecessary assignment
            i = 0;
            for (i = 0; i < Segments.Length; i++)
            {
                perimeter += Segments[i].GetLength();          
            }
            return Math.Round(perimeter,2);
        }

        /// <summary>
        /// Calculates the area of geometric figure
        /// </summary>
        /// <param name="points">Array of points</param>
        /// <returns>Returns the area</returns>
        public abstract double GetArea(Point[] points);
    }
}

