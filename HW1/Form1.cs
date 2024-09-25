using System;
using System.Windows.Forms;

namespace HW1
{
    public partial class Form1 : Form
    {
        private readonly Model model = new Model();

        public Form1()
        {
            InitializeComponent();
            AssignEventHandlers();
        }

        private void AssignEventHandlers()
        {
            // Assign the same event handler to all digit buttons
            button_0.Click += DigitButton_Click;
            button_1.Click += DigitButton_Click;
            button_2.Click += DigitButton_Click;
            button_3.Click += DigitButton_Click;
            button_4.Click += DigitButton_Click;
            button_5.Click += DigitButton_Click;
            button_6.Click += DigitButton_Click;
            button_7.Click += DigitButton_Click;
            button_8.Click += DigitButton_Click;
            button_9.Click += DigitButton_Click;
            button_dot.Click += DigitButton_Click;

            // Assign the same event handler to all operation buttons
            button_add.Click += OperationButton_Click;
            button_sub.Click += OperationButton_Click;
            button_mul.Click += OperationButton_Click;
            button_div.Click += OperationButton_Click;

            // Assign event handler to solve button
            button_equ.Click += (sender,e) => result.Text = model.CalculateResult();

            // Assign event handlers to memory and clear buttons
            button_c.Click += (sender, e) => result.Text = model.Clear();
            button_ce.Click += (sender, e) => result.Text = model.ClearEntry();
            button_mr.Click += (sender, e) => result.Text = model.MemoryRecall();
            button_ms.Click += (sender, e) => model.MemoryStore(result.Text);
            button_mc.Click += (sender, e) => model.MemoryClear();
            button_m_plus.Click += (sender, e) => model.MemoryPlus(result.Text);
            button_m_minus.Click += (sender, e) => model.MemoryMinus(result.Text);
        }

        private void DigitButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                result.Text = model.AppendDigit(result.Text, button.Text);
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                model.SetOperation(button.Text);
            }
        }
    }
}
