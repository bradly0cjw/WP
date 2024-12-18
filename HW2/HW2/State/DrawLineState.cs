using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.State
{
    public class DrawLineState : IState
    {
        private Model _model;
        private int _initX;
        private int _initY;

        public void Initialize(Model model)
        {
            _model = model;
        }

        public void MouseDown(int x, int y)
        {
            foreach (Shape shape in Enumerable.Reverse(_model.GetShapes()))
            {
                if (shape.IsClickConnectPoint(x, y)!=null)
                {
                    
                }
            }
        }

        public void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void MouseUp(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Draw(IGraphic graphic)
        {
            throw new NotImplementedException();
        }

    }
}
