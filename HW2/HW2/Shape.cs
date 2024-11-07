using System;


namespace HW2
{
    // Shape class to store the properties of a shape
    public class Shape
    {
        
        public string ShapeName { get; set; }
        public string Text { get; set; }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        // Constructor
        public Shape(string shapeName, string text, int id, int x, int y, int width, int height)
        {
            ShapeName = shapeName;
            Text = text;
            ID = id;
            X = x;
            Y = y;
            W = width;
            H = height;
        }
        // Virtual method
        public virtual void Draw(IGraphic graphic)
        {
            Console.WriteLine($"Drawing {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
        }
    }
}