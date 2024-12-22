using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using HW2Tests;

namespace HW2.Tests
{
    [TestClass()]
    public class DeleteCommandTest
    {
        public Model _model;
        public DeleteCommand _deleteCommand;
        public AddCommand _addCommand;
        public Shape _shape1, _shape2, _shape3, _shape4;

        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _shape1 = _model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            _shape2 = _model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            _shape3 = _model.GetNewShape("Start", "ccc", 0, 0, 100, 200);
            _shape4 = _model.GetNewShape("Start", "ddd", 0, 0, 100, 200);

            _addCommand = new AddCommand(_model, _shape1);
            _addCommand.Execute();
            _addCommand = new AddCommand(_model, _shape2);
            _addCommand.Execute();
            _addCommand = new AddCommand(_model, _shape3);
            _addCommand.Execute();
            _addCommand = new AddCommand(_model, _shape4);
            _addCommand.Execute();

            Line line1 = new Line("Line", "test1", 999, 100, 200, 300, 400);
            _model.AddShapeObj(line1);
            line1.SetConnection1(_shape1, 0);
            line1.SetConnection2(_shape2, 0);

            Line line2 = new Line("Line", "test2", 1000, 100, 200, 300, 400);
            _model.AddShapeObj(line2);
            line2.SetConnection1(_shape2, 0);
            line2.SetConnection2(_shape3, 0);
        }

        [TestMethod()]
        public void ExecuteTest_NoConnectedLines()
        {
            _deleteCommand = new DeleteCommand(_model, _shape4);
            _deleteCommand.Execute();
            Assert.AreEqual(5, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void ExecuteTest_OneConnectedLine()
        {
            _deleteCommand = new DeleteCommand(_model, _shape3);
            _deleteCommand.Execute();
            Assert.AreEqual(4, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void ExecuteTest_MultipleConnectedLines()
        {
            _deleteCommand = new DeleteCommand(_model, _shape2);
            _deleteCommand.Execute();
            Assert.AreEqual(3, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _deleteCommand = new DeleteCommand(_model, _shape3);
            _deleteCommand.Execute();
            Assert.AreEqual(4, _model.GetShapes().Count);
            _deleteCommand.Unexecute();
            Assert.AreEqual(6, _model.GetShapes().Count);
            _deleteCommand = new DeleteCommand(_model, _shape2);
            _deleteCommand.Execute();
            Assert.AreEqual(3, _model.GetShapes().Count);
            _deleteCommand.Unexecute();
            Assert.AreEqual(6, _model.GetShapes().Count);
        }
    }
}
