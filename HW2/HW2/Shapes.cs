using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class ShapeWrapper
    {
        public int Id { get; set; }
        public string ShapeType { get; set; }
        public Shape Shape { get; set; }
    }
    public class Shapes
    {
        private int uid = 0;
        // List to store different shapes
        private List<ShapeWrapper> shapeList;

        public Shapes()
        {
            shapeList = new List<ShapeWrapper>();
        }

        // Method to add a shape to the list
        public void AddShape(Shape shape, string shapeType)
        {
            var shapeWrapper = new ShapeWrapper
            {
                Id = NewId(),
                ShapeType = shapeType,
                Shape = shape
            };
            shapeList.Add(shapeWrapper);
        }

        // Method to get all shapes
        public List<ShapeWrapper> GetShapes()
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
        public ShapeWrapper GetShapeById(int id)
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

