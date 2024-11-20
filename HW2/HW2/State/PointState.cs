using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class PointState : IState
    {
        Model _model;

        private int _preX;
        private int _preY;
        private bool _isPressed = false;
        private Shape selectedShape;
        public PointState()
        {
        }

        public void Initialize(Model model)
        {
            this._model = model;
            selectedShape = null;
        }


        public void MouseDown(int x, int y)
        {
            foreach (Shape _shape in Enumerable.Reverse(_model.GetShapes()))
            {
                if (_shape.IsClickInShape(x, y))
                {
                    selectedShape = _shape;
                    _isPressed = true;
                    _preX = x;
                    _preY = y;
                    _model.NotifyObserver();
                    return;
                }
            }

            selectedShape = null;
            _model.NotifyObserver();
        }
        public void MouseMove(int x, int y)
        {
            if (_isPressed)
            {
                int dx = x - _preX;
                int dy = y - _preY;
                selectedShape.X += dx;
                selectedShape.Y += dy;
                _preX = x;
                _preY = y;
                _model.NotifyObserver();
            }
        }
        public void MouseUp(int x, int y)
        {
            _isPressed = false;
        }
        public void Draw(IGraphic graphic)
        {
            graphic.ClearAll();
            // 畫出所有的Shape
            foreach (Shape _shape in _model.GetShapes())
            {
                _shape.Draw(graphic);
            }

            if (selectedShape != null)
            {
                selectedShape.DrawBounding(graphic);
            }

        }


    }
}
