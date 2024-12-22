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
        public int Connection1 { get; set; }
        public int Connection2 { get; set; }
        public Shape Shape1 { get; set; }
        public Shape Shape2 { get; set; }

        public Line(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        {
            Connection1 = -1;
            Connection2 = -1;
            Shape1 = null;
            Shape2 = null;
        }

        public void SetConnection1(Shape shape, int point)
        {
            (Shape1,Connection1) = (shape, point);
        }

        public void SetConnection2(Shape shape, int point)
        {
            (Shape2,Connection2) = (shape, point);
        }

        public override void Draw(IGraphic graphic)
        {
            // flags3
            if (Shape2 != null)
            {
                (X,Y) = Shape1.GetConnectionPoint(Connection1);
                (W,H) = Shape2.GetConnectionPoint(Connection2);
            }
            graphic.DrawLine(X, Y, W, H);
            
        }

        public override bool IsClickInShape(int x, int y)
        {
            return false;
        }

    }
}
