using NUnit.Framework;
using NUnit.Framework.Legacy;
using ShapesLibrary.Shapes;

namespace ShapesLibrary.UnitTests
{
    [TestFixture()]
    public class TriangleTests
    {
        [TestCase(3, 4, 5, 6)]
        public void GetShapeAreaTest(double firstSide, double secondSide, double thirdSide, double expected)
        {
            Triangle triangle = new Triangle(0, 0, new() { firstSide, secondSide, thirdSide });

            double triangleArea = triangle.GetShapeArea();

            ClassicAssert.AreEqual(expected, triangleArea,
                $"Triangle area {triangleArea} should be {expected}");
        }

        [TestCaseSource(nameof(IsRectangularTestValues))]
        public void IsRectangularTest(IEnumerable<double> sides, bool expected)
        {
            Triangle triangle = new Triangle(0, 0, sides as List<double>);

            var triangleIsReactangular = triangle.IsRectangular();

            Assert.That(expected == triangleIsReactangular);
        }

        [Test]
        public void GetShapePerimeterTest()
        {
            var expected = 15 + 26 + 33;
            var triangle = new Triangle(0, 0, new() { 15, 26, 33 });

            var trinalgePerimeter = triangle.GetShapePerimeter();

            ClassicAssert.AreEqual(expected, trinalgePerimeter,
                $"Triangle perimeter {trinalgePerimeter} should be {expected}");
        }


        private static IEnumerable<object[]> IsRectangularTestValues => new[]
        {
            new object[]{new List<double>{ 3, 4, 5 }, true},
            new object[]{new List<double>{ 8, 3, 5}, false},
            new object[]{new List<double>{ 89, 21, 90.99999999999999 }, false}
        };



    }
}
