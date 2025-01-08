using System;
using HW2;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace HW2
{

    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public event Action<Shape> TextChangeRequested;
        public delegate void ModelChangedEventHandler();
        public Shapes Shapes = new Shapes();
        private string _mode = "";

        public bool HasChanges;

        private readonly IState _pointState;
        private readonly IState _drawState;
        private readonly IState _lineState;
        public IState CurrentState;

        private readonly CommandManager _commandManager;

        public Model()
        {
            _pointState = new PointState();
            _drawState = new DrawState();
            _lineState = new DrawLineState();
            CurrentState = _pointState;
            _commandManager = new CommandManager();
        }
        public void AddShapeObj(Shape shape)
        {
            Shapes.AddShape(shape);
            NotifyObserver();
        }

        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            var shape = Shapes.NewShape(shapeName, text, x, y, width, height);
            _commandManager.ExecuteCommand(new AddCommand(this, shape));
        }

        public void AddLine(Shape shape)
        {
            _commandManager.ExecuteCommand(new DrawCommand(this, shape));
        }
        // Remove shape from list
        public void RemoveShape(int id)
        {
            var shape = GetShape(id);
            if (shape == null) return;
            var deleteCommand = new DeleteCommand(this, shape);
            _commandManager.ExecuteCommand(deleteCommand);
        }

        public Shape GetShape(int id)
        {
            return Shapes.GetShape(id);
        }

        public Shape GetNewShape(string shapeName, string text, int x, int y, int width, int height)
        {
            return Shapes.NewShape(shapeName, text, x, y, width, height);
        }


        public void RemoveShape(Shape shape)
        {
            Shapes.DeleteShape(shape.ID);
            SetPointState();
            NotifyObserver();
        }

        public void Draw(IGraphic graphic)
        {
            CurrentState.Draw(graphic);
        }

        public void SetDrawingMode(string shape)
        {
            _mode = shape;
            SetDrawState();
            NotifyObserver();
        }

        public void SetLineMode(string shape)
        {
            _mode = shape;
            SetLineState();
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
            CurrentState.MouseDown(x, y);
        }

        public void PointerMove(int x, int y)
        {
            CurrentState.MouseMove(x, y);
        }

        public void PointerUp(int x, int y)
        {
            CurrentState.MouseUp(x, y);
        }

        public void SetPointState()
        {
            _pointState.Initialize(this);
            CurrentState = _pointState;
        }

        public void SetDrawState()
        {
            _drawState.Initialize(this);
            CurrentState = _drawState;
        }

        public void SetLineState()
        {
            _lineState.Initialize(this);
            CurrentState = _lineState;
        }

        public void MoveShape(Shape shape, int initX, int initY)
        {
            var moveCommand = new MoveCommand(shape, initX, initY, shape.X, shape.Y);
            _commandManager.ExecuteCommand(moveCommand);
            NotifyObserver();
        }

        public void MoveText(Shape shape, int initBiasX, int initBiasY)
        {
            var textMoveCommand = new TextMoveCommand(shape, initBiasX, initBiasY, shape.BiasX, shape.BiasY);
            _commandManager.ExecuteCommand(textMoveCommand);
            NotifyObserver();
        }

        public void ChangeText(Shape shape, string text)
        {
            var textChangeCommand = new TextChangedCommand(shape, shape.Text ,text);
            _commandManager.ExecuteCommand(textChangeCommand);
            NotifyObserver();
        }

        public void PointerDoubleClick(int x, int y)
        {
            CurrentState.MouseDoubleClick(x, y);
        }


        // Get shape list for UI
        public List<Shape> GetShapes()
        {
            return Shapes.GetShapes();
        }

        public void NotifyObserver()
        {
            HasChanges = true;
            ModelChanged?.Invoke();
        }

        public void NotifyTextChangeRequested(Shape shape)
        {
            TextChangeRequested?.Invoke(shape);
        }

        public string GetMode()
        {
            return _mode;
        }

        public int GetNewId()
        {
            return Shapes.NewId();
        }

        public void Undo()
        {
            _commandManager.Undo();
            NotifyObserver();
        }

        public void Redo()
        {
            _commandManager.Redo();
            NotifyObserver();
        }

        public bool CanUndo() => _commandManager.CanUndo;
        public bool CanRedo() => _commandManager.CanRedo;
        

    }

}