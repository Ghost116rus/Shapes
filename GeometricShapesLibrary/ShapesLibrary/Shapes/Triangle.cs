using ShapesLibrary.Base;
using ShapesLibrary.Base.Interfaces;

namespace ShapesLibrary.Shapes
{
    public class Triangle : ShapeWithSides, IRectangular
    {
        private bool _isRectangular = false;

        public Triangle(int x, int y, List<double> sides)
            : base(x, y, 3)
        {
            SetSides(sides);
        }

        public override void SetSides(List<double> sides)
        {
            base.SetSides(sides);
            CheckIsRectangular();
        }

        public override double GetShapeArea()
        {
            var p = GetShapePerimeter() / 2;
            var a = _sides[0];
            var b = _sides[1];
            var c = _sides[2];

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool IsRectangular() => _isRectangular;

        protected virtual void CheckIsRectangular()
        {
            var a = Math.Pow(_sides[0], 2);
            var b = Math.Pow(_sides[1], 2);
            var c = Math.Pow(_sides[2], 2);

            var firstHypotese = Math.Abs(c - a - b) < Constants.Precision;
            var secondHypotese = firstHypotese ? false : Math.Abs(a - c - b) < Constants.Precision;
            var thirdHypotese = firstHypotese || secondHypotese
                ? false : Math.Abs(b - c - a) < Constants.Precision;

            _isRectangular = firstHypotese || secondHypotese || thirdHypotese;
        }
    }
}
