using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        private Shapes shapes = new Shapes();

        // Add shape to list
        public int AddShape(ShapeData shapeData)
        {
            try
            {
                Shape shape = ShapeFactory.CreateShape(shapeData.ShapeType, shapeData.Text, shapeData.X, shapeData.Y, shapeData.Width, shapeData.Height);
                shapes.AddShape(shape, shapeData.ShapeType);
            }
            catch (FormatException)
            {
                // Handle parsing errors
                return 2;
            }
            catch (Exception)
            {
                // Handle other errors (e.g., from ShapeFactory)
                return 1;
            }
            return 0;
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