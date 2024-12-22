using System.Drawing;

namespace HW2
{
    public class FormGraphicAdapter : IGraphic
    {
        private readonly Graphics _graphics;
        private readonly Pen _pen;

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
            catch
            {
            }
        }

        public void DrawEllipse(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawEllipse(_pen, x1, y1, x2, y2);
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(_pen, x1, y1, x2, y2);
        }

        public void DrawPolygon(int x, int y, int w, int h)
        {
            Point[] points = new Point[4];
            points[0] = new Point(x + w / 2, y);
            points[1] = new Point(x + w, y + h / 2);
            points[2] = new Point(x + w / 2, y + h);
            points[3] = new Point(x, y + h / 2);
            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawRectangle(_pen, x1, y1, x2, y2);
        }

        public void DrawString(string text, int x, int y)
        {
            _graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, x, y);
        }

        public void DrawBounding(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawRectangle(new Pen(Color.Red), x1, y1, y2, (float)x2);
        }

        public void DrawDot(int x, int y)
        {

            _graphics.FillRectangle(new SolidBrush(Color.Red), (float)(x - 3), (float)(y - 3), 6, 6);
            //Console.WriteLine("Rec "+ x+" "+y );
        }
    }
}
