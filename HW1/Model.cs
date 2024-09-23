using System;
using System.Security.Policy;

namespace HW1
{
    internal class Model
    {
        private double inputNum = 0;
        private double resultNum = 0;
        private string operation = "";
        private double memory = 0;
        private bool operationPress = false;

        public string Operation(string execute, string first)
        {
            operationPress = true;
            Console.WriteLine("Operation: " + operation+"E"+execute+"F" + first);
            switch (operation)
            {
                case "+":
                    resultNum = resultNum + inputNum;
                    break;
                case "-":
                    resultNum = resultNum - inputNum;
                    break;
                case "*":
                    resultNum = resultNum * inputNum;
                    break;
                case "/":
                    resultNum = resultNum / inputNum;
                    break;
                case "":
                    break;
                default:
                    return "Error";

            }
            if (execute != "=")
                operation = execute;
            inputNum = Convert.ToDouble(first);
            return resultNum.ToString();
        }

        public string SetDigit(string original, string append)
        {
            if (append == "." && original.Contains("."))
            {
                return original; // Prevent multiple dots
            }
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
            return "0";
        }
        public string ClearEntry()
        {
            inputNum = 0;
            return "0";
        }

        public string Calculate()
        {
            return Operation("=", resultNum.ToString());
        }
    }
}
