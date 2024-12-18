using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class CommandManager
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
            // log command execute
            Console.WriteLine("Execute: " + command);
            Console.WriteLine("Undo stack count: " + _undoStack.Count);
            Console.WriteLine("Redo stack count: " + _redoStack.Count);
        }

        public void Undo()
        {
            if (CanUndo)
            {
                var command = _undoStack.Pop();
                command.Unexecute();
                _redoStack.Push(command);
                // log command execute
                Console.WriteLine("Undo: " + command);
                Console.WriteLine("Undo stack count: " + _undoStack.Count);
                Console.WriteLine("Redo stack count: " + _redoStack.Count);
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
                // log command execute
                Console.WriteLine("Redo: " + command);
                Console.WriteLine("Undo stack count: " + _undoStack.Count);
                Console.WriteLine("Redo stack count: " + _redoStack.Count);
            }
        }
    }
}


