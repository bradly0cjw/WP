using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Shape class to store the properties of a shape
    public class Shape
    {
        //public int Id { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        //public Shape(int id, string shapeName , int x, int y, int height, int width)
        //{
        //    Id = id;
        //    ShapeName = shapeName;
        //    X = x;
        //    Y = y;
        //    Height = height;
        //    Width = width;
        //}
    }

    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        public Start()
        {
            
        }
    }
    public class Terminator : Shape
    {
        public Terminator()
        {

        }
    }
    public class Process : Shape
    {
        public Process()
        {

        }
    }
    public class Decision : Shape
    {
        public Decision()
        {

        }
    }
}
