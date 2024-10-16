using System;

namespace HW2
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(string shapeSelect, string text, int x, int y, int height, int width)
        {
            switch (shapeSelect.ToLower())
            {
                case "start":
                    return new Start(text, x, y, width, height);
                case "terminator":
                    return new Terminator(text, x, y, width, height);
                case "process":
                    return new Process(text, x, y, width, height);
                case "decision":
                    return new Decision(text, x, y, width, height);
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
}