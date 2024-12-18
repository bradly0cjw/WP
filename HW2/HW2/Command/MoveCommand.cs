using System;

namespace HW2
{
    public class MoveCommand : ICommand
    {
        private Shape _shape;
        private Model _model;
        private int _oldX;
        private int _oldY;
        private int _newX;
        private int _newY;

        public MoveCommand(Model model, Shape shape, int oldX, int oldY, int newX, int newY)
        {
            _shape = shape;
            _model = model;
            _oldX = oldX;
            _oldY = oldY;
            _newX = newX;
            _newY = newY;
        }

        public void Execute()
        {
            _shape.X = _newX;
            _shape.Y = _newY;
        }

        public void Unexecute()
        {
            _shape.X = _oldX;
            _shape.Y = _oldY;
        }
    }
}