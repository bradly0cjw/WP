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
            _model.AddShape(_shape);
        }

        public void Undo()
        {
            _model.RemoveShape(_shape.ID);
        }
    }
}