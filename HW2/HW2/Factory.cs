using System;

namespace HW2
{
    public static class ShapeFactory
    {
        // Create shape based on shape name
        public static Shape CreateShape(string shapeName, int x, int y,int width, int height)
        {
            switch (shapeName.ToLower())
            {
                case "start":
                    return new Start(shapeName, x, y, width, height);
                case "terminator":
                    return new Terminator(shapeName, x, y, width, height);
                case "process":
                    return new Process(shapeName, x, y, width, height);
                case "decision":
                    return new Decision(shapeName, x, y, width, height);
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
}