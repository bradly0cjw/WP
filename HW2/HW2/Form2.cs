using System;
using System.Windows.Forms;

namespace HW2
{
    public partial class 文字編輯方塊 : Form
    {
        public string NewText { get; private set; }

        public 文字編輯方塊(string currentText)
        {
            InitializeComponent();
            textBoxNewText.Text = currentText;
            buttonOK.Enabled = !string.IsNullOrEmpty(currentText);
        }

        private void textBoxNewText_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = !string.IsNullOrEmpty(textBoxNewText.Text);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            NewText = textBoxNewText.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}