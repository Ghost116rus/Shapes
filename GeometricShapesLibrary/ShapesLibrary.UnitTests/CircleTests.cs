using NUnit.Framework;
using ShapesLibrary.Shapes;

namespace ShapesLibrary.UnitTests
{
    [TestFixture()]
    public class CircleTests
    {
        [TestCase(15, 94.2477796, 0.000001)]
        [TestCase(25, 157.0796326, 0.000001)]
        public void GetShapePerimeterTest(double radious, double expected, double precision)
        {
            var circle = new Circle(0, 0, radious);

            var circlePerimeter = circle.GetShapePerimeter();

            Assert.That(Math.Abs(circlePerimeter - expected), Is.LessThan(precision));
        }

        [TestCase(15, 706.8583470, 0.000001)]
        [TestCase(25, 1963.4954084, 0.000001)]
        public void GetShapeAreaTest(double radious, double expected, double precision)
        {
            var circle = new Circle(0, 0, radious);

            var circleArea = circle.GetShapeArea();

            Assert.That(Math.Abs(circleArea - expected), Is.LessThan(precision));

        }
    }
}
