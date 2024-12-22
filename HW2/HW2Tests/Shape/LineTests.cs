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
    public class LineTests
    {
        [TestMethod()]
        public void LineTest()
        {
            Shape shape = new Line("Line", "", 1, 0, 0, 300, 400);
            Assert.AreEqual("Line", shape.ShapeName);
            Assert.AreEqual("", shape.Text);
            Assert.AreEqual(1, shape.ID);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
            Assert.AreEqual(300, shape.W);
            Assert.AreEqual(400, shape.H);
        }

        [TestMethod()]
        public void DrawTest()
        {
            Shape shape1 = new Start("Start", "test", 0, 100, 200, 300, 400);
            Shape shape2 = new Start("Start", "test", 0, 100, 200, 300, 400);
            Line line = new Line("Line", "test", 0, 100, 200, 300, 400);
            IGraphic mockGraphic = new MockGraphic();
            line.SetConnection1(shape1, 0);
            line.Draw(mockGraphic);
            line.SetConnection2(shape2, 0);
            line.Draw(mockGraphic);
        }

        [TestMethod()]
        public void IsClickInShapeTest()
        {
            Shape shape = new Line("Line", "test", 0, 100, 200, 300, 400);
            Assert.IsFalse(shape.IsClickInShape(0, 0));
        }
        [TestMethod()]
        public void SetConnection2Test()
        {

            Shape shape1 = new Start("Start", "test", 0, 100, 200, 300, 400);
            Line line = new Line("Line", "test", 0, 100, 200, 300, 400);
            line.SetConnection1(shape1, 0);
            Assert.AreEqual(shape1, line.Shape1);
            Assert.AreEqual(0, line.Connection1);

        }

        [TestMethod()]
        public void SetConnection1Test()
        {
            Shape shape2 = new Start("Start", "test", 0, 100, 200, 300, 400);
            Line line = new Line("Line", "test", 0, 100, 200, 300, 400);
            line.SetConnection2(shape2, 0);
            Assert.AreEqual(shape2, line.Shape2);
            Assert.AreEqual(0, line.Connection2);
        }

    }
}