using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    /// <summary>
    /// Class represents hexagon
    /// </summary>
    public class Hexagon : Polygon
    {
        private Random random = new Random();
        private Point [] points { get; set; }
        /// <summary>
        /// Calculates the area of hexagon
        /// </summary>
        /// <param name="points">Count of points</param>
        /// <returns>Returns the area of hexagon</returns>
        public override double GetArea(Point[] points)
        {
            var firstResult = 0d;
            int i = 0;
            for (; i < points.Length - 1; i++)
            {
                firstResult += (points[i].X * points[i + 1].Y);
            }
            firstResult += (points[i].X * points[0].Y);
            var secondResult = 0d;
            i = 0;
            for (; i < points.Length - 1; i++)
            {
                secondResult += (points[i + 1].X * points[i].Y);
            }

            secondResult += (points[0].X * points[i].Y);
            double area = (double)(firstResult - secondResult) / 2;
            if (area < 0)
            { 
                return -1 * area;
            }
            else
            { 
                return area;
            }
        }

        /// <summary>
        /// Generates random coordinates for hexagon
        /// </summary>
        /// <returns>Returns array with random points</returns>
        public Point[] GetRandomCoordinatesForHexagon()
        {
            points = new Point[6];
            for (int i = 0; i < points.Length; i++)
            {
                var randomPoint = new Point();
                randomPoint.X = random.GetRandom().X;
                randomPoint.Y = random.GetRandom().Y;
                if (i < 3 && !points.Contains(randomPoint))
                {
                    points[i].X = randomPoint.X;
                    points[i].Y = randomPoint.Y;
                }
                else if (i == 3)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandom().X;
                        point.Y = random.GetRandom().Y;
                        if (!points.Contains(point) 
                            && !LineIntersectionCheck(points[0], points[1], points[2], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }
                        else
                            isSuccess = false;
                    }
                }
                else if (i == 4)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandom().X;
                        point.Y = random.GetRandom().Y;
                        if (!points.Contains(point)
                            && !LineIntersectionCheck(points[0], points[1], points[3], point) 
                            && !LineIntersectionCheck(points[1], points[2], points[3], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }
                        else
                            isSuccess = false;
                    }
                }
                else if (i == 5)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandom().X;
                        point.Y = random.GetRandom().Y;
                        if (!points.Contains(point) 
                            && !LineIntersectionCheck(points[0], points[1], points[4], point)
                            && !LineIntersectionCheck(points[1], points[2], points[4], point)
                            && !LineIntersectionCheck(points[2], points[3], points[4], point)
                            && !LineIntersectionCheck(points[1], points[2], points[0], point)
                            && !LineIntersectionCheck(points[2], points[3], points[0], point)
                            && !LineIntersectionCheck(points[3], points[4], points[0], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            isSuccess = true;
                        }

                        else
                            isSuccess = false;
                    }
                }
            }
            return points;
        }

        /// <summary>
        /// Checks segments for intersections
        /// </summary>
        /// <param name="firstPointFirstSegment">First point of first segment</param>
        /// <param name="secondPointFirstSegment">Second point of first segment</param>
        /// <param name="firstPointSecondSegment">First point of second segment</param>
        /// <param name="secondPointSecondSegment">Second point of second segment</param>
        /// <returns>Returns a value based on the presence of an intersection</returns>
        private bool LineIntersectionCheck(Point firstPointFirstSegment, Point secondPointFirstSegment, Point firstPointSecondSegment, Point secondPointSecondSegment)
        {
            if (secondPointFirstSegment.X < firstPointFirstSegment.X)
            {
                Point tmp = firstPointFirstSegment;
                firstPointFirstSegment = secondPointFirstSegment;
                secondPointFirstSegment = tmp;
            }
            if (secondPointSecondSegment.X < firstPointSecondSegment.X)
            {
                Point tmp = firstPointSecondSegment;
                firstPointSecondSegment = secondPointSecondSegment;
                secondPointSecondSegment = tmp;
            }
            if (secondPointFirstSegment.X < firstPointSecondSegment.X)
            {
                return false;
            }
            if ((firstPointFirstSegment.X - secondPointFirstSegment.X == 0) && (firstPointSecondSegment.X - secondPointSecondSegment.X == 0))
            {
                if (firstPointFirstSegment.X == firstPointSecondSegment.X)
                {
                    if (!((Math.Max(firstPointFirstSegment.Y, secondPointFirstSegment.Y) < Math.Min(firstPointSecondSegment.Y, secondPointSecondSegment.Y)) || (Math.Min(firstPointFirstSegment.Y, secondPointFirstSegment.Y) > Math.Max(firstPointSecondSegment.Y, secondPointSecondSegment.Y))))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (firstPointFirstSegment.X - secondPointFirstSegment.X == 0)
            {
                double firstPointFirstSegmentX = firstPointFirstSegment.X;
                double firstAFirstVertical = ((double)(firstPointSecondSegment.Y - secondPointSecondSegment.Y)) / (firstPointSecondSegment.X - secondPointSecondSegment.X);
                double secondBFirstVertical = firstPointSecondSegment.Y - (firstAFirstVertical * firstPointSecondSegment.X);
                double Ya = (firstAFirstVertical * firstPointFirstSegmentX) + secondBFirstVertical;
                if (firstPointSecondSegment.X <= firstPointFirstSegmentX && secondPointSecondSegment.X >= firstPointFirstSegmentX && Math.Min(firstPointFirstSegment.Y, secondPointFirstSegment.Y) <= Ya && Math.Max(firstPointFirstSegment.Y, secondPointFirstSegment.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            if (firstPointSecondSegment.X - secondPointSecondSegment.X == 0)
            {
                double firstPointSecondSegmentX = firstPointSecondSegment.X;
                double firstASecondVertical = ((double)(firstPointFirstSegment.Y - secondPointFirstSegment.Y)) / (firstPointFirstSegment.X - secondPointFirstSegment.X);
                double firstBSecondVertical = firstPointFirstSegment.Y - (firstASecondVertical * firstPointFirstSegment.X);
                double Ya = (firstASecondVertical * firstPointSecondSegmentX) + firstBSecondVertical;
                if (firstPointFirstSegment.X <= firstPointSecondSegmentX && secondPointFirstSegment.X >= firstPointSecondSegmentX
                    && Math.Min(firstPointSecondSegment.Y, secondPointSecondSegment.Y) <= Ya && Math.Max(firstPointSecondSegment.Y,
                    secondPointSecondSegment.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            double firstA = Math.Round(((double)(firstPointFirstSegment.Y - secondPointFirstSegment.Y)) / (firstPointFirstSegment.X - secondPointFirstSegment.X), 2);
            double secondA = Math.Round(((double)(firstPointSecondSegment.Y - secondPointSecondSegment.Y)) / (firstPointSecondSegment.X - secondPointSecondSegment.X), 2);
            double firstB = firstPointFirstSegment.Y - (firstA * firstPointFirstSegment.X);
            double secondB = firstPointSecondSegment.Y - (secondA * firstPointSecondSegment.X);
            if (firstA == secondA)
            {
                return false;
            }
            double Xa = ((double)(secondB - firstB)) / (firstA - secondA);
            if ((Xa < Math.Max(firstPointFirstSegment.X, firstPointSecondSegment.X)) || (Xa > Math.Min(secondPointFirstSegment.X, secondPointSecondSegment.X)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Compares two values
        /// </summary>
        /// <param name="obj">Compared value</param>
        /// <returns>Returns true, if values are the same and false if values are different</returns>
        public override bool Equals(object obj)
        {
            return obj is Hexagon hexagon &&
                   Id == hexagon.Id &&
                   EqualityComparer<Segment[]>.Default.Equals(Segments, hexagon.Segments);
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
            return String.Format($"Name: {nameof(Hexagon)}, Area: {GetArea(points)}, Perimeter: {GetPerimeter(points)}");
        }
    }
}
