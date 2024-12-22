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
    public class MoveCommandTest
    {
        public Model _model;
        public MoveCommand _moveCommand;
        public AddCommand _addCommand;
        public Shape _shape1, _shape2, _shape3;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _shape1 = _model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            _shape2 = _model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            _shape3 = _model.GetNewShape("Start", "ccc", 0, 0, 100, 200);

            _addCommand = new AddCommand(_model, _shape1);
            _addCommand.Execute();


        }


        [TestMethod()]
        public void ExecuteTest()
        {
            _moveCommand = new MoveCommand(_shape1, 0, 0, 200, 300);
            _moveCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _moveCommand = new MoveCommand(_shape1, 0, 0, 200, 300);
            _moveCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _moveCommand.Unexecute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }
    }
}
