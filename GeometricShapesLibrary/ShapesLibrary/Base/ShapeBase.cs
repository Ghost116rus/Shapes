namespace ShapesLibrary.Base
{
    public abstract class ShapeBase
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ShapeBase(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract double GetShapePerimeter();
        public abstract double GetShapeArea();
    }
}
