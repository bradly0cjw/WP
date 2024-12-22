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
        public Model Model;
        public AddCommand AddCommand;
        public Shape Shape1, Shape2, Shape3;

        [TestInitialize]
        public void Initialize()
        {
            Model = new Model();
            Shape1 = Model.GetNewShape("Start", "aaa", 0, 0, 100, 200);
            Shape2 = Model.GetNewShape("Start", "bbb", 0, 0, 100, 200);
            Shape3 = Model.GetNewShape("Start", "ccc", 0, 0, 100, 200);


            AddCommand = new AddCommand(Model, Shape1);
        }


        [TestMethod()]
        public void ExecuteTest()
        {
            AddCommand.Execute();
            Assert.AreEqual(1, Model.GetShapes().Count);
            AddCommand = new AddCommand(Model, Shape2);
            AddCommand.Execute();
            Assert.AreEqual(2, Model.GetShapes().Count);
            AddCommand = new AddCommand(Model, Shape3);
            AddCommand.Execute();
            Assert.AreEqual(3, Model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            AddCommand.Execute();
            Assert.AreEqual(1, Model.GetShapes().Count);
            AddCommand.Unexecute();
            Assert.AreEqual(0, Model.GetShapes().Count);
        }
    }
}
