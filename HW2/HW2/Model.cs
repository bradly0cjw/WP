using System;
using HW2;
using System.Collections.Generic;
using System.Linq;

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
        _commandManager.ExecuteCommand(new AddCommand(this, shape));
        //AddShape(shape);
    }

    // Remove shape from list
    public void RemoveShape(int id)
    {
        var shape = Shapes.GetShapes().FirstOrDefault(s => s.ID == id);
        if (shape != null)
        {
            var deleteCommand = new DeleteCommand(this, shape);
            _commandManager.ExecuteCommand(deleteCommand);
        }
    }

    public void RemoveShape(Shape shape)
    {
        Shapes.DeleteShape(shape.ID);
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

    public void MoveShape(Shape shape, int initX, int initY)
    {
        var moveCommand = new MoveCommand(this, shape, initX, initY, shape.X, shape.Y);
        Console.WriteLine("Old Pos: " + initX + " " + initY);
        Console.WriteLine("New Pos: " + shape.X + " " + shape.Y);
        _commandManager.ExecuteCommand(moveCommand);
        NotifyObserver();
    }

    public void MoveText(Shape shape, int initBiasX, int initBiasY)
    {
        var textMoveCommand = new TextMoveCommand(this, shape, initBiasX, initBiasY, shape.BiasX, shape.BiasY);
        Console.WriteLine("Old Pos: " + initBiasX + " " + initBiasY);
        Console.WriteLine("New Pos: " + shape.BiasX + " " + shape.BiasY);
        _commandManager.ExecuteCommand(textMoveCommand);
        NotifyObserver();
    }

    public void ChangeText(Shape shape, string text)
    {
        var textChangeCommand = new TextChangedCommand(this, shape, shape.Text, text);
        _commandManager.ExecuteCommand(textChangeCommand);
        NotifyObserver();
    }

    public void PointerDoubleClick(int x, int y)
    {
        _currentState.MouseDoubleClick(x, y);
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

    public void Redo()
    {
        _commandManager.Redo();
        NotifyObserver();
    }

    public bool CanUndo() => _commandManager.CanUndo;
    public bool CanRedo() => _commandManager.CanRedo;
}
