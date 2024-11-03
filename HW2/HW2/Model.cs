using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        private Shapes shapes = new Shapes();
        private int mouse_x, mouse_y, mouse_ix, mouse_iy;
        private bool _ispress = false;
        private string _mode = "";
        private Shape _hint;

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            shapes.AddShape(shapeName, text, x, y, width, height);
        }

        public void PreviewShape(string shapeName)
        {
            _hint = shapes.PreviewShape(shapeName, mouse_ix, mouse_iy, mouse_x, mouse_y);
        }

        public void Draw(Igraphic graphic)
        {
            graphic.ClearAll();
            foreach (var shape in shapes.GetShapes())
            {
                shape.Shape.Draw(graphic);
            }

            if (_ispress)
            {
                _hint.Draw(graphic);
            }
        }

        public void MouseMoveHandler(int x, int y)
        {
            mouse_x = x;
            mouse_y = y;
            if (_ispress)
            {
                PreviewShape(_mode);
                NotifyObserver();

            }
        }

        public void MouseDownHandeler(int x, int y)
        {
            mouse_x = x;
            mouse_y = y;
            mouse_ix = x;
            mouse_iy = y;
            _ispress = true;
            PreviewShape(_mode);
            NotifyObserver();
        }

        public void SetMode(string s)
        {
            _mode = s;
        }
        public void MouseUpHandeler(int x, int y)
        {
            _ispress = false;
            shapes.AddShape(_mode, "", mouse_ix, mouse_iy, mouse_x, mouse_y);
            NotifyObserver();
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

        void NotifyObserver()
        {
            if (ModelChanged != null)
                ModelChanged();
        }
    }

}