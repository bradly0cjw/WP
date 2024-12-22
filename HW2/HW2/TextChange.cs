using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public class TextChange
    {
        private readonly Model _model;

        public TextChange(Model model)
        {
            _model = model;
        }

        public virtual void ShowTextChangeForm(Shape shape)
        {
            TextChangeForm textChangeForm = new TextChangeForm(shape.Text);
            DialogResult result = textChangeForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                shape.Text = textChangeForm.GetText();
                _model.NotifyObserver();
            }
        }
    }
}
