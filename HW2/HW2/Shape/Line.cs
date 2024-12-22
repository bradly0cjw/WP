using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public class Line : Shape
    {
        public int connection1 { get; set; }
        public int connection2 { get; set; }
        public Shape shape1 { get; set; }
        public Shape shape2 { get; set; }

        //public (int, int) relativePosition1;
        //public (int, int) relativePosition2;

        public Line(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        {
            connection1 = -1;
            connection2 = -1;
            shape1 = null;
            shape2 = null;
        }

        public void SetConnection1(Shape shape, int point)
        {
            (shape1,connection1) = (shape, point);
            //relativePosition1 = shape.GetConnectionPoint(point);
            //(X, Y) = relativePosition1;
            //Console.WriteLine(relativePosition1);
        }

        public void SetConnection2(Shape shape, int point)
        {
            (shape2,connection2) = (shape, point);
            //relativePosition2 = shape.GetConnectionPoint(point);
            //(W, H) = relativePosition2;
            //Console.WriteLine(relativePosition2);
        }

        public override void Draw(IGraphic graphic)
        {
            // flags3
            if (shape2 != null)
            {
                (X,Y) = shape1.GetConnectionPoint(connection1);
                (W,H) = shape2.GetConnectionPoint(connection2);
            }
            graphic.DrawLine(X, Y, W, H);
            
        }

        public override bool IsClickInShape(int x, int y)
        {
            return false;
        }

    }
}
