using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class DrawState : IState
    {
        private Model _model;
        

        private int _initX;
        private int _initY;
        private bool _isPressed;

        Shape _hint;

        
        public void Initialize(Model model)
        {
            this._model = model;
            this._isPressed = false;
        }

        public void MouseDown(int x, int y)
        {
            _initX = x;
            _initY = y;
            _isPressed = true;
            _hint = _model.Shapes.NewShape(_model.GetMode(), "", _initX, _initY, 0, 0);
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed)
            {
                _hint.H = y - _initY;
                _hint.W = x - _initX;
                _model.NotifyObserver();
            }
        }

        public void MouseUp(int x, int y)
        {
            if (_isPressed)
            {
                _model.AddShape(_model.GetMode(), "", _initX, _initY, _hint.W, _hint.H);
                _isPressed = false;
                _model.SetSelectMode();
                _model.NotifyObserver();
            }
        }

        public void Draw(IGraphic graphic)
        {
            graphic.ClearAll();
            foreach (var shape in _model.GetShapes())
            {
                shape.Draw(graphic);
            }

            if (_isPressed)
            {
                _hint.Draw(graphic);
            }
        }


    }
}
