using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2;

namespace HW2Tests
{
    internal class MockState : IState
    {
        Model _model;

        public int mouseDownX;
        public int mouseDownY;
        public int mouseUpX;
        public int mouseUpY;
        public int mouseMoveX;
        public int mouseMoveY;


        public bool isDrawCalled;


        public void Initialize(Model model)
        {
            _model = model;
        }
        public void MouseDown(int x, int y)
        {
            mouseDownX = x;
            mouseDownY = y;
        }
        public void MouseMove(int x, int y)
        {
            mouseMoveX = x;
            mouseMoveY = y;
        }
        public void MouseUp(int x, int y)
        {
            mouseUpX = x;
            mouseUpY = y;
        }
        public void Draw(IGraphic graphic)
        {
            isDrawCalled = true;
        }

    }
}
