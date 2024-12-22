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
    public class AddCommandTest
    {
        public Model _model;
        public AddCommand _addCommand;
        public Shape _shape1,_shape2,_shape3;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _shape1=_model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            _shape2 = _model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            _shape3 = _model.GetNewShape("Start", "ccc", 0, 0, 100, 200);
            

            _addCommand = new AddCommand(_model, _shape1);
        }


        [TestMethod()]
        public void ExecuteTest()
        {
            _addCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _addCommand = new AddCommand(_model, _shape2);
            _addCommand.Execute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            _addCommand = new AddCommand(_model, _shape3);
            _addCommand.Execute();
            Assert.AreEqual(3, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _addCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _addCommand.Unexecute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }
    }
}
