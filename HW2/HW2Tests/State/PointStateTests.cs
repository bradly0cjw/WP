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
    public class PointStateTests
    {
        private Model _model;
        private PointState _pointState;

        private PrivateObject _pObj;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _pointState = new PointState();
            _pointState.Initialize(_model);
            _pObj = new PrivateObject(_pointState);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            _model.AddShape("Start", "test", 0, 0, 100, 200);
            _pointState.MouseDown(50, 100);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), true);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_preX"), 50);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_preY"), 100);
            Assert.IsNotNull(_pointState.SelectedShape);
            _pointState.MouseDown(300, 400);
            Assert.IsNull(_pointState.SelectedShape);
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            _model.AddShape("Start", "test", 0, 0, 100, 200);
            _pointState.MouseMove(50, 100);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), false);

            _pointState.MouseDown(50, 100);
            _pointState.MouseMove(100, 200);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), true);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isTextClicked"), false);


            Assert.AreEqual(_pObj.GetFieldOrProperty("_preX"), 100);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_preY"), 200);
            _pointState.MouseUp(200, 300);

            _model.AddShape("Start", "text", 100, 200, 300, 400);
            _pointState.MouseDown(281, 401);
            _pointState.MouseMove(300, 400);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isTextClicked"), true);


        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _model.AddShape("Start", "test", 0, 0, 100, 200);
            _pointState.MouseDown(50, 100);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), true);
            _pointState.MouseUp(100, 200);
            Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), false);

            _model.AddShape("Start", "test", 200, 200, 100, 200);
            _pointState.MouseDown(280, 300);
            _pointState.MouseMove(300,400);
            _pointState.MouseUp(300, 400);

            _pointState.MouseUp(2800, 3000);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphic mockGraphic = new MockGraphic();
            _model.AddShape("Start", "test", 0, 0, 100, 200);
            _pointState.Draw(mockGraphic);

            _model.AddShape("Terminator", "test", 100, 200, 300, 400);
            _pointState.MouseDown(200, 300);
            _pointState.Draw(mockGraphic);

        }

        [TestMethod()]
        public void MouseDoubleClickTest()
        {
            _model.AddShape("Start", "test", 0, 0, 100, 200);
            _pointState.MouseDoubleClick(300,300);
            _pointState.MouseDown(80, 100);
            _pointState.MouseDoubleClick(50, 100);
            _pointState.MouseDoubleClick(80,100);
            //Assert.AreEqual(_pObj.GetFieldOrProperty("_isPressed"), false);
            //Assert.IsNull(_pointState.SelectedShape);
        }
    }
}