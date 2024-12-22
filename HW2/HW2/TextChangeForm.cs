using System;
using System.Windows.Forms;

namespace HW2
{
    public partial class TextChangeForm : Form
    {
        private readonly PresentationModel2 _pModel;

        public TextChangeForm(string currentText)
        {
            InitializeComponent();
            _pModel = new PresentationModel2(currentText);
            textBoxNewText.Text = currentText;
            textBoxNewText.TextChanged += textBoxNewText_TextChanged;

            buttonOK.DataBindings.Add("Enabled", _pModel, "IsConfirmEnabled");
        }

        public void textBoxNewText_TextChanged(object sender, EventArgs e)
        {
            _pModel.TextChanged(textBoxNewText.Text);
        }

        public string GetText()
        {
            return textBoxNewText.Text;
        }
    }
}