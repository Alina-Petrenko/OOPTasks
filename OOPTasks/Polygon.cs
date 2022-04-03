namespace FirstTask
{
    public abstract class Polygon: GeometricFigure
    {
        public abstract override double GetArea(Point[]points);

        public new void GetPerimetr()
        {
            var perimetr = 0d;
            for (int i = 0; i < Segment.Length; i++)
            {
                perimetr += Segment[i].GetLength();
            }
        }
    }
}
