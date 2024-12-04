using System;
using System.Security.AccessControl;

namespace HW2
{
    public static class ShapeFactory
    {
        // Create shape based on shape name

        public static Shape CreateShape(string shapeName, string text, int id, int x, int y, int width, int height)
        {
            switch (shapeName.ToLower())
            {
                case "start":
                    return new Start(shapeName, text, id, x, y, width, height);
                case "terminator":
                    return new Terminator(shapeName, text, id, x, y, width, height);
                case "process":
                    return new Process(shapeName, text, id, x, y, width, height);
                case "decision":
                    return new Decision(shapeName, text, id, x, y, width, height);
                default:
                    return null;
            }
        }
    }
}