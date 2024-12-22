using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class AddCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public AddCommand(Model model, Shape shape)
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
