using System;
using System.Collections.Generic;

namespace HW2
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        public Shapes shapes = new Shapes();
        private int _mouseX, _mouseY, _mouseIx, _mouseIy;
        private bool _ispress = false;
        private string _mode = "";
        private Shape _hint;

        private IState pointState;
        private IState drawState;
        private IState currentState;


        public Model()
        {
            pointState = new PointState();
            drawState = new DrawState((PointState)pointState);
            currentState = pointState;
        }

        // Add shape to list
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            shapes.AddShape(shapeName, text, x, y, width, height);
            NotifyObserver();
        }

        public void Draw(IGraphic graphic)
        {
            currentState.Draw(graphic);
        }



        public void SetDrawingMode(string shape)
        {
            _mode = shape;
            setDrawState();
            NotifyObserver();
        }

        public void SetSelectMode()
        {
            _mode = "";
            setPointState();
            NotifyObserver();
        }
        public void PointerDown(int x, int y)
        {
            currentState.MouseDown(x,y);
        }
        public void PointerMove(int x, int y)
        {
            currentState.MouseMove(x, y);
        }

        public void PointerUp(int x, int y)
        {
            currentState.MouseUp(x, y);
        }

        public void setPointState()
        {
            
            pointState.Initialize(this);
            currentState = pointState;
        }

        public void setDrawState()
        {
            drawState.Initialize(this);
            currentState = drawState;
        }
        //public void MouseMoveHandler(int x, int y)
        //{
        //    _mouseX = x;
        //    _mouseY = y;
        //    if (_ispress && _mode != "")
        //    {
        //        PreviewShape(_mode);
        //        NotifyObserver();

        //    }
        //}

        //public void MouseDownHandeler(int x, int y)
        //{
        //    Console.WriteLine("Down");
        //    _mouseX = x;
        //    _mouseY = y;
        //    _mouseIx = x;
        //    _mouseIy = y;
        //    _ispress = true;
        //    if (_mode != "")
        //    {

        //        PreviewShape(_mode);
        //        NotifyObserver();
        //    }
        //}

        //public void SetMode(string s)
        //{
        //    _mode = s;
        //}
        //public void MouseUpHandeler(int x, int y)
        //{
        //    if (_mode != "")
        //    {

        //        _mouseX = x;
        //        _mouseY = y;
        //        Console.WriteLine("Up");
        //        _ispress = false;
        //        _shapes.AddShape(_mode, "", _mouseIx, _mouseIy, _mouseX - _mouseIx, _mouseY - _mouseIy);
        //        _mode = "";
        //        NotifyObserver();
        //    }
        //}

        // Remove shape from list
        public void RemoveShape(int id)
        {
            shapes.DeleteShape(id);
            NotifyObserver();
        }

        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
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