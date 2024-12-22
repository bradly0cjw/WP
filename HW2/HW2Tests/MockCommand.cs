using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2;

namespace HW2Tests
{
    internal class MockCommand : ICommand
    {

        public bool UnExecuted { get; private set; }
        public bool Executed { get; private set; }
        public void Execute()
        {
            Executed = true;
            UnExecuted = false;
        }

        public void Unexecute()
        {
            UnExecuted = true;
            Executed = false;
        }
    }
}