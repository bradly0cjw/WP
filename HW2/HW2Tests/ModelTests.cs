using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HW2Tests;

namespace HW2.Tests
{
    [TestClass()]
    public class ModelTests
    {
        public Model model= new Model();

        //[TestMethod()]
        //public void ModelTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddShapeTest()
        {
            

            model.AddShape("start","aaa",0,0,100,200);

            var shape = model.GetShapes();
            Assert.AreEqual(1, shape.Count);
            Assert.AreEqual("",model.GetMode());

            model.AddShape("Terminator","bbb",0,0,100,200);

            shape = model.GetShapes();
            Assert.AreEqual(2, shape.Count);

            model.AddShape("Process", "ccc", 0, 0, 100, 200);

            shape = model.GetShapes();
            Assert.AreEqual(3, shape.Count);

            model.AddShape("Decision", "ddd", 0, 0, 100, 200);

            shape = model.GetShapes();
            Assert.AreEqual(4, shape.Count);

        }


        [TestMethod()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCurrentStateTest()
        {
            model.SetDrawState();
            Assert.AreEqual("",model.GetCurrentState());

            model.SetPointState();
            Assert.AreEqual("", model.GetCurrentState());
        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PointerDownTest()
        {
            // Arrange
            IState mockstate = new MockState();
            model._currentState = mockstate;
            var x = 10;
            var y = 20;

            // Act
            model.PointerDown(x, y);
            Assert.Fail();
            // Assert
            // Add appropriate assertions based on the expected behavior of PointerDown
        }

        [TestMethod()]
        public void PointerMoveTest()
        {
            // Arrange
            var model = new Model();
            var x = 10;
            var y = 20;

            // Act
            model.PointerMove(x, y);
            Assert.Fail();
            // Assert
            // Add appropriate assertions based on the expected behavior of PointerMove
        }

        [TestMethod()]
        public void PointerUpTest()
        {
            // Arrange
            var model = new Model();
            var x = 10;
            var y = 20;

            // Act
            model.PointerUp(x, y);
            Assert.Fail();
            // Assert
            // Add appropriate assertions based on the expected behavior of PointerUp
        }

        [TestMethod()]
        public void SetPointStateTest()
        {

            // Act
            model.SetPointState();
            Assert.Fail();
            // Assert

        }

        [TestMethod()]
        public void SetDrawStateTest()
        {
            // Arrange
            var model = new Model();

            // Act
            model.SetDrawState();
            Assert.Fail();
            // Assert
            // Add appropriate assertions based on the expected behavior of SetDrawState
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            model.AddShape("start", "aaa", 0, 0, 100, 200);
            model.AddShape("Terminator", "bbb", 0, 0, 100, 200);
            model.AddShape("Process", "ccc", 0, 0, 100, 200);
            model.RemoveShape(2);
            var shape = model.GetShapes();
            Assert.AreEqual(2, shape.Count);
        }

        [TestMethod()]
        public void GetShapesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetModeTest()
        {
            Assert.Fail();
        }

    }
}