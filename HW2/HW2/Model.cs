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
        public delegate void ModelChangedEventHandler();
        public Shapes Shapes = new Shapes();
        private string _mode = "";

        private bool _hasChanges;
        public bool HasChanges => _hasChanges;

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
            return Shapes.GetShapes().FirstOrDefault(s => s.ID == id);
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
            _hasChanges = true;
            ModelChanged?.Invoke();
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

        public async Task SaveAsync(string filePath)
        {
            await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(3000);
                    // Create a StringBuilder to build the custom format string
                    var sb = new StringBuilder();

                    // Add shapes to the string
                    sb.AppendLine("Shape ID X Y W H Text");
                    foreach (var shape in Shapes.GetShapes())
                    {
                        if (shape.ShapeName != "Line")
                        {
                            sb.AppendLine($"{shape.ShapeName} {shape.ID} {shape.X} {shape.Y} {shape.W} {shape.H} {shape.Text}");
                        }
                    }

                    // Add lines to the string (assuming you have a way to get lines and their connections)
                    sb.AppendLine("---------");
                    sb.AppendLine("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2");
                    foreach (var shape in Shapes.GetShapes().OfType<Line>()) // Assuming LineShape is a subclass of Shape
                    {
                        var (connShapeId1, connPoint1) = (shape.Shape1.ID, shape.Connection1);
                        var (connShapeId2, connPoint2) = (shape.Shape2.ID, shape.Connection2);
                        sb.AppendLine($"Line {shape.ID} {connShapeId1} {connPoint1} {connShapeId2} {connPoint2}");
                    }
                    sb.AppendLine("---------");
                    // Write the formatted string to the file
                    File.WriteAllText(filePath, sb.ToString());

                    _hasChanges = false;
                    // Log success message
                    Console.WriteLine("Save completed successfully.");
                }
                catch (Exception ex)
                {
                    // Log error message
                    Console.WriteLine($"Failed to save the file. Error: {ex.Message}");
                }
            });
        }



        public void Load(string filePath)
        {
            try
            {
                Thread.Sleep(3000);
                // Read the file content
                var lines = File.ReadAllLines(filePath);

                // Clear existing shapes
                Shapes = new Shapes();

                // Parse shapes
                int i = 1; // Start after the header line
                while (i < lines.Length && !lines[i].StartsWith("---------"))
                {
                    var parts = lines[i].Split(' ');
                    if (parts.Length >= 7)
                    {
                        string shapeName = parts[0];
                        int id = int.Parse(parts[1]);
                        int x = int.Parse(parts[2]);
                        int y = int.Parse(parts[3]);
                        int w = int.Parse(parts[4]);
                        int h = int.Parse(parts[5]);
                        string text = parts[6];

                        var shape = Shapes.NewShape(shapeName, text, x, y, w, h);
                        shape.ID = id; // Set the ID explicitly
                        Shapes.AddShape(shape);
                    }
                    i++;
                }

                // Parse lines (connections)
                i += 2; // Skip the "---------" line and the header line for lines
                while (i < lines.Length && !lines[i].StartsWith("---------"))
                {
                    var parts = lines[i].Split(' ');
                    if (parts.Length >= 6)
                    {
                        int id = int.Parse(parts[1]);
                        int connShapeId1 = int.Parse(parts[2]);
                        int connPoint1 = int.Parse(parts[3]);
                        int connShapeId2 = int.Parse(parts[4]);
                        int connPoint2 = int.Parse(parts[5]);


                        var lineShape = new Line("Line", "", id, 0, 0, 0, 0); // Assuming Line is a subclass of Shape
                        lineShape.SetConnection1(Shapes.GetShape(connShapeId1), connPoint1);
                        lineShape.SetConnection2(Shapes.GetShape(connShapeId2), connPoint2);
                        Shapes.AddShape(lineShape);
                    }
                    i++;
                }

                // Notify observers
                NotifyObserver();

                // Log success message
                Console.WriteLine("Load completed successfully.");
            }
            catch (Exception ex)
            {
                // Log error message
                Console.WriteLine($"Failed to load the file. Error: {ex.Message}");
            }
        }


    }

}