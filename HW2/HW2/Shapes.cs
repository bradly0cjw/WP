using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HW2
{
    

    public class Shapes
    {
        private int _uid = 0;
        private readonly List<ShapeWrapper> _shapeList;

        // Constructor
        public Shapes()
        {
            _shapeList = new List<ShapeWrapper>();
        }

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            // Create shape using ShapeFactory
            Shape shape = ShapeFactory.CreateShape(shapeName, x, y, width, height);
            var shapeWrapper = new ShapeWrapper
            {
                Id = NewId(),
                Text = text,
                Shape = shape
            };
            _shapeList.Add(shapeWrapper);
        }

        // Get shape list for UI
        public List<ShapeWrapper> GetShapes()
        {
            return _shapeList;
        }

        // Remove shape from list
        public void DeleteShape(int id)
        {
            var shapeToRemove = _shapeList.FirstOrDefault(s => s.Id == id);
            if (shapeToRemove != null)
            {
                _shapeList.Remove(shapeToRemove);
            }
        }

        // Generate new id for shape
        public int NewId()
        {
            return _uid++;
        }

        // Draw shape by id 
        // This method is not used in the current implementation
        // Polymorphism is used to draw shapes in the UI
        //public void DrawShape(int id)
        //{
        //    var shapeToDraw = _shapeList.FirstOrDefault(s => s.Id == id);
        //    shapeToDraw?.Shape.Draw();
        //}
    }
}