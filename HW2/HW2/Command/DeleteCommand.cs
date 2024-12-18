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
            _model.Shapes.DeleteShape(_shape.ID);
        }

        public void Undo()
        {
            _model.Shapes.AddShape(_shape.ShapeName, _shape.Text, _shape.X, _shape.Y, _shape.W, _shape.H);
        }
    }
}