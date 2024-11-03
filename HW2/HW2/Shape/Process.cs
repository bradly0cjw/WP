using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Process : Shape
    {
        // Constructor
        public Process(string shapeName, int x, int y, int width, int height) : base(shapeName, x, y, width, height) { }

        // Draw method
        public override void Draw(int x, int y, int w, int h)
        {
            Console.WriteLine($"Drawing Process shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}
