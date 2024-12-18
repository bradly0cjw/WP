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
        public (Shape,int) connection1 { get; set; }
        public (Shape, int) connection2 { get; set; }
        public (int, int) relativePosition1 { get; set; }
        public (int, int) relativePosition2 { get; set; }

        public Line(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        {
            connection1 = (null, -1);
            connection2 = (null, -1);
        }

        public void SetConnection1(Shape shape, int point)
        {
            connection1 = (shape,point);
            relativePosition1 = shape.GetConnectionPoint(point);
            (X, Y) = relativePosition1;
            Console.WriteLine(relativePosition1);
        }

        public void SetConnection2(Shape shape, int point)
        {
            connection2 = (shape, point);
            relativePosition2 = shape.GetConnectionPoint(point);
            (W, H) = relativePosition2;
            Console.WriteLine(relativePosition2);
        }

        public override void Draw(IGraphic graphic)
        {
            if (connection2.Item1 != null)
            {
                var (x1, y1) = relativePosition1;
                var (x2, y2) = relativePosition2;
                graphic.DrawLine(x1, y1, x2, y2);
            }
            else
            {
                graphic.DrawLine(X, Y, W, H);
            }
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
            return (-1, -1);
        }
    }
}
