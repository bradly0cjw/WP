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

        [TestMethod()]

        public void GetConnectionPointTest()
        {
            Shape shape = new Start("Start", "test", 0, 0, 0, 400, 200);
            Assert.AreEqual((-1,-1), shape.GetConnectionPoint(0));
            Assert.AreEqual((200, 0), shape.GetConnectionPoint(1));
            Assert.AreEqual((200, 200), shape.GetConnectionPoint(2));
            Assert.AreEqual((400, 100), shape.GetConnectionPoint(3));
            Assert.AreEqual((0, 100), shape.GetConnectionPoint(4));
        }

        [TestMethod()]
        public void IsClickConnectionPointTest()
        {
            Shape shape = new Start("Start", "test", 0, 0, 0, 400, 200);
            Assert.AreEqual(-1, shape.IsClickConnectionPoint(0, 0));
            Assert.AreEqual(1, shape.IsClickConnectionPoint(200, 0));
            Assert.AreEqual(2, shape.IsClickConnectionPoint(200, 200));
            Assert.AreEqual(3, shape.IsClickConnectionPoint(400, 100));
            Assert.AreEqual(4, shape.IsClickConnectionPoint(0, 100));
        }
    }
}