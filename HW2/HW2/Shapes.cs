using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Shapes
    {
        private int uid = 0;
        // List to store different shapes
        private List<Shape> shapeList;

        public Shapes()
        {
            shapeList = new List<Shape>();
        }

        // Method to add a shape to the list
        public void AddShape (Shape shape)
        {
            shapeList.Add(shape);
        }

        // Method to get all shapes
        public List<Shape> GetShapes()
        {
            return shapeList;
        }
        // Delete a shape by ID
        public void DeleteShape(int id)
        {
            var shapeToRemove = shapeList.FirstOrDefault(s => s.Id == id);
            if (shapeToRemove != null)
            {
                shapeList.Remove(shapeToRemove);
            }
        }

        // Retrieve a specific shape by its ID
        public Shape GetShapeById(int id)
        {
            return shapeList.FirstOrDefault(s => s.Id == id);
        }

        // Count the total number of shapes
        public int NewId()
        {
            return uid++;
        }
    }
}
