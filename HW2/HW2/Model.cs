using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        private readonly Shapes _shapes = new Shapes();
        private int _mouseX, _mouseY, _mouseIx, _mouseIy;
        private bool _ispress = false;
        private string _mode = "";
        private Shape _hint;

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("Width and height must be positive");
            }
            _shapes.AddShape(shapeName, text, x, y, width, height);
            NotifyObserver();
        }

        public void PreviewShape(string shapeName)
        {
            _hint = Shapes.PreviewShape(shapeName, "", 0, _mouseIx, _mouseIy, _mouseX, _mouseY);
        }


        public void Draw(IGraphic graphic)
        {
            graphic.ClearAll();
            foreach (var shape in _shapes.GetShapes())
            {
                shape.Draw(graphic);
            }

            if (_ispress)
            {
                _hint.Draw(graphic);
            }
        }

        public void MouseMoveHandler(int x, int y)
        {
            _mouseX = x;
            _mouseY = y;
            if (_ispress && _mode != "")
            {
                PreviewShape(_mode);
                NotifyObserver();

            }
        }

        public void MouseDownHandeler(int x, int y)
        {
            Console.WriteLine("Down");
            _mouseX = x;
            _mouseY = y;
            _mouseIx = x;
            _mouseIy = y;
            _ispress = true;
            if (_mode != "")
            {

                PreviewShape(_mode);
                NotifyObserver();
            }
        }

        public void SetMode(string s)
        {
            _mode = s;
        }
        public void MouseUpHandeler(int x, int y)
        {
            if (_mode != "")
            {

                _mouseX = x;
                _mouseY = y;
                Console.WriteLine("Up");
                _ispress = false;
                _shapes.AddShape(_mode, "", _mouseIx, _mouseIy, _mouseX - _mouseIx, _mouseY - _mouseIy);
                _mode = "";
                NotifyObserver();
            }
        }

        // Remove shape from list
        public void RemoveShape(int id)
        {
            _shapes.DeleteShape(id);
            NotifyObserver();
        }

        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return _shapes.GetShapes();
        }

        public void NotifyObserver()
        {
            ModelChanged?.Invoke();
        }

        public string GetMode()
        {
            return _mode;
        }

    }

}