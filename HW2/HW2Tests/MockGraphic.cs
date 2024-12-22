using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2;
using System.Drawing;


namespace HW2Tests
{
    internal class MockGraphic : IGraphic
    {
        public void ClearAll() { }

        public void DrawLine(int x1, int y1, int x2, int y2) { }

        public void DrawRectangle(int x1, int y1, int x2, int y2) { }

        public void DrawEllipse(int x1, int y1, int x2, int y2) { }


        public void DrawArc(int x1, int y1, int x2, int y2, int deg1, int deg2) { }


        public void DrawString(string text, int x, int y) { }


        public void DrawPolygon(int x, int y, int w, int h) { }

        public void DrawBounding(int x1, int y1, int x2, int y2) { }

        public void DrawDot(int x1, int y1) { }


    }
}
