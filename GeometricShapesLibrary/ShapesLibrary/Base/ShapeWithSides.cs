namespace ShapesLibrary.Base
{
    public abstract class ShapeWithSides : ShapeBase
    {
        private double _shapePerimeter;
        protected readonly double[] _sides;
        public IReadOnlyList<double> Sides { get => _sides; }
        public ShapeWithSides(int x, int y, int countOfSides) : base(x, y)
        {
            _shapePerimeter = 0;
            _sides = new double[countOfSides];
        }

        public virtual void SetSides(List<double> sides)
        {
            if (sides == null)
                throw new ArgumentNullException(nameof(sides));
            if (sides.Count != _sides.Length)
                throw new ArgumentOutOfRangeException(nameof(sides), sides.Count, $"List must be have {_sides.Length} values");

            int index = 0;
            foreach (var side in sides)
            {
                if (side <= 0)
                    throw new ArgumentOutOfRangeException(nameof(side), side, "Parameter must be non-negative.");
                _sides[index++] = side;
                _shapePerimeter += side;
            }
        }

        public override double GetShapePerimeter() => _shapePerimeter;
    }
}
