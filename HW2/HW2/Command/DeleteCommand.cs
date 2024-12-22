using System;

namespace HW2
{
    public class DeleteCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public DeleteCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        public void Execute()
        {
            _model.RemoveShape(_shape);
        }

        public void Unexecute()
        {
            _model.AddShapeObj(_shape);
        }
    }
}