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
        //[TestMethod()]
        //public void ModelTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddShapeTest()
        {
            // Arrange
            var shapeName = "start";
            var text = "Start Shape";
            var id = 1;
            var x = 10;
            var y = 20;
            var width = 100;
            var height = 50;

            // Act
            var shape = ShapeFactory.CreateShape(shapeName, text, id, x, y, width, height);

            // Assert
            Assert.IsNotNull(shape);
            Assert.AreEqual(shapeName, shape.ShapeName);
            Assert.AreEqual(text, shape.Text);
            Assert.AreEqual(id, shape.ID);
            Assert.AreEqual(x, shape.X);
            Assert.AreEqual(y, shape.Y);
            Assert.AreEqual(width, shape.W);
            Assert.AreEqual(height, shape.H);
        }

        [TestMethod()]
        public void DrawTest()
        {
            // Arrange
            var graphicMock = new Mock<IGraphic>();
            var model = new Model();
            var shape = new Mock<Shape>("start", "Start Shape", 1, 10, 20, 100, 50);
            model.AddShape(shape.Object);

            // Act
            model.Draw(graphicMock.Object);

            // Assert
            shape.Verify(s => s.Draw(graphicMock.Object), Times.Once);
        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {
            // Arrange
            var model = new Model();

            // Act
            model.SetDrawingMode();

            // Assert
            Assert.AreEqual(Model.Mode.Drawing, model.GetMode());
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            // Arrange
            var model = new Model();

            // Act
            model.SetSelectMode();

            // Assert
            Assert.AreEqual(Model.Mode.Select, model.GetMode());
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
            // Arrange
            var model = new Model();
            var shape = new Mock<Shape>("start", "Start Shape", 1, 10, 20, 100, 50);
            model.AddShape(shape.Object);

            // Act
            model.RemoveShape(shape.Object);

            // Assert
            Assert.IsFalse(model.GetShapes().Contains(shape.Object));
        }

        [TestMethod()]
        public void GetShapesTest()
        {
            // Arrange
            var model = new Model();
            var shape = new Mock<Shape>("start", "Start Shape", 1, 10, 20, 100, 50);
            model.AddShape(shape.Object);

            // Act
            var shapes = model.GetShapes();

            // Assert
            Assert.IsTrue(shapes.Contains(shape.Object));
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            // Arrange
            var model = new Model();
            var observerMock = new Mock<IObserver>();
            model.AddObserver(observerMock.Object);

            // Act
            model.NotifyObserver();

            // Assert
            observerMock.Verify(o => o.Update(), Times.Once);
        }

        [TestMethod()]
        public void GetModeTest()
        {
            // Arrange
            var model = new Model();

            // Act
            var mode = model.GetMode();

            // Assert
            Assert.AreEqual(Model.Mode.Select, mode); // Assuming default mode is Select
        }

    }
}