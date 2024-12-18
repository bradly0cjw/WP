using System;

namespace HW2
{
    public class TextMoveCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private int _oldBiasX;
        private int _oldBiasY;
        private int _newBiasX;
        private int _newBiasY;

        public TextMoveCommand(Model model, Shape shape, int oldBiasX, int oldBiasY, int newBiasX, int newBiasY)
        {
            _model = model;
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