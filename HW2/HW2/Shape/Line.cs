using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Line : Shape
    {
        public Line(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0,
            int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        {
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
    }
}
