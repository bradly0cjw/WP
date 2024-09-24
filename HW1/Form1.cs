using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1
{
    public partial class Form1 : Form
    {
        Model model= new Model();
        public Form1()
        {
            InitializeComponent();
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
            button_add.Click += OperationButton_Click;
            button_sub.Click += OperationButton_Click;
            button_mul.Click += OperationButton_Click;
            button_div.Click += OperationButton_Click;
            button_equ.Click += Solve;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //result.Text=
        }


        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                result.Text = model.SetDigit(result.Text, button.Text);
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                model.SetOperation(button.Text);
                //MessageBox.Show("Called "+ button.Text);
            }
        }

        private void Solve(object sender, EventArgs e)
        {
            result.Text = model.Calculate();
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            result.Text = model.Clear();
        }

        private void button_ce_Click(object sender, EventArgs e)
        {
            result.Text = model.ClearEntry();
        }

        private void button_mr_Click(object sender, EventArgs e)
        {
            result.Text = model.MRecall();
        }

        private void button_ms_Click(object sender, EventArgs e)
        {
            model.MStore(result.Text);
        }

        private void button_mc_Click(object sender, EventArgs e)
        {
            model.MClear();
        }

        private void button_m_plus_Click(object sender, EventArgs e)
        {
            model.MPlus(result.Text);
        }

        private void button_m_minus_Click(object sender, EventArgs e)
        {
            model.MMinus(result.Text);
        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
