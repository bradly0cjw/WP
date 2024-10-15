using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Model model;
        public Form1(Model model)
        {
            InitializeComponent();
            comboBox_shape.Items.Add("Start");
            comboBox_shape.Items.Add("Terminator");
            comboBox_shape.Items.Add("Process");
            comboBox_shape.Items.Add("Decision");
            dataGridView_graph.Rows.Clear();
            dataGridView_graph.Columns.Clear();
            this.model = model;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {

        }
    }
}
