using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(string shapeSelect, int id, string text, int x, int y, int height, int width)
        {
            switch (shapeSelect.ToLower())
            {
                case "start":
                    return new Start { Id = id, ShapeName = text, X = x, Y = y, Height = height, Width = width };
                case "terminator":
                    return new Terminator { Id = id, ShapeName = text, X = x, Y = y, Height = height, Width = width };
                case "process":
                    return new Process { Id = id, ShapeName = text, X = x, Y = y, Height = height, Width = width };
                case "decision":
                    return new Decision { Id = id, ShapeName = text, X = x, Y = y, Height = height, Width = width };
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
}
