using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public interface IGraphic
    {
        void ClearAll();

        void DrawLine(int x1, int y1, int x2, int y2);

        void DrawRectangle(int x1, int y1, int x2, int y2);

        void DrawEllipse(int x1, int y1, int x2, int y2);


        void DrawArc(int x1, int y1, int x2, int y2, int deg1, int deg2);


        void DrawString(string text, int x, int y);


        void DrawPolygon(Point[] points);

        void DrawBounding(int x1, int y1, int x2, int y2);
    }
}
