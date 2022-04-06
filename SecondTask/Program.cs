using System;

namespace SecondTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prints the results of method calls
        /// </summary>
        static void Main()
        {
            var hexagonPoints = Hexagon.GetRandomCoordinatesForHexagon();
            Hexagon hexagon = new Hexagon(hexagonPoints, 1);
            var newHexagon = hexagon.Clone();
            //Polygon hexagonPolygon = new Hexagon(hexagonPoints, 2);
            //GeometricFigure hexagonGeometricFigure = new Hexagon(hexagonPoints, 3);

            var trianglePoints = Triangle.GetRandomCoordinatesForTriangle();
            var trianglePoints2 = Triangle.GetRandomCoordinatesForTriangle();
            Polygon triangle = new Triangle(trianglePoints, 1);
            Polygon triangle2 = new Triangle(trianglePoints2, 1);
            var newTriangle = triangle == triangle2;
            Console.WriteLine("");

            Segment[] triangleSegments = new Segment[3];
            Polygon triangleExplicit = triangleSegments;
            Segment[] segmentsImplicit = (Segment[])triangleExplicit;
            Console.WriteLine("");

            Polygon firstPoly = new Polygon();
            for (int i = 0; i < hexagonPoints.Length - 1; i++)
            {
                firstPoly.Segments[i].FirstPoint = hexagonPoints[i];
                firstPoly.Segments[i].SecondPoint = hexagonPoints[i + 1];
            }
            Polygon secondPoly = new Polygon();
            for (int i = 0; i < hexagonPoints.Length - 1; i++)
            {
                secondPoly.Segments[i].FirstPoint = hexagonPoints[i];
                secondPoly.Segments[i].SecondPoint = hexagonPoints[i + 1];
            }



            //Polygon trianglePolygon = new Triangle(trianglePoints, 2);
            //GeometricFigure triangleGeometricFigure = new Triangle(trianglePoints, 3);

            //Console.WriteLine($"Hexagon type: Area: {hexagon.GetArea()}, Perimeter: {hexagon.GetPerimeter()}, GetHashCode: {hexagon.GetHashCode()}, Equals: {hexagon.Equals(hexagonPolygon)}");
            //Console.WriteLine($"Polygon Type: Area: {hexagonPolygon.GetArea()}, Perimeter: {hexagonPolygon.GetPerimeter()}, GetHashCode: {hexagonPolygon.GetHashCode()}, Equals: {hexagonPolygon.Equals(hexagon)}");
            //Console.WriteLine($"Geometric Figure Type: Area: {hexagonGeometricFigure.GetArea()}, Perimeter: {hexagonGeometricFigure.GetPerimeter()}, GetHashCode {hexagonGeometricFigure.GetHashCode()}, Equals: {hexagonGeometricFigure.Equals(hexagon)}");

            //var hexagonToString = hexagon.ToString();
            //var hexagonPolygonToString = hexagon.ToString();
            //var hexagonGeometricFiguraToString = hexagon.ToString();
            //Console.WriteLine($"ToString Hexagon: {hexagonToString}");
            //Console.WriteLine($"ToString Hexagon Polygon: {hexagonPolygonToString}");
            //Console.WriteLine($"ToString Hexagon Geometric Figure: {hexagonGeometricFiguraToString}");

            //Console.WriteLine("");
            //Console.WriteLine($"Triangle type: Area: {triangle.GetArea()}, Perimeter: {triangle.GetPerimeter()}, GetHashCode: {triangle.GetHashCode()}, Equals: {triangle.Equals(trianglePolygon)}");
            //Console.WriteLine($"Triangle Polygon Type: Area: {trianglePolygon.GetArea()}, Perimeter: {trianglePolygon.GetPerimeter()}, GetHashCode: {trianglePolygon.GetHashCode()}, Equals: {trianglePolygon.Equals(triangle)}");
            //Console.WriteLine($"Triangle GeometricFigure Type: Area: {triangleGeometricFigure.GetArea()}, Perimeter: {triangleGeometricFigure.GetPerimeter()}, GetHashCode: {triangleGeometricFigure.GetHashCode()}, Equals: {triangleGeometricFigure.Equals(triangle)}");

            var triangleToString = triangle.ToString();
            //var trianglePolygonToString = trianglePolygon.ToString();
            //var triangleGeometricFigureToString = triangleGeometricFigure.ToString();
            Console.WriteLine($"ToString triangle type: {triangleToString}");
            //Console.WriteLine($"ToString triangle Polygon type: {trianglePolygonToString}");
            //Console.WriteLine($"ToString triangle GeometricFigure type: {triangleGeometricFigureToString}");
        }
    }
}
