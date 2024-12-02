using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        public Shapes Shapes = new Shapes();
        private string _mode = "";

        private readonly IState _pointState;
        private readonly IState _drawState;
        private IState _currentState;


        public Model()
        {
            _pointState = new PointState();
            _drawState = new DrawState();
            _currentState = _pointState;
        }

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            Shapes.AddShape(shapeName, text, x, y, width, height);
            NotifyObserver();
        }

        public void Draw(IGraphic graphic)
        {
            _currentState.Draw(graphic);
        }

        public string GetCurrentMode()
        {
            return _mode;
        }
        public void SetDrawingMode(string shape)
        {
            _mode = shape;
            SetDrawState();
            NotifyObserver();
        }

        public void SetSelectMode()
        {
            _mode = "";
            SetPointState();
            NotifyObserver();
        }
        public void PointerDown(int x, int y)
        {
            _currentState.MouseDown(x, y);
        }
        public void PointerMove(int x, int y)
        {
            _currentState.MouseMove(x, y);
        }

        public void PointerUp(int x, int y)
        {
            _currentState.MouseUp(x, y);
        }

        public void SetPointState()
        {
            _pointState.Initialize(this);
            _currentState = _pointState;
        }

        public void SetDrawState()
        {
            _drawState.Initialize(this);
            _currentState = _drawState;
        }

        // Remove shape from list
        public void RemoveShape(int id)
        {
            Shapes.DeleteShape(id);
            NotifyObserver();
        }

        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return Shapes.GetShapes();
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