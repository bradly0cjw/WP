using System;


namespace HW2
{
    // Shape class to store the properties of a shape
    public abstract class Shape
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
        // abstract method
        // not virtual method
        public abstract void Draw(IGraphic graphic);


        public abstract bool IsClickInShape(int x, int y);
        //Console.WriteLine($"Checking if click is in shape {ShapeName} at ({X}, {Y}) with width {W} and height {H}");



        public void DrawBounding(IGraphic graphic)
        {
            graphic.DrawBounding(X - 1, Y - 1, W + 2, H + 2);
        }

        public void Normalize()
        {
            if (H < 0)
            {
                H *= -1;
                X -= H;
            }
            if (W < 0)
            {
                W *= -1;
                Y -= W;
            }
        }
    }
}