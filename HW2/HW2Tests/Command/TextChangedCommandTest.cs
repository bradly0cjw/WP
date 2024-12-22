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
    public class TextChangedCommandTest
    {
        public Model _model;
        public TextChangedCommand _TextChangedCommand;
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
            _addCommand.Execute();

        }


        [TestMethod()]
        public void ExecuteTest()
        {
            _TextChangedCommand = new TextChangedCommand(_model, _shape1,"old","new");
            _TextChangedCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _TextChangedCommand = new TextChangedCommand(_model, _shape1, "old", "new");
            _TextChangedCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _TextChangedCommand.Unexecute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }
    }
}
