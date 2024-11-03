using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HW2
{
    

    public class Shapes
    {
        private int _uid = 0;
        private readonly List<Shape> _shapeList;
        private Igraphic graphic;

        // Constructor
        public Shapes()
        {
            _shapeList = new List<Shape>();

        }

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            // Create shape using ShapeFactory
            Shape shape = ShapeFactory.CreateShape(shapeName,text,NewId(), x, y, width, height);
            _shapeList.Add(shape);
        }

        public Shape PreviewShape(string shapeName, string shapetext, int id, int click_x, int click_y, int mouse_x, int mouse_y)
        {
            Shape shape = ShapeFactory.CreateShape(shapeName, shapetext, id, click_x, click_y, mouse_x - click_x, mouse_y - click_y);
            return shape;
        }


        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return _shapeList;
        }

        // Remove shape from list
        public void DeleteShape(int id)
        {
            var shapeToRemove = _shapeList.FirstOrDefault(s => s.ID == id);
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