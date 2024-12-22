using System;

namespace HW2
{
    public class TextMoveCommand : ICommand
    {
        private readonly Shape _shape;
        private readonly int _oldBiasX;
        private readonly int _oldBiasY;
        private readonly int _newBiasX;
        private readonly int _newBiasY;

        public TextMoveCommand(Shape shape, int oldBiasX, int oldBiasY, int newBiasX, int newBiasY)
        {
            _shape = shape;
            _oldBiasX = oldBiasX;
            _oldBiasY = oldBiasY;
            _newBiasX = newBiasX;
            _newBiasY = newBiasY;
        }

        public void Execute()
        {
            _shape.BiasX = _newBiasX;
            _shape.BiasY = _newBiasY;
        }

        public void Unexecute()
        {
            _shape.BiasX = _oldBiasX;
            _shape.BiasY = _oldBiasY;
        }
    }
}