using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class TextChangedCommand : ICommand
    {
        private readonly Shape _shape;
        private readonly string _oldText;
        private readonly string _newText;

        public TextChangedCommand(Shape shape, string oldText, string newText)
        {
            _shape = shape;
            _oldText = oldText;
            _newText = newText;
        }

        public void Execute()
        {
            _shape.Text = _newText;
        }

        public void Unexecute()
        {
            _shape.Text = _oldText;
        }
    }
}



