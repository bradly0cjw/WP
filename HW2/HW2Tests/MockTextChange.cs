using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2;

namespace HW2Tests
{
    internal class MockTextChange : TextChange
    {
        public MockTextChange(Model model) : base(model)
        {
        }

        public override void ShowTextChangeForm(Shape shape)
        {
        }
    }
}
