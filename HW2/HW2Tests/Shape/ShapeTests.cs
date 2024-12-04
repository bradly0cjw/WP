using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2Tests;

namespace HW2.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        [TestMethod()]
        public void DrawBoundingTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            Shape shape = new Start("Start", "test", 0, 100, 200, 300, 400);
            shape.DrawBounding(mockGraphic);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Shape shape = new Start("Start", "test", 0, 0, 0, -300, -400);
            shape.Normalize();
            Assert.AreEqual(-300, shape.X);
            Assert.AreEqual(-400, shape.Y);
            Assert.AreEqual(300, shape.W);
            Assert.AreEqual(400, shape.H);

            Shape shape2 = new Start("Start", "test", 0, 0, 0, 300, 400);
            shape2.Normalize();
            Assert.AreEqual(0, shape2.X);
            Assert.AreEqual(0, shape2.Y);
            Assert.AreEqual(300, shape2.W);
            Assert.AreEqual(400, shape2.H);


        }
    }
}