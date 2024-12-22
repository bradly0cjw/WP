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
        public Model Model;
        public TextChangedCommand TextChangedCommand;
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
            AddCommand.Execute();

        }


        [TestMethod()]
        public void ExecuteTest()
        {
            TextChangedCommand = new TextChangedCommand(Shape1, "old", "new");
            TextChangedCommand.Execute();
            Assert.AreEqual(1, Model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            TextChangedCommand = new TextChangedCommand(Shape1, "old", "new");
            TextChangedCommand.Execute();
            Assert.AreEqual(1, Model.GetShapes().Count);
            TextChangedCommand.Unexecute();
            Assert.AreEqual(1, Model.GetShapes().Count);
        }
    }
}
