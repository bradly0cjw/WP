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
    public class CommandManagerTest
    {
        private CommandManager _cM;

        [TestInitialize]
        public void Initialize()
        {
            _cM = new CommandManager();
        }


        [TestMethod()]
        public void ExecuteTest()
        {
            var mockcmd = new MockCommand();
            _cM.ExecuteCommand(mockcmd);

            Assert.IsTrue(mockcmd.Executed);
            Assert.IsTrue(_cM.CanUndo);
            Assert.IsFalse(_cM.CanRedo);
        }

        [TestMethod()]
        public void UndoTest()
        {
            var mockcmd = new MockCommand();
            _cM.ExecuteCommand(mockcmd);
            _cM.Undo();
            Assert.IsFalse(mockcmd.Executed);
            Assert.IsFalse(_cM.CanUndo);
            Assert.IsTrue(_cM.CanRedo);
            _cM.Undo();

        }
        [TestMethod()]
        public void RedoTest()
        {
            var mockcmd = new MockCommand();
            _cM.ExecuteCommand(mockcmd);
            _cM.Undo();
            _cM.Redo();
            Assert.IsTrue(mockcmd.Executed);
            Assert.IsTrue(_cM.CanUndo);
            Assert.IsFalse(_cM.CanRedo);
            _cM.Redo();
        }
    }
}
