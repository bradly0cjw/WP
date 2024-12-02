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
            Assert.AreEqual("",model.GetCurrentMode());

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
            
        }

        [TestMethod()]
        public void GetCurrevtModeTest()
        {
            Model model = new Model();

            model.SetDrawState();
            Assert.AreEqual("Draw", model.GetCurrentMode());

            model.SetPointState();
            Assert.AreEqual("Point", model.GetCurrentMode());
        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {
            
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
           
        }

        [TestMethod()]
        public void PointerDownTest()
        {
            // Arrange
            var model = new Model();
            var x = 10;
            var y = 20;

            // Act
            model.PointerDown(x, y);

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

            // Assert
            // Add appropriate assertions based on the expected behavior of PointerUp
        }

        [TestMethod()]
        public void SetPointStateTest()
        {
            // Arrange
            var model = new Model();

            // Act
            model.SetPointState();

            // Assert
            // Add appropriate assertions based on the expected behavior of SetPointState
        }

        [TestMethod()]
        public void SetDrawStateTest()
        {
            // Arrange
            var model = new Model();

            // Act
            model.SetDrawState();

            // Assert
            // Add appropriate assertions based on the expected behavior of SetDrawState
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
           
        }

        [TestMethod()]
        public void GetShapesTest()
        {
           
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            
        }

        [TestMethod()]
        public void GetModeTest()
        {

        }

    }
}