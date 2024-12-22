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
        public Model Model;
        public DeleteCommand DeleteCommand;
        public AddCommand AddCommand;
        public Shape Shape1, Shape2, Shape3, Shape4;

        [TestInitialize]
        public void Initialize()
        {
            Model = new Model();
            Shape1 = Model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            Shape2 = Model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            Shape3 = Model.GetNewShape("Start", "ccc", 0, 0, 100, 200);
            Shape4 = Model.GetNewShape("Start", "ddd", 0, 0, 100, 200);

            AddCommand = new AddCommand(Model, Shape1);
            AddCommand.Execute();
            AddCommand = new AddCommand(Model, Shape2);
            AddCommand.Execute();
            AddCommand = new AddCommand(Model, Shape3);
            AddCommand.Execute();
            AddCommand = new AddCommand(Model, Shape4);
            AddCommand.Execute();

            Line line1 = new Line("Line", "test1", 999, 100, 200, 300, 400);
            Model.AddShapeObj(line1);
            line1.SetConnection1(Shape1, 0);
            line1.SetConnection2(Shape2, 0);

            Line line2 = new Line("Line", "test2", 1000, 100, 200, 300, 400);
            Model.AddShapeObj(line2);
            line2.SetConnection1(Shape2, 0);
            line2.SetConnection2(Shape3, 0);
        }

        [TestMethod()]
        public void ExecuteTest_NoConnectedLines()
        {
            DeleteCommand = new DeleteCommand(Model, Shape4);
            DeleteCommand.Execute();
            Assert.AreEqual(5, Model.GetShapes().Count);
        }

        [TestMethod()]
        public void ExecuteTest_OneConnectedLine()
        {
            DeleteCommand = new DeleteCommand(Model, Shape3);
            DeleteCommand.Execute();
            Assert.AreEqual(4, Model.GetShapes().Count);
        }

        [TestMethod()]
        public void ExecuteTest_MultipleConnectedLines()
        {
            DeleteCommand = new DeleteCommand(Model, Shape2);
            DeleteCommand.Execute();
            Assert.AreEqual(3, Model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            DeleteCommand = new DeleteCommand(Model, Shape3);
            DeleteCommand.Execute();
            Assert.AreEqual(4, Model.GetShapes().Count);
            DeleteCommand.Unexecute();
            Assert.AreEqual(6, Model.GetShapes().Count);
            DeleteCommand = new DeleteCommand(Model, Shape2);
            DeleteCommand.Execute();
            Assert.AreEqual(3, Model.GetShapes().Count);
            DeleteCommand.Unexecute();
            Assert.AreEqual(6, Model.GetShapes().Count);
        }
    }
}
