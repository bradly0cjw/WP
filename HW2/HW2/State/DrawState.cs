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
        private string _random;

        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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
            _random = GenerateRandomText();
            _hint = _model.Shapes.NewShape(_model.GetMode(), _random, _initX, _initY, 0, 0);
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed)
            {
                int newWidth = x - _initX;
                int newHeight = y - _initY;

                if (newWidth < 0)
                {
                    _hint.X = x;
                    _hint.W = -newWidth;
                }
                else
                {
                    _hint.X = _initX;
                    _hint.W = newWidth;
                }

                if (newHeight < 0)
                {
                    _hint.Y = y;
                    _hint.H = -newHeight;
                }
                else
                {
                    _hint.Y = _initY;
                    _hint.H = newHeight;
                }

                _model.NotifyObserver();
            }
        }

        public void MouseUp(int x, int y)
        {
            if (_isPressed)
            {
                _hint.Normalize();
                _model.AddShape(_model.GetMode(), _random, _hint.X, _hint.Y, _hint.W, _hint.H);
                _isPressed = false;
                _model.SetSelectMode();
                _model.NotifyObserver();
            }
        }

        public void MouseDoubleClick(int x, int y)
        {
            Console.WriteLine();
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

        public string GenerateRandomText()
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

    }
}
