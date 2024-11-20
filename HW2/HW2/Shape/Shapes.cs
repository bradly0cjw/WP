using System;
using System.Collections.Generic;

using System.Linq;

namespace HW2
{
    

    public class Shapes
    {
        private readonly List<Shape> _shapeList;

        // Constructor
        public Shapes()
        {
            _shapeList = new List<Shape>();

        }

        //Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            // Create shape using ShapeFactory
            _shapeList.Add(NewShape(shapeName, text, x, y, width, height));
        }

        public Shape NewShape(string shapeName, string text, int x, int y, int width, int height)
        {
            return ShapeFactory.CreateShape(shapeName, text, NewId(), x, y, width, height);

        }



        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return _shapeList;
        }

        // Remove shape from list
        public void DeleteShape(int id)
        {
            var shapeToRemove = _shapeList.Find(s => s.ID == id);
            if (shapeToRemove != null)
            {
                _shapeList.Remove(shapeToRemove);
            }
        }

        // Generate new id for shape
        public int NewId()
        {
            if (_shapeList.Count == 0)
            {
                return 0;
            }

            return _shapeList.Last().ID + 1;
        }

    }
}