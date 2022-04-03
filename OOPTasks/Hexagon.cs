using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    public class Hexagon : Polygon
    {
        private Random random = new Random();
        public override double GetArea(Point[] points)
        {
            int[,] coordinates = new int[2, points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                coordinates[0, i] = points[i].X;
                coordinates[1, i] = points[i].Y;
            }
            int x1, x2, x3, y1, y2, y3;
            double p, a, b, c, s = 0;
            x1 = coordinates[0, 0];
            y1 = coordinates[1, 0];
            for (int i = 1; i < coordinates.GetLength(1) - 1; i++)
            {
                x2 = coordinates[0, i];
                y2 = coordinates[1, i];
                x3 = coordinates[0, i + 1];
                y3 = coordinates[1, i + 1];
                a = Math.Sqrt(((x3 - x2) * (x3 - x2)) + ((y3 - y2) * (y3 - y2)));
                b = Math.Sqrt(((x3 - x1) * (x3 - x1)) + ((y3 - y1) * (y3 - y1)));
                c = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                p = (a + b + c) / 2;
                s += Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return s;
        }
        public Point[] GetRandomCoordinatesForHexagon()
        {
            Point[] points = new Point[6];
            for (int i = 0; i < points.Length; i++)
            {
                if (i < 3)
                {
                    points[i].X = random.GetRandom().X;
                    points[i].Y = random.GetRandom().Y;
                    Console.WriteLine($"{points[i].X}, {points[i].Y}");
                }
                else if (i == 3)
                {
                    Point point = new Point();
                    var isSuccess = false;
                    while (!isSuccess)
                    {
                        point.X = random.GetRandom().X;
                        point.Y = random.GetRandom().Y;
                        isSuccess = checkIntersectionOfTwoLineSegments(points[0], points[1], points[2], point);
                        if (!isSuccess && !points.Contains(point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            Console.WriteLine($"{points[i].X}, {points[i].Y}");
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
                        isSuccess = checkIntersectionOfTwoLineSegments(points[0], points[1], points[3], point);
                        if (!isSuccess && !checkIntersectionOfTwoLineSegments(points[1], points[2], points[3], point) && !points.Contains(point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            Console.WriteLine($"{points[i].X}, {points[i].Y}");
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
                        isSuccess = checkIntersectionOfTwoLineSegments(points[0], points[1], points[4], point);
                        if (!points.Contains(point) && !isSuccess
                            && !checkIntersectionOfTwoLineSegments(points[1], points[2], points[4], point)
                            && !checkIntersectionOfTwoLineSegments(points[2], points[3], points[4], point)
                            && !checkIntersectionOfTwoLineSegments(points[1], points[2], points[0], point)
                              && !checkIntersectionOfTwoLineSegments(points[2], points[3], points[0], point)
                              && !checkIntersectionOfTwoLineSegments(points[3], points[4], points[0], point))
                        {
                            points[i].X = point.X;
                            points[i].Y = point.Y;
                            Console.WriteLine($"{points[i].X}, {points[i].Y}");
                            isSuccess = true;
                        }

                        else
                            isSuccess = false;
                    }
                }
            }
            return points;
        }

        //метод, проверяющий пересекаются ли 2 отрезка [p1, p2] и [p3, p4]
        private bool checkIntersectionOfTwoLineSegments(Point firstPointFirstSegment, Point secondPointFirstSegment, Point firstPointSecondSegment, Point secondPointSecondSegment)
        {
            //сначала расставим точки по порядку, т.е. чтобы было p1.x <= p2.x
            if (secondPointFirstSegment.X < firstPointFirstSegment.Y)
            {
                Point tmp = firstPointFirstSegment;
                firstPointFirstSegment = secondPointFirstSegment;
                secondPointFirstSegment = tmp;
            }
            //и p3.x <= p4.x
            if (secondPointSecondSegment.X < firstPointSecondSegment.X)
            {
                Point tmp = firstPointSecondSegment;
                firstPointSecondSegment = secondPointSecondSegment;
                secondPointSecondSegment = tmp;
            }
            //проверим существование потенциального интервала для точки пересечения отрезков
            if (secondPointFirstSegment.X < firstPointSecondSegment.X)
            {
                return false; //ибо у отрезков нету взаимной абсциссы
            }
            //если оба отрезка вертикальные
            if ((firstPointFirstSegment.X - secondPointFirstSegment.X == 0) && (firstPointSecondSegment.X - secondPointSecondSegment.X == 0))
            {
                //если они лежат на одном X
                if (firstPointFirstSegment.X == firstPointSecondSegment.X)
                {
                    //проверим пересекаются ли они, т.е. есть ли у них общий Y
                    //для этого возьмём отрицание от случая, когда они НЕ пересекаются
                    if (!((Math.Max(firstPointFirstSegment.Y, secondPointFirstSegment.Y) < Math.Min(firstPointSecondSegment.Y, secondPointSecondSegment.Y)) || (Math.Min(firstPointFirstSegment.Y, secondPointFirstSegment.Y) > Math.Max(firstPointSecondSegment.Y, secondPointSecondSegment.Y))))
                    {
                        return true;
                    }
                }
                return false;
            }
            //найдём коэффициенты уравнений, содержащих отрезки
            //f1(x) = A1*x + b1 = y
            //f2(x) = A2*x + b2 = y

            //если первый отрезок вертикальный
            if (firstPointFirstSegment.X - secondPointFirstSegment.X == 0)
            {
                //найдём Xa, Ya - точки пересечения двух прямых
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
            //если второй отрезок вертикальный
            if (firstPointSecondSegment.X - secondPointSecondSegment.X == 0)
            {
                //найдём Xa, Ya - точки пересечения двух прямых
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
            //оба отрезка невертикальные
            double firstA = Math.Round(((double)(firstPointFirstSegment.Y - secondPointFirstSegment.Y)) / (firstPointFirstSegment.X - secondPointFirstSegment.X), 2);
            double secondA = Math.Round(((double)(firstPointSecondSegment.Y - secondPointSecondSegment.Y)) / (firstPointSecondSegment.X - secondPointSecondSegment.X), 2);
            double firstB = firstPointFirstSegment.Y - (firstA * firstPointFirstSegment.X);
            double secondB = firstPointSecondSegment.Y - (secondA * firstPointSecondSegment.X);
            if (firstA == secondA)
            {
                return false; //отрезки параллельны
            }
            //Xa - абсцисса точки пересечения двух прямых
            double Xa = ((double)(secondB - firstB)) / (firstA - secondA);
            if ((Xa < Math.Max(firstPointFirstSegment.X, firstPointSecondSegment.X)) || (Xa > Math.Min(secondPointFirstSegment.X, secondPointSecondSegment.X)))
            {
                return false; //точка Xa находится вне пересечения проекций отрезков на ось X 
            }
            else
            {
                return true;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Hexagon hexagon &&
                   Id == hexagon.Id &&
                   EqualityComparer<Segment[]>.Default.Equals(Segment, hexagon.Segment);
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
