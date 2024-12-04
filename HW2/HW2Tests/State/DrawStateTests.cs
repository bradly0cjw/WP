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
    public class DrawStateTests
    {

        private Model _model;
        private DrawState _drawState;

        private PrivateObject _pObj;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _drawState = new DrawState();
            _drawState.Initialize(_model);

            _pObj = new PrivateObject(_drawState);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            int x = 100;
            int y = 100;

            _model.SetDrawingMode("Start");
            _drawState.MouseDown(x, y);

            var hint = _pObj.GetField("_hint") as Shape;
            Assert.IsNotNull(hint);
            Assert.AreEqual(x, hint.X);
            Assert.AreEqual(y, hint.Y);
            Assert.AreEqual(_pObj.GetField("_isPressed"), true);
            Assert.AreEqual(_pObj.GetField("_initX"), x);
            Assert.AreEqual(_pObj.GetField("_initY"), y);

            x = -10;
            y = -10;
            _model.SetDrawingMode("Start");
            _drawState.MouseDown(x, y);

            hint = _pObj.GetField("_hint") as Shape;
            Assert.IsNotNull(hint);
            Assert.AreEqual(x, hint.X);
            Assert.AreEqual(y, hint.Y);
            Assert.AreEqual(_pObj.GetField("_isPressed"), true);
            Assert.AreEqual(_pObj.GetField("_initX"), x);
            Assert.AreEqual(_pObj.GetField("_initY"), y);

        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            int ix = 100;
            int iy = 100;

            int x = 200;
            int y = 200;

            _model.SetDrawingMode("Start");
            _drawState.MouseMove(x, y);

            Assert.AreEqual(_pObj.GetField("_isPressed"), false);
            _drawState.MouseDown(ix, iy);
            _drawState.MouseMove(x, y);
            Assert.AreEqual(_pObj.GetField("_isPressed"), true);



            var hint = _pObj.GetField("_hint") as Shape;
            Assert.AreEqual(x - ix, hint.W);
            Assert.AreEqual(y - iy, hint.H);

            _drawState.MouseMove(-x, -y);
            Assert.AreEqual(-x, hint.X);
            Assert.AreEqual(-y, hint.Y);


        }

        [TestMethod()]
        public void MouseUpTest()
        {
            int ix = 100;
            int iy = 100;
            int x = 200;
            int y = 200;

            _model.SetDrawingMode("Start");
            _drawState.MouseUp(x, y);
            _drawState.MouseDown(ix, iy);
            _drawState.MouseMove(x, y);
            _drawState.MouseUp(x, y);


            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            var shape = shapes[0];
            Assert.AreEqual(ix, shape.X);
            Assert.AreEqual(iy, shape.Y);
            Assert.AreEqual(x - ix, shape.W);
            Assert.AreEqual(y - iy, shape.H);


        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            _model.SetDrawingMode("Start");
            _drawState.MouseMove(200, 200);
            _drawState.Draw(mockGraphic);

            _drawState.MouseDown(100, 100);
            _drawState.MouseMove(200, 200);
            _drawState.Draw(mockGraphic);
            _drawState.MouseUp(300, 400);

            _model.AddShape("Start", "test", 100, 200, 300, 400);

            _drawState.Draw(mockGraphic);

        }

        [TestMethod()]
        public void GenerateRandomTextTest()
        {
            var text = _drawState.GenerateRandomText();
            Assert.AreEqual(5, text.Length);
            Assert.IsTrue(text.All(c => DrawState.chars.Contains(c)));
        }
    }
}