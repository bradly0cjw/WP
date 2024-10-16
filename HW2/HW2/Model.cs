using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        private Shapes shapes = new Shapes();

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            shapes.AddShape(shapeName, text,  x,  y, width,  height);
        }

        // Remove shape from list
        public void RemoveShape(int id)
        {
            shapes.DeleteShape(id);
        }

        // Get shape list for UI
        public List<ShapeWrapper> GetShapes()
        {
            return shapes.GetShapes();
        }
    }
    
}