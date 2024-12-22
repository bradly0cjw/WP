using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;


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
        protected Shape(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0)
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

        public bool IsClickOnText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X + (W / 2) + 30 + BiasX - 3, Y + (H / 2) + BiasY - 3, 6, 6));
            return path.IsVisible(new Point(x, y));
        }

        public void DrawBounding(IGraphic graphic)
        {
            graphic.DrawBounding(X - 1, Y - 1, H + 2, W + 2);
            graphic.DrawBounding(X + (W / 2) + BiasX, Y + (H / 2) + BiasY, 20, 60);
            graphic.DrawDot(X + (W / 2) + BiasX + 30, Y + (H / 2) + BiasY);

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

        public void DrawConnectionPoint(IGraphic graphic)
        {
            graphic.DrawDot(X + (W / 2), Y);
            graphic.DrawDot(X + (W / 2), (Y + H));
            graphic.DrawDot((X + W), Y + (H / 2));
            graphic.DrawDot(X, Y + (H / 2));
        }

        public int IsClickConnectionPoint(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X + (W / 2) - 3, Y - 3, 6, 6));
            if (path.IsVisible(x, y))
            {
                return 1;
            }
            path.AddRectangle(new Rectangle(X + (W / 2) - 3, (Y + H) - 3, 6, 6));
            if (path.IsVisible(x, y))
            {
                return 2;
            }
            path.AddRectangle(new Rectangle((X + W) - 3, Y + (H / 2) - 3, 6, 6));
            if (path.IsVisible(x, y))
            {
                return 3;
            }
            path.AddRectangle(new Rectangle(X - 3, Y + (H / 2) - 3, 6, 6));
            if (path.IsVisible(x, y))
            {
                return 4;
            }
            return -1;

        }
        public (int, int) GetConnectionPoint(int index)
        {
            switch (index)
            {
                case 1:
                    return (X + (W / 2), Y);
                case 2:
                    return (X + (W / 2), (Y + H));
                case 3:
                    return ((X + W), Y + (H / 2));
                case 4:
                    return (X, Y + (H / 2));
                default:
                    return (-1, -1);
            }
        }
    }
}