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
        private Igraphic graphic;

        // Constructor
        public Shapes()
        {
            _shapeList = new List<ShapeWrapper>();

        }

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            // Create shape using ShapeFactory
            Shape shape = ShapeFactory.CreateShape(shapeName, x, y, width, height,graphic);
            var shapeWrapper = new ShapeWrapper
            {
                Id = NewId(),
                Text = text,
                Shape = shape
            };
            _shapeList.Add(shapeWrapper);
        }

        public void PreviewShape(string shapeName, int click_x, int click_y, int mouse_x, int mouse_y)
        {
            Shape shape = ShapeFactory.CreateShape(shapeName, click_x, click_y, mouse_x - click_x, mouse_y - click_y, graphic);
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