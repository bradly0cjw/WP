using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Line : Shape
    {
        public Shape connection1;
        public Shape connection2;
        public int point1;
        public int point2;

        public Line(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        {
            connection1 = null;
            connection2 = null;
            point1 = -1;
            point2 = -1;

        }

        public void SetConnection1(Shape shape, int point)
        {
            connection1 = shape;
            point1 = point;
        }

        public void SetConnection2(Shape shape, int point)
        {
            connection2 = shape;
            point2 = point;
        }

        public override void Draw(IGraphic graphic)
        {
            graphic.DrawLine(X, Y, W, H);

        }

        public override bool IsClickInShape(int x, int y)
        {
            return false;
        }

        public override bool IsClickOnText(int x, int y)
        {
            return false;


        }

        public override void DrawConnectionPoint(IGraphic graphic)
        {

        }

        public override int IsClickConnectionPoint(int x, int y)
        {
            return -1;

        }
        public override (int, int) GetConnectionPoint(int index)
        {
            return (-1,-1);
        }
    }
}
