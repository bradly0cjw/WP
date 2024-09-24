using System;
using System.Security.Policy;

namespace HW1
{
    internal class Model
    {
        private double inputNum = 0;
        private double resultNum = 0;
        private string operation = "";
        private string equalOperation = "";
        private double memory = 0;
        private bool operationPress = false;
        private bool equalPress = false;
        private bool init = true;
        

        public double Calc(string op)
        {
            Console.WriteLine("Result: "+ resultNum +" "+op+" input: " + inputNum );
            switch (op)
            {
                case "+":
                    return resultNum + inputNum;
                case "-":
                    return resultNum - inputNum;
                case "*":
                    return resultNum * inputNum;
                case "/":
                    return resultNum / inputNum;
                default:
                    return resultNum;
            }
        }
        public void SetOperation(string execute)
        {
            if (init)
            {
                resultNum = inputNum;
                init = false;
            }
            if (equalPress)
            {
                operation = "";
                equalPress = false;
            }
            resultNum = Calc(operation);
            operation = execute;
            operationPress = true;

        }

        public string SetDigit(string original, string append)
        {
            if (original.StartsWith("0"))
            {
                original = original.Remove(0, 1);
            }
            if (operationPress)
            {
                original = "";
                operationPress = false;
            }
            if (append == "." && original.Contains("."))
            {
                inputNum = Convert.ToDouble(original);
                return original; // Prevent multiple dots
            }
            inputNum = Convert.ToDouble(original + append);
            return original + append;
        }

        public void MPlus(string number)
        {
            memory += Convert.ToDouble(number);
        }

        public void MMinus(string number)
        {
            memory -= Convert.ToDouble(number);

        }
        public void MClear()
        {
            memory = 0;
        }

        public string MRecall()
        {
            return memory.ToString();
        }

        public void MStore(string number)
        {
            memory = Convert.ToDouble(number);
        }

        public string Clear()
        {
            inputNum = 0;
            resultNum = 0;
            operation = "";
            init = true;
            return "0";
        }
        public string ClearEntry()
        {
            inputNum = 0;
            return "0";
        }

        public string Calculate()
        {
            //return Operation("=", resultNum.ToString());
            resultNum = Calc(operation);
            equalPress = true;
            return resultNum.ToString();
        }
    }
}
