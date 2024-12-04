using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        [TestMethod()]
        public void CreateShapeTest()
        {
            Shape shape1 = ShapeFactory.CreateShape("start", "aaa", 0, 0, 0, 100, 200);
            Assert.AreEqual(0, shape1.ID);

            Shape shape2 = ShapeFactory.CreateShape("aaa", "bbb", 0, 0, 0, 100, 200);

            Assert.AreEqual(null, shape2);
        }
    }
}