using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(string shapeSelect, string text, int x, int y, int height, int width)
        {
            switch (shapeSelect.ToLower())
            {
                case "start":
                    return new Start { Text = text, X = x, Y = y, Height = height, Width = width };
                case "terminator":
                    return new Terminator { Text = text, X = x, Y = y, Height = height, Width = width };
                case "process":
                    return new Process { Text = text, X = x, Y = y, Height = height, Width = width };
                case "decision":
                    return new Decision { Text = text, X = x, Y = y, Height = height, Width = width };
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
}
