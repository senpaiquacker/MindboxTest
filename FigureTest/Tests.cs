using NUnit.Framework;
using Figure;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FigureTest
{
    public class Tests
    {

        [Test]
        [Order(00)]
        public void CircleCreation()
        {
            var expectedRadius = 1f;
            var actualCircle = new Circle(1f);
            Assert.AreEqual(1f, actualCircle.Radius);
        }

        [Test]
        [Order(01)]
        public void CircleExceptions([Values(-1f, 0f)]float radius)
        {
            Assert.Throws<Exception>(() => new Circle(radius));
        }

        [Test]
        [Order(02)]
        public void AreaUniRadiusCircle([Values(1f)]float radius)
        {

            Assert.AreEqual((float)Math.PI, new Circle(radius).Area, float.Epsilon);
        }

        [Test]
        [Order(10)]
        public void TriangleCreation()
        {
            (float a, float b, float c) expectedSides = (1f, 1f, 1f);
            var actualTriangle = new Triangle(1f, 1f, 1f);
            Assert.AreEqual(expectedSides.a, actualTriangle.Sides.a);
            Assert.AreEqual(expectedSides.b, actualTriangle.Sides.b);
            Assert.AreEqual(expectedSides.c, actualTriangle.Sides.c);
        }


        [Test]
        [TestCaseSource(nameof(sideCasesWithErrors))]
        [Order(11)]
        public void TriangleExceptions((float a, float b, float c) sides)
        {
            Assert.Throws<Exception>(() => new Triangle(sides.a, sides.b, sides.c));
        }
        private static IEnumerable<(float a, float b, float c)> sideCasesWithErrors
        {
            get
            {
                yield return (1f, 0f, 1f);
                yield return (-1f, 1f, 1f);
                yield return (1f, 2f, -0.5f);
                yield return (1f, 2f, 3f);
            }
        }


        [Test]
        [Order(12)]
        public void TriangleArea()
        {
            CollectionAssert
                .AreEqual(resultsSuccessful.Select(a => a.Item1),
                sideCasesSuccessful
                    .Select(
                    s => (float)Math.Round(new Triangle(s.a, s.b, s.c).Area,4)));
        }
        [Test]
        [Order(13)]
        public void TriangleRight()
        {
            CollectionAssert
                .AreEqual(resultsSuccessful.Select(a => a.Item2),
                sideCasesSuccessful
                    .Select(
                    s => new Triangle(s.a, s.b, s.c).IsTriangleRight()));
        }
        private static IEnumerable<(float, bool)> resultsSuccessful
        {
            get
            {
                yield return (6f, true);
                yield return (0.4330f, false);
                yield return (14.9812f, false);
                yield return (6f, true);
            }
        }
        private static IEnumerable<(float a, float b, float c)> sideCasesSuccessful
        {
            get
            {
                yield return (3f, 4f, 5f);
                yield return (1f, 1f, 1f);
                yield return (6f, 5f, 8f);
                yield return (4f, 3f, 5f);
            }
        }
    }
}