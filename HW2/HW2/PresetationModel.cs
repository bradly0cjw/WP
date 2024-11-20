using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class PresetationModel
    {
        private bool isStartChecked = false;
        private bool isTerminatorChecked = false;
        private bool isProcessChecked = false;
        private bool isDecisionChecked = false;
        private bool isSelectedChecked = true;
        private bool isAddEnable = false;
        private readonly Model _model;

        private string _shape="";
        private string _text;
        private string _x;
        private string _y;
        private string _width;
        private string _height;


        public PresetationModel(Model model)
        {
            this._model = model;
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
            isStartChecked = true;
            isTerminatorChecked = false;
            isProcessChecked = false;
            isDecisionChecked = false;
            isSelectedChecked = false;
            _model.SetMode("Start");
        }

        public void TerminatorPressed()
        {
            isStartChecked = false;
            isTerminatorChecked = true;
            isProcessChecked = false;
            isDecisionChecked = false;
            isSelectedChecked = false;
            _model.SetMode("Terminator");
        }

        public void ProcessPressed()
        {
            isStartChecked = false;
            isTerminatorChecked = false;
            isProcessChecked = true;
            isDecisionChecked = false;
            isSelectedChecked = false;
            _model.SetMode("Process");
        }

        public void DecisionPressed()
        {
            isStartChecked = false;
            isTerminatorChecked = false;
            isProcessChecked = false;
            isDecisionChecked = true;
            isSelectedChecked = false;
            _model.SetMode("Decision");
        }
        public void SelectPressed()
        {
            isStartChecked = false;
            isTerminatorChecked = false;
            isProcessChecked = false;
            isDecisionChecked = false;
            isSelectedChecked = true;
            _model.SetMode("");
        }

        public void XChanged(string x)
        {
            _x = x;

        }
        public void YChanged(string y)
        {
            _y= y;
        }
        public void WidthChanged(string width)
        {
            _width = width;
        }
        public void HeightChanged(string height)
        {
            _height = height;
        }

        public void ShapeChanged(string shape)
        {
            _shape = shape;
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
            }catch {
                return false;
            }
        }

        public bool IsYValid() {
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
            Console.WriteLine("@@@@@@");
            Console.WriteLine(_shape);
            if (_shape == "")
            {
                return false;
            }
            return true;
            
        }
        public bool IsAddEnable()
        {
            if (IsXValid() && IsYValid() && IsWidthValid() && IsHeightValid() && IsShapeValid())
            {
                return true;
            }
            return false;
            
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

        public void AddShape()
        {
            _model.AddShape(_shape, _text, int.Parse(_x), int.Parse(_y), int.Parse(_width), int.Parse(_height));
        }

    }
}
