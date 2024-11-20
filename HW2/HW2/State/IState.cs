using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public interface IState
    {
        void Initialize(Model model);
        void MouseDown(int x, int y);
        void MouseMove(int x, int y);
        void MouseUp(int x, int y);
        void Draw(IGraphic g);
    }
}
