using System;

namespace HW2
{
    public class DrawCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        public void Execute()
        {
            _model.AddShapeObj(_shape);
        }

        public void Unexecute()
        {
            _model.RemoveShape(_shape);
        }
    }
}