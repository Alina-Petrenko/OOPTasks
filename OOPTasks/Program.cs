using System;

namespace FirstTask
{
    public class Program
    {
        static void Main()
        {
            Hexagon hexagon = new Hexagon();
            Point [] points = hexagon.GetRandomCoordinatesForHexagon();
            var area = hexagon.GetArea(points);
            Console.WriteLine($"{area}");
            Console.WriteLine("");
        }
    }
}
