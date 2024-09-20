using ShapesLibrary.Base;

namespace ShapesLibrary.Shapes
{
    public class Circle : ShapeBase
    {
        public double Radious { get; private set; }

        public Circle(int x, int y, double radious)
            : base(x, y)
        {
            Radious = radious;
        }

        public override double GetShapePerimeter()
        {
            return 2 * Constants.PI * Radious;
        }

        public override double GetShapeArea()
        {
            return Constants.PI * Radious * Radious;
        }
    }
}
