using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Model _model;

        private string _shape;
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
    }
}
