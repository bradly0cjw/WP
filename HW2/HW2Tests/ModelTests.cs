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
        public Model model = new Model();


        [TestMethod()]
        public void AddShapeTest()
        {


            model.AddShape("start", "aaa", 0, 0, 100, 200);

            var shape = model.GetShapes();
            Assert.AreEqual(1, shape.Count);
            Assert.AreEqual("", model.GetMode());

            model.AddShape("Terminator", "bbb", 0, 0, 100, 200);

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
            IState mockstate = new MockState();
            mockstate.Initialize(model);
            model.CurrentState = mockstate;
            IGraphic mockGraphic = new MockGraphic();

            model.Draw(mockGraphic);

            MockState state = (MockState)model.CurrentState;

            Assert.IsTrue(state.isDrawCalled);


        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {
            model.SetDrawingMode("Start");
            Assert.AreEqual("Start", model.GetMode());

        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            model.SetSelectMode();
            Assert.AreEqual("", model.GetMode());
        }

        [TestMethod()]
        public void PointerDownTest()
        {
            // Arrange
            IState mockstate = new MockState();
            model.CurrentState = mockstate;
            mockstate.Initialize(model);
            var x = 10;
            var y = 20;

            // Act
            model.PointerDown(x, y);
            MockState state = (MockState)model.CurrentState;

            Assert.AreEqual(x, state.mouseDownX);
            Assert.AreEqual(y, state.mouseDownY);

        }

        [TestMethod()]
        public void PointerMoveTest()
        {
            // Arrange
            IState mockstate = new MockState();
            model.CurrentState = mockstate;
            mockstate.Initialize(model);
            var x = 10;
            var y = 20;

            // Act
            model.PointerMove(x, y);
            MockState state = (MockState)model.CurrentState;

            Assert.AreEqual(x, state.mouseMoveX);
            Assert.AreEqual(y, state.mouseMoveY);
        }

        [TestMethod()]
        public void PointerUpTest()
        {
            // Arrange

            IState mockstate = new MockState();
            model.CurrentState = mockstate;
            mockstate.Initialize(model);

            var x = 10;
            var y = 20;

            // Act
            model.PointerUp(x, y);
            MockState state = (MockState)model.CurrentState;

            Assert.AreEqual(x, state.mouseUpX);
            Assert.AreEqual(y, state.mouseUpY);

        }

        [TestMethod()]
        public void PointerDoubleClickTest()
        {
            // Arrange

            IState mockstate = new MockState();
            model.CurrentState = mockstate;
            mockstate.Initialize(model);

            var x = 10;
            var y = 20;

            // Act
            model.PointerDoubleClick(x, y);
            MockState state = (MockState)model.CurrentState;

            Assert.AreEqual(x, state.mouseDoubleClickX);
            Assert.AreEqual(y, state.mouseDoubleClickY);

        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            model.AddShape("start", "aaa", 0, 0, 100, 200);
            model.AddShape("Terminator", "bbb", 0, 0, 100, 200);
            model.AddShape("Process", "ccc", 0, 0, 100, 200);
            model.RemoveShape(2);
            model.RemoveShape(3);
            model.RemoveShape(99);
            var shape = model.GetShapes();
            Assert.AreEqual(2, shape.Count);
        }

        [TestMethod()]
        public void GetShapesTest()
        {

            model.AddShape("start", "aaa", 0, 0, 100, 200);
            model.AddShape("Terminator", "bbb", 0, 0, 100, 200);
            model.AddShape("Process", "ccc", 0, 0, 100, 200);
            model.AddShape("Decision", "ddd", 0, 0, 100, 200);
            var shape = model.GetShapes();
            Assert.AreEqual(4, shape.Count);

        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            bool isNotified = false;
            model.ModelChanged += () => isNotified = true;
            isNotified = false;

            model.NotifyObserver();

            Assert.IsTrue(isNotified);
        }

        [TestMethod()]
        public void NotifyTextChangeRequestedTest()
        {
            Shape nshape = model.GetNewShape("start", "aaa", 0, 0, 100, 200);
            bool isNotified = false;
            model.TextChangeRequested += (shape) => isNotified = true;
            isNotified = false;
            model.NotifyTextChangeRequested(nshape);
            Assert.IsTrue(isNotified);
        }

        [TestMethod()]
        public void GetModeTest()
        {

            model.SetDrawingMode("Start");
            Assert.AreEqual("Start", model.GetMode());

            model.SetSelectMode();
            Assert.AreEqual("", model.GetMode());
        }

        [TestMethod()]
        public void GetShapeTest()
        {
            model.AddShape("start", "aaa", 0, 0, 100, 200);
            model.AddShape("Terminator", "bbb", 0, 0, 100, 200);
            model.AddShape("Process", "ccc", 0, 0, 100, 200);
            model.AddShape("Decision", "ddd", 0, 0, 100, 200);
            Assert.AreEqual(4, model.GetShapes().Count);
        }

        [TestMethod()]
        public void GetNewIdTest()
        {
            model.GetNewId();
        }

        [TestMethod()]
        public void SaveAsyncTest()
        {
            //model.SaveAsync("test");
        }

        [TestMethod()]
        public void LoadTest()
        {
            //model.Load("test");
        }
    }
}