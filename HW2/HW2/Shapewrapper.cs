using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Wrapper class to store the shape and its properties
    public class ShapeWrapper
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Shape Shape { get; set; }
    }
}
