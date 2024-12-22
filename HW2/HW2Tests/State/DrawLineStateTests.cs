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
    public class DrawLineStateTests
    {

        private Model _model;
        private DrawLineState _state;

        private PrivateObject _pObj;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _state = new DrawLineState();
            _state.Initialize(_model);



            _pObj = new PrivateObject(_state);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            int x1 = 300;
            int y1 = 200;
            _model.SetLineMode("Line");
            _state.Initialize(_model);
            _state.MouseDown(x1, y1);
            Assert.AreEqual(null, _pObj.GetField("_selectShape"));
            _state.MouseMove(x1, y1);
            _state.MouseDown(x1, y1);
            var hint = _pObj.GetField("_hint") as Shape;
            Assert.IsNotNull(hint);
            Assert.AreEqual(x1, hint.X);
            Assert.AreEqual(y1, hint.Y);




        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            _model.SetLineMode("Line");
            _state.Initialize(_model);

            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _state.MouseMove(x2, y2);
            _state.MouseMove(x1, y1);
            Assert.AreEqual(null, _pObj.GetField("_selectShape"));
            _state.MouseDown(x1, y1);
            _state.MouseMove(x2, y2);
            Assert.IsNotNull(_pObj.GetField("_selectShape"));
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            _model.SetLineMode("Line");
            _state.Initialize(_model);
            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _state.MouseMove(x2, y2);
            _state.MouseMove(x1, y1);
            _state.MouseDown(x1, y1);
            _state.MouseMove(x2, y2);
            _state.MouseUp(x2, y2);
            _model.SetLineMode("Line");
            _state.MouseMove(x1, y1);
            _state.MouseDown(x1, y1);
            _state.MouseUp(x1, y1);
            _model.SetLineMode("Line");
            _state.MouseMove(x1, y1);
            _state.MouseDown(x1, y1);
            _state.MouseMove(x2, y2);
            _state.MouseUp(900, 900);
        }

        [TestMethod()]
        public void MouseDoubleClickTest()
        {
            _state.MouseDoubleClick(0, 0);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            _model.SetDrawingMode("Start");
            _state.MouseDown(200, 200);
            _state.Draw(mockGraphic);

            _state.MouseMove(200, 200);
            _state.Draw(mockGraphic);

            _state.MouseDown(100, 100);
            _state.MouseMove(200, 200);
            _state.Draw(mockGraphic);
            _state.MouseUp(300, 400);

            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _state.MouseMove(x1, y1);
            _state.MouseDown(x1, y1);
            _state.MouseMove(x2, y2);

            _state.Draw(mockGraphic);

        }

    }
}