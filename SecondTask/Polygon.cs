using System;
using System.Linq;

namespace SecondTask
{
    /// <summary>
    /// Class represents polygon
    /// </summary>
    public class Polygon : GeometricFigure, ICloneable, IComparable
    {
        public object Clone()
        {
            Polygon newPolygon = (Polygon)this.MemberwiseClone();
            Segment[] segments = new Segment[this.Segments.Length];
            newPolygon.Segments = segments;
            return newPolygon;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Polygon))
                throw new ArgumentException("Object is not a Polygon");
            Polygon polygon = (Polygon)obj;
            var firstPolygon = GetArea();
            var secondPolygon = polygon.GetArea();
            if (firstPolygon > secondPolygon)
                return 1;
            else if (secondPolygon > firstPolygon)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Polygon polygon &&
            Id == polygon.Id &&
            Segments.SequenceEqual(polygon.Segments);
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var segments in Segments)
            {
                hash ^= segments.GetHashCode();
            }
            return HashCode.Combine(Id, Segments);
        }
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

        public static Polygon operator +(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon();
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    polygon.Segments[i].FirstPoint = firstPolygon.Segments[i].FirstPoint + secondPolygon.Segments[i].FirstPoint;
                    polygon.Segments[i].SecondPoint = firstPolygon.Segments[i].SecondPoint + secondPolygon.Segments[i].SecondPoint;
                }
                return polygon;
            }
        }
        public static Polygon operator -(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon();
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    polygon.Segments[i].FirstPoint = firstPolygon.Segments[i].FirstPoint - secondPolygon.Segments[i].FirstPoint;
                    polygon.Segments[i].FirstPoint = firstPolygon.Segments[i].FirstPoint - secondPolygon.Segments[i].FirstPoint;
                }
                return polygon;
            }
        }
        public static bool operator ==(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon();
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    if ((firstPolygon.Segments[i].FirstPoint == secondPolygon.Segments[i].FirstPoint) && (firstPolygon.Segments[i].FirstPoint == secondPolygon.Segments[i].FirstPoint))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool operator !=(Polygon firstPolygon, Polygon secondPolygon)
        {
            Polygon polygon = new Polygon();
            polygon.Segments = new Segment[firstPolygon.Segments.Length];
            if (firstPolygon.Segments.Length != secondPolygon.Segments.Length)
            {
                throw new InvalidOperationException("Different count of sides.");
            }
            else
            {
                for (int i = 0; i < firstPolygon.Segments.Length; i++)
                {
                    if ((firstPolygon.Segments[i].FirstPoint != secondPolygon.Segments[i].FirstPoint) && (firstPolygon.Segments[i].FirstPoint != secondPolygon.Segments[i].FirstPoint))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static implicit operator Polygon(Segment[] segments)
        {
            Polygon polygon = new Polygon();
            polygon.Segments = segments;
            return polygon;
        }

        public static explicit operator Segment[](Polygon polygon)
        {
            return polygon.Segments;
        }
    }

}
