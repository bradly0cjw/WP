using HW2;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

public class PresentationModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private bool isStartChecked = false;
    private bool isTerminatorChecked = false;
    private bool isProcessChecked = false;
    private bool isDecisionChecked = false;
    private bool isSelectedChecked = true;
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

    public bool CanUndo => _model.CanUndo();
    public bool CanRedo => _model.CanRedo();

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

    public void StartPressed() => _model.SetDrawingMode("Start");
    public void TerminatorPressed() => _model.SetDrawingMode("Terminator");
    public void ProcessPressed() => _model.SetDrawingMode("Process");
    public void DecisionPressed() => _model.SetDrawingMode("Decision");
    public void SelectPressed() => _model.SetSelectMode();

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

    private void UpdateIsAddEnabled() => IsAddEnabled = IsXValid() && IsYValid() && IsWidthValid() && IsHeightValid() && IsShapeValid() && IsTextValid();

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
}
