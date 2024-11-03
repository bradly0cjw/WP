using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public interface Igraphic
    {
        void ClearAll();

        void DrawLine(double x1, double y1, double x2, double y2);

        void DrawRectangle(double x1, double y1, double x2, double y2);

        void DrawEllipse(double x1, double y1, double x2, double y2);


        void DrawArc(double x1, double y1, double x2, double y2, int deg1, int deg2);


        void DrawString(string text, double x, double y);


        void DrawPolygon(Point[] points);

    }
}
