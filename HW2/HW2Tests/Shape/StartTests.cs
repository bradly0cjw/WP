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
    public class StartTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Shape shape = new Start("Start", "test", 0, 100, 200, 300, 400);
            Assert.AreEqual("Start", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(0, shape.ID);
            Assert.AreEqual(100, shape.X);
            Assert.AreEqual(200, shape.Y);
            Assert.AreEqual(300, shape.W);
            Assert.AreEqual(400, shape.H);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            Shape shape = new Start("Start", "test", 0, 100, 200, 300, 400);
            shape.Draw(mockGraphic);
            shape = new Start("Start", "test", 0, 100, 200, -300, -400);
            shape.Draw(mockGraphic);
        }

        [TestMethod()]
        public void IsClickInShapeTest()
        {
            Shape shape = new Start("Start", "test", 0, 100, 200, 300, 400);
            Assert.IsTrue(shape.IsClickInShape(200, 300));
            Assert.IsFalse(shape.IsClickInShape(0, 0));
        }
        [TestMethod()]
        public void IsClickOnTextTest()
        {
            Shape shape = new Process("Process", "test", 0, 100, 200, 300, 400);
            Assert.IsTrue(shape.IsClickOnText(281, 401));
            Assert.IsFalse(shape.IsClickOnText(200, 300));
        }
    }
}