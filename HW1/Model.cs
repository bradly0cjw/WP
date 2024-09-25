using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HW1
{
    internal class Model
    {
        // Variables
        private double _inputNum = 0;
        private double _resultNum = 0;
        private string _operation = null;
        private double _memory = 0;
        private bool _operationPressed = false;
        private bool _equalPressed = false;
        private bool _init = true;
        
        // Constant
        private const string Zero = "0";
        private const string Dot = ".";
        private const string Plus = "+";
        private const string Minus = "-";
        private const string Multiply = "*";
        private const string Divide = "/";
        private const string GetResult = "GetResult";

        // Debug method for internal state debugging
        //public void Debug()
        //{
        //    Console.WriteLine($"resultNum: {_resultNum} inputNum: {_inputNum} operation: {_operation}");
        //    Console.WriteLine($"memory: {_memory}");
        //    Console.WriteLine($"operationPressed: {_operationPressed} equalPressed: {_equalPressed} init: {_init}");
        //}

        // Calculate the result based on the operation
        public double Calculate(string operation)
        {
            //Debug();
            switch (operation)
            {
                case Plus:
                    return _resultNum + _inputNum;
                case Minus:
                    return _resultNum - _inputNum;
                case Multiply:
                    return _resultNum * _inputNum;
                case Divide:
                    // Prevent division by zero
                    if (_inputNum != 0) return _resultNum / _inputNum;

                    MessageBox.Show("Can't divide by zero");
                    Clear();
                    return 0;
                case GetResult:
                    return _resultNum;
                // If no operation is set, return the current number
                default:
                    return _inputNum;
            }
        }
        // Set the current operation
        public void SetOperation(string operation)
        {
            if (_init)
            {
                _resultNum = _inputNum;
                _init = false;
            }
            if (_equalPressed)
            {
                _operation = GetResult;
                _inputNum = _resultNum;
                _equalPressed = false;
            }
            _resultNum = Calculate(_operation);
            _operation = operation;
            _operationPressed = true;
            //Debug();
        }
        public string AppendDigit(string original, string append)
        {
            original = HandleEqualPressed(original);
            original = HandleOperationPressed(original);
            if (IsMultipleDots(original, append)) return original;
            original = HandleLeadingZeros(original, append);

            _inputNum = double.Parse(original + append);
            return original + append;
        }

        // Clear the number if the equal button is pressed
        private string HandleEqualPressed(string original)
        {
            if (_equalPressed)
            {
                Clear();
                _equalPressed = false;
                return Zero;
            }
            return original;
        }

        // Clear the number if an operation button is pressed
        private string HandleOperationPressed(string original)
        {
            if (!_operationPressed) return original;
            _operationPressed = false;
            return Zero;
        }

        // Prevent multiple dots in a number
        private bool IsMultipleDots(string original, string append)
        {
            return append == Dot && original.Contains(Dot);
        }

        // Prevent leading zeros in a number
        private string HandleLeadingZeros(string original, string append)
        {
            // Prevent leading zeros 
            if (original == Zero && append != Dot)
            {
                return null;
            }
            // Prevent multiple leading zeros
            if (original.Length > 1 && original[0] == char.Parse(Zero) && original[1] == char.Parse(Zero))
            {
                return original.Remove(1, 1);
            }
            return original;
        }

        // Add a number to memory
        public void MemoryPlus(string number)
        {
            _memory += double.Parse(number);
            //Debug();
        }
        // Subtract a number from memory
        public void MemoryMinus(string number)
        {
            _memory -= double.Parse(number);
            //Debug();
        }
        // Clear the memory
        public void MemoryClear()
        {
            _memory = 0;
            //Debug();
        }
        // Recall the number from memory
        public string MemoryRecall()
        {
            //Debug();
            return _memory.ToString();
        }
        // Store a number in memory
        public void MemoryStore(string number)
        {
            _memory = double.Parse(number);
            //Debug();
        }
        // Clear all 
        public string Clear()
        {
            _inputNum = 0;
            _resultNum = 0;
            _operation = null;
            _init = true;
            _equalPressed = false;
            _operationPressed = false;
            //Debug();
            return Zero;
        }
        // Clear the last entry
        public string ClearEntry()
        {
            _inputNum = 0;
            //Debug();
            return Zero;
        }
        // Calculate the result of the current operation
        public string CalculateResult()
        {
            // If the equal button is pressed multiple times, repeat the last operation
            _resultNum = Calculate(_operation);
            _equalPressed = true;
            //Debug();
            return _resultNum.ToString();
        }
    }
}
