using System;

namespace FirstTask
{
    public class Program
    {
        static void Main()
        {
            var hexagonPoints = Hexagon.GetRandomCoordinatesForHexagon();
            Hexagon hexagon = new Hexagon(hexagonPoints);


            GeometricFigure hexagonGeometricFigure = new Hexagon();
            Polygon hexagonPolygon = new Hexagon();
            Segment[] triangleSegments = new Segment[3];

            Triangle triangleExplicit = triangleSegments;
            Segment[] segmentsImplicit = (Segment[])triangleExplicit;

            foreach (var triangle in triangleSegments)
            {
                
            }
            Triangle triangle = new Triangle();
            Polygon trianglePolygon = new Triangle();
            GeometricFigure triangleGeometricFigure = new Triangle();

            Point[] trianglePoints = triangle.GetRandomCoordinatesForTriangle();
            Point[] hexagonPoints = hexagon.GetRandomCoordinatesForHexagon();
            
            Console.WriteLine($"Hexagon type: Area: {hexagon.GetArea(hexagonPoints)}, Perimeter: {hexagon.GetPerimeter(hexagonPoints)}, GetHashCode: {hexagon.GetHashCode()}, Equals: {hexagon.Equals(hexagonPolygon)}");
            Console.WriteLine($"Polygon Type: Area: {hexagonPolygon.GetArea(hexagonPoints)}, Perimeter: {hexagonPolygon.GetPerimeter(hexagonPoints)}, GetHashCode: {hexagonPolygon.GetHashCode()}, Equals: {hexagonPolygon.Equals(hexagon)}");
            Console.WriteLine($"Geometric Figure Type: Area: {hexagonGeometricFigure.GetArea(hexagonPoints)}, Perimeter: {hexagonGeometricFigure.GetPerimeter(hexagonPoints)}, GetHashCode {hexagonGeometricFigure.GetHashCode()}, Equals: {hexagonGeometricFigure.Equals(hexagon)}");

            var hexagonToString = hexagon.ToString();
            var hexagonPolygonToString = hexagon.ToString();
            var hexagonGeometricFiguraToString = hexagon.ToString();
            Console.WriteLine($"ToString Hexagon: {hexagonToString}");
            Console.WriteLine($"ToString Hexagon Polygon: {hexagonPolygonToString}");
            Console.WriteLine($"ToString Hexagon Geometric Figure: {hexagonGeometricFiguraToString}");
            
            Console.WriteLine("");                   
            Console.WriteLine($"Triangle type: Area: {triangle.GetArea(trianglePoints)}, Perimeter: {triangle.GetPerimeter(trianglePoints)}, GetHashCode: {triangle.GetHashCode()}, Equals: {triangle.Equals(trianglePolygon)}");
            Console.WriteLine($"Triangle Polygon Type: Area: {trianglePolygon.GetArea(trianglePoints)}, Perimeter: {trianglePolygon.GetPerimeter(trianglePoints)}, GetHashCode: {trianglePolygon.GetHashCode()}, Equals: {trianglePolygon.Equals(triangle)}");
            Console.WriteLine($"Triangle GeometricFigure Type: Area: {triangleGeometricFigure.GetArea(trianglePoints)}, Perimeter: {triangleGeometricFigure.GetPerimeter(trianglePoints)}, GetHashCode: {triangleGeometricFigure.GetHashCode()}, Equals: {triangleGeometricFigure.Equals(triangle)}");
            
            var triangleToString = triangle.ToString();
            //var trianglePolygonToString = trianglePolygon.ToString();
            var triangleGeometricFigureToString = triangleGeometricFigure.ToString();
            Console.WriteLine($"ToString triangle type: {triangleToString}");          
            //Console.WriteLine($"ToString triangle Polygon type: {trianglePolygonToString}");
            Console.WriteLine($"ToString triangle GeometricFigure type: {triangleGeometricFigureToString}");
        }
    }
}
