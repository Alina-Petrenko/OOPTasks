using System;

namespace FirstTask
{
    /// <summary>
    /// Class represents polygon
    /// </summary>
    public abstract class Polygon: GeometricFigure
    {
        /// <summary>
        /// Calculates the area of polygon
        /// </summary>
        /// <returns>Returns the area</returns>
        public override double GetArea()
        {
            double sum = 0;
            for (var iterator = 0; iterator < this.Segments.Length; iterator++)
            {
                sum += (this.Segments[iterator].FirstPoint.X + this.Segments[iterator].SecondPoint.X) *
                       (this.Segments[iterator].FirstPoint.Y - this.Segments[iterator].SecondPoint.Y);
            }
            return (double)(0.5f * Math.Abs(sum));
        }

        /// <summary>
        /// Calculates the perimeter of polygon
        /// </summary>
        /// <returns>Returns the perimeter</returns>
        public new double GetPerimeter()
        {
            var perimeter = 0d;
            for (int i = 0; i < Segments.Length; i++)
            {
                perimeter += Segments[i].GetLength();
            }
            return Math.Round(perimeter, 2);
        }
    }
}
