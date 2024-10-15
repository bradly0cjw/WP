using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Model
    {
        private Shapes shapes = new Shapes();

        //add shape to list
        public int AddShape(string shapeSelect,string text,string x,string y,string h,string w)
        {
            int xPos = int.Parse(x);
            int yPos = int.Parse(y);
            int height = int.Parse(h);
            int width = int.Parse(w);
            try
            {
                Shape shape = ShapeFactory.CreateShape(shapeSelect, text, xPos, yPos, height, width);
                shapes.AddShape(shape,shapeSelect);
            }catch (Exception)
            {
                return 1;
            }
            return 0;
        }

        //remove shape from list
        public void RemoveShape(int id)
        {
            shapes.DeleteShape(id);
        }

        // Get shape list for UI
        public List<ShapeWrapper> UpdateShape()
        {
            return shapes.GetShapes();
        }
    }
}
