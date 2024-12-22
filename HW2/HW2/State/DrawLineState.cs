using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class DrawLineState : IState
    {
        private Model _model;
        private int _init;
        private Shape _hoverShape;
        private Shape _selectShape;
        private Shape _hint;

        public void Initialize(Model model)
        {
            this._model = model;
        }

        public void MouseDown(int x, int y)
        {
            int tempX, tempY;
            if (_hoverShape != null)
            {
                _init = _hoverShape.IsClickConnectionPoint(x, y);
            }
            else
            {
                _init = -1;
            }
            if (_init != -1)
            {
                _selectShape = _hoverShape;
                (tempX, tempY) = _selectShape.GetConnectionPoint(_init);
                _hint = _model.Shapes.NewShape(_model.GetMode(), "", tempX, tempY, 0, 0);

            }
        }

        public void MouseMove(int x, int y)
        {
            if (_selectShape != null)
            {
                _hint.W = x;
                _hint.H = y;
                _model.NotifyObserver();
            }
            foreach (Shape shape in Enumerable.Reverse(_model.GetShapes()))
            {
                if (shape.IsClickInShape(x, y))
                {
                    _hoverShape = shape;
                    _model.NotifyObserver();
                    return;
                }

            }
        }

        public void MouseUp(int x, int y)
        {
            if (_selectShape != null)
            {
                if (_selectShape != _hoverShape && _hoverShape != null)
                {
                    int tempX, tempY;
                    int end = _hoverShape.IsClickConnectionPoint(x, y);
                    if (end != -1)
                    {
                        (tempX, tempY) = _hoverShape.GetConnectionPoint(end);


                        var line = new Line("Line", "", _model.GetNewId(), _hint.X, _hint.Y, tempX, tempY);

                        //flags 1
                        line.SetConnection1(_selectShape, _init);
                        line.SetConnection2(_hoverShape, end);

                        Console.WriteLine(line);
                        _model.AddLine(line);
                    }
                    Console.WriteLine("@@@");
                }
                _selectShape = null;
                _hint = null;
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

            _hoverShape?.DrawConnectionPoint(graphic);
            _hint?.Draw(graphic);
        }

        public void MouseDoubleClick(int x, int y)
        {
            Console.WriteLine("Not implement");
        }

    }
}
