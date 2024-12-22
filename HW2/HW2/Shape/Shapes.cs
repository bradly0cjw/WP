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

        public void AddShape(Shape shape)
        {
            _shapeList.Add(shape);
            SortShapes();
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
            _shapeList.Remove(shapeToRemove);
        }


        // Sort shapes by ID
        public void SortShapes()
        {
            _shapeList.Sort((x, y) => x.ID.CompareTo(y.ID));
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