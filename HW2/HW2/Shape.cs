using System;

namespace HW2
{
    // Shape class to store the properties of a shape
    public class Shape
    {
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Shape(string text, int x, int y, int width, int height)
        {
            Text = text;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        public Start(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }
    }

    public class Terminator : Shape
    {
        public Terminator(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }
    }

    public class Process : Shape
    {
        public Process(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }
    }

    public class Decision : Shape
    {
        public Decision(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }
    }
}