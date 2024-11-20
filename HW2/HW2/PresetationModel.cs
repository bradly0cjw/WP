using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public class PresetationModel : INotifyPropertyChanged
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

        public PresetationModel(Model model)
        {
            this._model = model;

            _model.ModelChanged += UpdateState;
        }

        public bool IsStartChecked()
        {
            return isStartChecked;
        }
        public bool IsTerminatorChecked()
        {
            return isTerminatorChecked;
        }
        public bool IsProcessChecked()
        {
            return isProcessChecked;
        }
        public bool IsDecisionChecked()
        {
            return isDecisionChecked;
        }
        public bool IsSelectedChecked()
        {
            return isSelectedChecked;
        }
        public void StartPressed()
        {
            _model.SetDrawingMode("Start");
        }

        public void TerminatorPressed()
        {
            _model.SetDrawingMode("Terminator");
        }

        public void ProcessPressed()
        {
            _model.SetDrawingMode("Process");
        }

        public void DecisionPressed()
        {
            _model.SetDrawingMode("Decision");
        }
        public void SelectPressed()
        {
            _model.SetSelectMode();
        }

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
        }

        public bool IsXValid()
        {
            try
            {
                if (int.Parse(_x) < 0)
                {
                    return false;
                }
                return true;
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
                if (int.Parse(_y) < 0)
                {
                    return false;
                }
                return true;
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
                if (int.Parse(_width) < 0)
                {
                    return false;
                }
                return true;
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
                if (int.Parse(_height) < 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsShapeValid()
        {
            if (_shape == "")
            {
                return false;
            }
            return true;
        }

        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateIsAddEnabled()
        {
            IsAddEnabled = IsXValid() && IsYValid() && IsWidthValid() && IsHeightValid() && IsShapeValid();
        }

        public Color XLabelColor()
        {
            if (IsXValid())
            {
                return Color.Black;
            }
            return Color.Red;
        }
        public Color YLabelColor()
        {
            if (IsYValid())
            {
                return Color.Black;
            }
            return Color.Red;
        }
        public Color WidthLabelColor()
        {
            if (IsWidthValid())
            {
                return Color.Black;
            }
            return Color.Red;
        }
        public Color HeightLabelColor()
        {
            if (IsHeightValid())
            {
                return Color.Black;
            }
            return Color.Red;
        }
        public Color ShapeNameColor()
        {
            if (IsShapeValid())
            {
                return Color.Black;
            }
            return Color.Red;
        }

        public Cursor CursorType()
        {
            return _cursor;
        }

        public void UpdateState()
        {
            string mode = _model.GetMode();
            if (mode != "")
            {
                _cursor = Cursors.Cross;
            }
            else
            {
                _cursor = Cursors.Default;
            }

            isStartChecked = mode == "Start";
            isTerminatorChecked = mode == "Terminator";
            isProcessChecked = mode == "Process";
            isDecisionChecked = mode == "Decision";
            isSelectedChecked = mode == "";
        }
        public void AddShape()
        {
            _model.AddShape(_shape, _text, int.Parse(_x), int.Parse(_y), int.Parse(_width), int.Parse(_height));
        }
    }
}
