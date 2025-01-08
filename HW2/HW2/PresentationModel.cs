using HW2;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

public class PresentationModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private bool isStartChecked = false;
    private bool isTerminatorChecked = false;
    private bool isProcessChecked = false;
    private bool isDecisionChecked = false;
    private bool isSelectedChecked = true;
    private bool isLineChecked = false;

    private readonly Model _model;

    private Cursor _cursor;

    private string _shape = "";
    private string _text;
    private string _x;
    private string _y;
    private string _width;
    private string _height;

    private bool _isAddEnabled;
    public bool IsAddEnabled
    {
        get { return _isAddEnabled; }
        private set
        {
            if (_isAddEnabled != value)
            {
                _isAddEnabled = value;
                Notify(nameof(IsAddEnabled));
            }
        }
    }

    public PresentationModel(Model model)
    {
        this._model = model;
        _model.ModelChanged += UpdateState;
    }

    public bool IsStartChecked() => isStartChecked;
    public bool IsTerminatorChecked() => isTerminatorChecked;
    public bool IsProcessChecked() => isProcessChecked;
    public bool IsDecisionChecked() => isDecisionChecked;
    public bool IsSelectedChecked() => isSelectedChecked;
    public bool IsLineChecked() => isLineChecked;
    public void StartPressed() => _model.SetDrawingMode("Start");
    public void TerminatorPressed() => _model.SetDrawingMode("Terminator");
    public void ProcessPressed() => _model.SetDrawingMode("Process");
    public void DecisionPressed() => _model.SetDrawingMode("Decision");
    public void SelectPressed() => _model.SetSelectMode();
    public void LinePressed() => _model.SetLineMode("Line");
    public void TextChange(Shape shape, string text) => _model.ChangeText(shape, text);

    public void XChanged(string x)
    {
        _x = x;
        UpdateIsAddEnabled();
    }

    public void YChanged(string y)
    {
        _y = y;
        UpdateIsAddEnabled();
    }

    public void WidthChanged(string width)
    {
        _width = width;
        UpdateIsAddEnabled();
    }

    public void HeightChanged(string height)
    {
        _height = height;
        UpdateIsAddEnabled();
    }

    public void ShapeChanged(string shape)
    {
        _shape = shape;
        UpdateIsAddEnabled();
    }

    public void TextChanged(string text)
    {
        _text = text;
        UpdateIsAddEnabled();
    }

    public bool IsXValid()
    {
        try
        {
            int X = Convert.ToInt32(_x);
            return X > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool IsYValid()
    {
        try
        {
            int Y = Convert.ToInt32(_y);
            return Y > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool IsWidthValid()
    {
        try
        {
            int W = Convert.ToInt32(_width);
            return W > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool IsHeightValid()
    {
        try
        {
            int H = Convert.ToInt32(_height);
            return H > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool IsShapeValid() => _shape == "Start" || _shape == "Terminator" || _shape == "Process" || _shape == "Decision";
    public bool IsTextValid() => !string.IsNullOrEmpty(_text);

    private void Notify(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void UpdateIsAddEnabled()
    {
        IsAddEnabled = IsXValid() && IsYValid() && IsWidthValid() && IsHeightValid() && IsShapeValid() && IsTextValid();
        Notify("IsAddEnabled");
    }

    public Color XLabelColor() => IsXValid() ? Color.Black : Color.Red;
    public Color YLabelColor() => IsYValid() ? Color.Black : Color.Red;
    public Color WidthLabelColor() => IsWidthValid() ? Color.Black : Color.Red;
    public Color HeightLabelColor() => IsHeightValid() ? Color.Black : Color.Red;
    public Color ShapeNameColor() => IsShapeValid() ? Color.Black : Color.Red;
    public Color TextColor() => IsTextValid() ? Color.Black : Color.Red;

    public Cursor CursorType() => _cursor;

    public void UpdateState()
    {
        string mode = _model.GetMode();
        _cursor = mode != "" ? Cursors.Cross : Cursors.Default;

        isStartChecked = mode == "Start";
        isTerminatorChecked = mode == "Terminator";
        isProcessChecked = mode == "Process";
        isDecisionChecked = mode == "Decision";
        isSelectedChecked = mode == "";
        isLineChecked = mode == "Line";


    }

    public void AddShape() => _model.AddShape(_shape, _text, Convert.ToInt32(_x), Convert.ToInt32(_y), Convert.ToInt32(_width), Convert.ToInt32(_height));

    public void Undo()
    {
        _model.Undo();
    }

    public void Redo()
    {
        _model.Redo();
    }

    public bool IsUndoClickable()
    {
        return _model.CanUndo();
    }

    public bool IsRedoClickable()
    {
        return _model.CanRedo();
    }

    public void ManageBackupFiles(string backupFolder)
    {
        var backupFiles = new DirectoryInfo(backupFolder).GetFiles()
            .OrderByDescending(f => f.CreationTime)
            .Skip(5)
            .ToList();

        foreach (var file in backupFiles)
        {
            file.Delete();
        }
    }
    public void AutoSaveAsync(string originalTitle)
    {
        if (_model.HasChanges)
        {
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
            Directory.CreateDirectory(backupFolder);

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string backupFileName = $"{timestamp}_bak.p0n3";
            string backupFilePath = Path.Combine(backupFolder, backupFileName);

            SaveAsync(backupFilePath);
            ManageBackupFiles(backupFolder);


        }
    }


    public void SaveAsync(string filePath)
    {

        Thread.Sleep(3000);
        // Create a StringBuilder to build the custom format string
        var sb = new StringBuilder();

        // Add shapes to the string
        sb.AppendLine("Shape ID X Y W H Text");
        List<Task> shapeTasks = new List<Task>();
        foreach (var shape in _model.GetShapes())
        {
            shapeTasks.Add(Task.Run(() =>
            {
                if (shape.ShapeName != "Line")
                {
                    sb.AppendLine($"{shape.ShapeName} {shape.ID} {shape.X} {shape.Y} {shape.W} {shape.H} {shape.Text}");
                }
            }));
        }

        // Wait for all shape tasks to complete
        Task.WaitAll(shapeTasks.ToArray());

        // Add lines to the string (assuming you have a way to get lines and their connections)
        sb.AppendLine("---------");
        sb.AppendLine("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2");
        List<Task> lineTasks = new List<Task>();
        foreach (var shape in _model.GetShapes().OfType<Line>()) // Assuming LineShape is a subclass of Shape
        {
            lineTasks.Add(Task.Run(() =>
            {
                var (connShapeId1, connPoint1) = (shape.Shape1.ID, shape.Connection1);
                var (connShapeId2, connPoint2) = (shape.Shape2.ID, shape.Connection2);
                sb.AppendLine($"Line {shape.ID} {connShapeId1} {connPoint1} {connShapeId2} {connPoint2}");
            }));
        }

        // Wait for all line tasks to complete
        Task.WaitAll(lineTasks.ToArray());

        sb.AppendLine("---------");
        // Write the formatted string to the file
        File.WriteAllText(filePath, sb.ToString());

        _model.HasChanges = false;
        // Log success message
        Console.WriteLine("Save completed successfully.");

    }


    public void Load(string filePath)
    {

        Thread.Sleep(3000);
        // Read the file content
        var lines = File.ReadAllLines(filePath);

        // Clear existing shapes
        _model.Shapes = new Shapes();

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

                var shape = _model.Shapes.NewShape(shapeName, text, x, y, w, h);
                shape.ID = id; // Set the ID explicitly
                _model.Shapes.AddShape(shape);
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
                lineShape.SetConnection1(_model.Shapes.GetShape(connShapeId1), connPoint1);
                lineShape.SetConnection2(_model.Shapes.GetShape(connShapeId2), connPoint2);
                _model.Shapes.AddShape(lineShape);
            }
            i++;
        }

        // Notify observers
        _model.NotifyObserver();

        // Log success message
        Console.WriteLine("Load completed successfully.");

    }
}

