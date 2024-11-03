using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class FormGraphicAdapter : Igraphic
    {
        private Graphics _graphics;
        private Pen _pen;

        public FormGraphicAdapter(Graphics graphics)
        {
            _graphics = graphics;
            _pen = new Pen(Color.Black);
        }

        public void ClearAll()
        {
            _graphics.Clear(Color.White);
        }

        public void DrawArc(double x1, double y1, double x2, double y2, int deg1, int deg2)
        {
            _graphics.DrawArc(_pen, (float)x1, (float)y1, (float)x2, (float)y2, deg1, deg2);
        }

        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawPolygon(Point[] points)
        {
            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawString(string text, double x, double y)
        {
            _graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, (float)x, (float)y);
        }
    }

}
