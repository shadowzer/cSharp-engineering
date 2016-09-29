using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cSharp_engineering;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no triangle with these sides.")]
        public void CreateTriangleObjectFrom3IncorrectSidesThrowsException()
        {
            cSharp_engineering.Triangle Triangle = cSharp_engineering.Triangle.CreateTriangleFrom3Sides(1, 1, 10);
        }

        [TestMethod]
        public void CreateTriangleFrom3SidesReturnTriangleArea()
        {
            cSharp_engineering.Triangle Triangle = cSharp_engineering.Triangle.CreateTriangleFrom3Sides(3, 4, 5);

            Assert.AreEqual(6, Triangle.GetTriangleArea());
        }



        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no triangle with these sides and angle.")]
        public void CreateTriangleObjectFrom2SidesAndIncorrectAngleThrowsException()
        {
            cSharp_engineering.Triangle Triangle = cSharp_engineering.Triangle.CreateTriangleFrom2SidesAndAngle(1, 1, 190);
        }

        [TestMethod]
        public void CreateTriangleFrom2SidesAndAngleReturnTriangleArea()
        {
            cSharp_engineering.Triangle Triangle = cSharp_engineering.Triangle.CreateTriangleFrom2SidesAndAngle(3, 4, 90);

            Assert.AreEqual(6, Triangle.GetTriangleArea());
        }



        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no triangle with these angles and side.")]
        public void CreateTriangleObjectFromSideAnd2IncorrectAnglesThrowsException()
        {
            cSharp_engineering.Triangle Triangle = cSharp_engineering.Triangle.CreateTriangleFromSideAnd2Angles(1, 90, 90);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no side in the triangle like that.")]
        public void CalcSideFrom2SidesAndIncorrectAngleThrowsException()
        {
            cSharp_engineering.Triangle.CalcSideFrom2SidesAndAngle(3, 4, -30);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There is no side in the triangle with these angles and side.")]
        public void CalcSideFromIncorrectSideAnd2AnglesThrowsException()
        {
            cSharp_engineering.Triangle.CalcSideFromSideAnd2Angles(-2, 30, 60);
        }
    }
}
