using System;
using System.Collections.Generic;
using System.Linq;

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
        public IState _currentState;

        private readonly CommandManager _commandManager;

        public Model()
        {
            _pointState = new PointState();
            _drawState = new DrawState();
            _currentState = _pointState;
            _commandManager = new CommandManager();
        }

        // Add shape to list
        public void AddShape(Shape shape)
        {
            Shapes.AddShape(shape.ShapeName, shape.Text, shape.X, shape.Y, shape.W, shape.H);
            NotifyObserver();
        }

        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            var shape = Shapes.NewShape(shapeName, text, x, y, width, height);
            AddShape(shape);
        }

        // Remove shape from list
        public void RemoveShape(int id)
        {
            Shapes.DeleteShape(id);
            NotifyObserver();
        }

        public void Draw(IGraphic graphic)
        {
            _currentState.Draw(graphic);
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

        public void MoveShape(Shape shape, int newX, int newY)
        {
            var moveCommand = new MoveCommand(shape, this, shape.X, shape.Y, newX, newY);
            _commandManager.ExecuteCommand(moveCommand);
            NotifyObserver();
        }

        public void MoveText(Shape shape, int newBiasX, int newBiasY)
        {
            var textMoveCommand = new TextMoveCommand(this, shape, shape.BiasX, shape.BiasY, newBiasX, newBiasY);
            _commandManager.ExecuteCommand(textMoveCommand);
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

        public void Undo()
        {
            _commandManager.Undo();
            NotifyObserver();
        }
    }
}
