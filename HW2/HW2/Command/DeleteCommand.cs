using System.Collections.Generic;
using System.Linq;
using HW2;

namespace HW2
{

    public class DeleteCommand : ICommand
    {
        private readonly Model _model;
        private readonly Shape _shape;
        private readonly List<Shape> _deletedLines;

        public DeleteCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
            _deletedLines = new List<Shape>();
        }

        public void Execute()
        {
            // Remove lines connected to the shape
            var connectedLines = _model.Shapes.GetShapes()
                .Where(s => s is Line line && (line.Shape1 == _shape || line.Shape2 == _shape))
                .ToList();

            foreach (var line in connectedLines)
            {
                _model.Shapes.DeleteShape(line.ID);
                _deletedLines.Add(line);
            }

            // Remove the shape
            _model.Shapes.DeleteShape(_shape.ID);

            // Notify the model of the change
            _model.SetPointState();
            _model.NotifyObserver();
        }

        public void Unexecute()
        {
            // Restore the shape
            _model.Shapes.AddShape(_shape);

            // Restore the connected lines
            foreach (var line in _deletedLines)
            {
                _model.Shapes.AddShape(line);
            }

            // Notify the model of the change
            _model.NotifyObserver();
        }
    }
}