using System;

namespace SecondTask
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
        /// <returns>Returns the perimeter</returns>
        public virtual double GetPerimeter()
        {
            var perimeter = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                perimeter += Segments[i].GetLength();
            }
            return Math.Round(perimeter, 2);
        }

        /// <summary>
        /// Calculates the area of geometric figure
        /// </summary>
        /// <returns>Returns the area</returns>
        public abstract double GetArea();
    }
}

