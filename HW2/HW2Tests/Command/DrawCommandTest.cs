using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using HW2Tests;

namespace HW2.Tests
{
    /// <summary>
    /// Summary description for AddCommandTest
    /// </summary>
    [TestClass()]
    public class DrawCommandTest
    {
        public Model _model;
        public DrawCommand _drawCommand;
        public Shape _shape1,_shape2,_shape3;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _shape1=_model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            _shape2 = _model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            _shape3 = _model.GetNewShape("Start", "ccc", 0, 0, 100, 200);
            

            _drawCommand = new DrawCommand(_model, _shape1);
        }


        [TestMethod()]
        public void ExecuteTest()
        {
            _drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _drawCommand = new DrawCommand(_model, _shape2);
            _drawCommand.Execute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            _drawCommand = new DrawCommand(_model, _shape3);
            _drawCommand.Execute();
            Assert.AreEqual(3, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _drawCommand.Unexecute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }
    }
}
