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

        public int BiasX { get; set; }

        public int BiasY { get; set; }

        // Constructor
        protected Shape(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0, int biasY = 0)
        {
            ShapeName = shapeName;
            Text = text;
            ID = id;
            X = x;
            Y = y;
            W = width;
            H = height;
            BiasX = biasX;
            BiasY = biasY;
        }
        // abstract method
        // not virtual method
        public abstract void Draw(IGraphic graphic);

        public abstract bool IsClickInShape(int x, int y);

        public abstract bool IsClickOnText(int x, int y);

        public void DrawBounding(IGraphic graphic)
        {
            graphic.DrawBounding(X - 1, Y - 1, H + 2, W + 2);
            graphic.DrawBounding(X + (W / 2) + BiasX, Y + (H / 2) + BiasY, 20, 60);
            graphic.DrawDot(X + (W / 2) + BiasX, Y + (H / 2) + BiasY, 60, 20);

        }

        public void Normalize()
        {
            if (H < 0)
            {
                H *= -1;
                Y -= H;
            }
            if (W < 0)
            {
                W *= -1;
                X -= W;
            }
        }
    }
}