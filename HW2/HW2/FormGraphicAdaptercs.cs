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

        public void DrawArc(int x, int y, int height, int width, int startAngle, int sweepAngle)
        {
            try
            {
                _graphics.DrawArc(_pen, x, y, width, height, startAngle, sweepAngle);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void DrawEllipse(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawEllipse(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawPolygon(Point[] points)
        {
            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawRectangle(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawString(string text, int x, int y)
        {
            _graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, (float)x, (float)y);
        }
    }

}
