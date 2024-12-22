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
        private DrawLineState _State;

        private PrivateObject _pObj;
       
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _State = new DrawLineState();
            _State.Initialize(_model);
            


            _pObj = new PrivateObject(_State);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            int x1 = 300;
            int y1 = 200;
            int x2 = 500;
            int y2 = 400;
            _model.SetLineMode("Line");
            _State.Initialize(_model);
            _State.MouseDown(x1, y1);
            Assert.AreEqual(_pObj.GetField("_selectShape"), null);
            _State.MouseMove(x1,y1);
            _State.MouseDown(x1, y1);
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
            _State.Initialize(_model);

            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _State.MouseMove(x2,y2);
            _State.MouseMove(x1,y1);
            Assert.AreEqual(_pObj.GetField("_selectShape"),null);
            _State.MouseDown(x1, y1);
            _State.MouseMove(x2, y2);
            Assert.IsNotNull(_pObj.GetField("_selectShape"));
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            _model.SetLineMode("Line");
            _State.Initialize(_model);
            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _State.MouseMove(x2, y2);
            _State.MouseMove(x1, y1);
            _State.MouseDown(x1, y1);
            _State.MouseMove(x2, y2);
            _State.MouseUp(x2, y2);
            _model.SetLineMode("Line");
            _State.MouseMove(x1, y1);
            _State.MouseDown(x1, y1);
            _State.MouseUp(x1, y1);
            _model.SetLineMode("Line");
            _State.MouseMove(x1, y1);
            _State.MouseDown(x1, y1);
            _State.MouseMove(x2, y2);
            _State.MouseUp(900, 900);
        }

        [TestMethod()]
        public void MouseDoubleClickTest()
        {
            _State.MouseDoubleClick(0,0);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            _model.AddShape("Process", "aaa", 200, 200, 200, 100);
            _model.AddShape("Process", "bbb", 400, 400, 200, 100);
            _model.SetDrawingMode("Start");
            _State.MouseDown(200,200);
            _State.Draw(mockGraphic);

            _State.MouseMove(200, 200);
            _State.Draw(mockGraphic);

            _State.MouseDown(100, 100);
            _State.MouseMove(200, 200);
            _State.Draw(mockGraphic);
            _State.MouseUp(300, 400);

            int x1 = 298;
            int y1 = 202;
            int x2 = 498;
            int y2 = 402;
            _State.MouseMove(x1, y1);
            _State.MouseDown(x1, y1);
            _State.MouseMove(x2, y2);

            _State.Draw(mockGraphic);

        }

    }
}