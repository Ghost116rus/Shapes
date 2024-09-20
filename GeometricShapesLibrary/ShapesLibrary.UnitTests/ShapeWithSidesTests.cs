using NUnit.Framework;
using NUnit.Framework.Legacy;
using ShapesLibrary.Base;

namespace ShapesLibrary.UnitTests
{
    [TestFixture]
    public class ShapeWithSidesTests
    {
        [TestCaseSource(nameof(SetSidesThrowOutOfRangetValues))]
        public void SetSidesThrowOutOfRange(IEnumerable<double> sides, int countOfSides)
        {
            var shape = new ShapeWithSidesMock(0, 0, countOfSides);

            var ex = Assert.Catch<ArgumentOutOfRangeException>(() => shape.SetSides(sides as List<double>));

            StringAssert.Contains($"List must be have {countOfSides} values", ex.Message);
        }

        [Test]
        public void SetSidesThrowOutOfRangeByNegativeSide()
        {
            var shape = new ShapeWithSidesMock(0, 0, 3);

            var ex = Assert.Catch<ArgumentOutOfRangeException>(() => shape.SetSides(new() { 1, -5, 6}));

            StringAssert.Contains($"Parameter must be non-negative.", ex.Message);
        }


        [TestCase(15, 16, 10)]
        [TestCase(5, 13, 22)]
        public void GetShapePerimeterTest(double firstSide, double secondSide, double thirdSide)
        {
            var expected = firstSide + secondSide + thirdSide;
            var shape = new ShapeWithSidesMock(0, 0, 3);
            shape.SetSides(new() { firstSide, secondSide, thirdSide });

            var shapePerimeter = shape.GetShapePerimeter();

            ClassicAssert.AreEqual(expected, shapePerimeter,
                $"Shape perimeter {shapePerimeter} should be {expected}");
        }

        private static IEnumerable<object[]> SetSidesThrowOutOfRangetValues => new[]
        {
            new object[]{new List<double>{ 3, 4, 5 }, 2},
            new object[]{new List<double>{ 8, 3, 5, 6}, 5},
        };
    }


    internal class ShapeWithSidesMock : ShapeWithSides
    {
        public ShapeWithSidesMock(int x, int y, int countOfSides) : base(x, y, countOfSides)
        {
        }

        public override double GetShapeArea()
        {
            throw new NotImplementedException();
        }
    }
}
