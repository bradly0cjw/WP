using System;

namespace HW2
{
    public class MoveCommand : ICommand
    {
        private readonly Shape _shape;
        private readonly int _oldX;
        private readonly int _oldY;
        private readonly int _newX;
        private readonly int _newY;

        public MoveCommand(Shape shape, int oldX, int oldY, int newX, int newY)
        {
            _shape = shape;
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