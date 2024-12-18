using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public class PointState : IState
    {
        Model _model;

        private int _preX;
        private int _preY;
        private int _initX;
        private int _initY;
        private int _initBiasX;
        private int _initBiasY;
        private bool _isPressed = false;
        private bool _isTextClicked = false;

        public Shape SelectedShape;
        public PointState()
        {
        }

        public void Initialize(Model model)
        {
            this._model = model;
            SelectedShape = null;
        }


        public void MouseDown(int x, int y)
        {
            foreach (Shape shape in Enumerable.Reverse(_model.GetShapes()))
            {
                if (shape.IsClickInShape(x, y))
                {
                    SelectedShape = shape;
                    _isPressed = true;
                    _preX = x;
                    _preY = y;
                    _initX = shape.X;
                    _initY = shape.Y;
                    _initBiasX = shape.BiasX;
                    _initBiasY = shape.BiasY;
                    if (shape.IsClickOnText(x, y))
                    {
                        _isTextClicked = true;
                    }
                    _model.NotifyObserver();
                    return;
                }
            }


            SelectedShape = null;
            _model.NotifyObserver();
        }
        public void MouseMove(int x, int y)
        {
            if (_isTextClicked)
            {
                int dx = x - _preX;
                int dy = y - _preY;
                SelectedShape.BiasX += dx;
                SelectedShape.BiasY += dy;
                _preX = x;
                _preY = y;
                _model.NotifyObserver();
            }
            else if (_isPressed)
            {
                int dx = x - _preX;
                int dy = y - _preY;
                SelectedShape.X += dx;
                SelectedShape.Y += dy;
                _preX = x;
                _preY = y;
                _model.NotifyObserver();
            }
        }
        public void MouseUp(int x, int y)
        {
            if (_isTextClicked)
            {
               _model.MoveText(SelectedShape,_initBiasX,_initBiasY);

            }
            else if (_isPressed)
            {
                _model.MoveShape(SelectedShape,_initX,_initY);
            }
            _isPressed = false;
            _isTextClicked = false;
        }

        public void MouseDoubleClick(int x, int y)
        {
            if (_isTextClicked && SelectedShape != null)
            {
                using (var dialog = new 文字編輯方塊(SelectedShape.Text))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _model.ChangeText(SelectedShape,dialog.NewText);
                    }
                }
            }
        }

        public void Draw(IGraphic graphic)
        {
            graphic.ClearAll();
            // 畫出所有的Shape
            foreach (Shape shape in _model.GetShapes())
            {
                shape.Draw(graphic);
            }

            if (SelectedShape != null)
            {
                SelectedShape.DrawBounding(graphic);
            }

        }


    }
}
