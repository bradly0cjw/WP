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
            dataGridView_graph.Columns.Add("Id", "Id");
            dataGridView_graph.Columns.Add("ShapeType", "Shape Type");
            dataGridView_graph.Columns.Add("Text", "Text");
            dataGridView_graph.Columns.Add("X", "X");
            dataGridView_graph.Columns.Add("Y", "Y");
            dataGridView_graph.Columns.Add("Width", "Width");
            dataGridView_graph.Columns.Add("Height", "Height");
            this.model = model;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int err = 0;
            err=model.AddShape(comboBox_shape.Text,textBox_text.Text,textBox_x.Text,textBox_y.Text,textBox_h.Text,textBox_w.Text);
            if (err == 1)
            {
                MessageBox.Show("Invalid shape type");
            }
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            // Fetch the list of shapes from the model
            List<Shape> shapes = model.UpdateShape();

            // Clear existing rows in the DataGridView
            dataGridView_graph.Rows.Clear();

            // Add each shape as a new row in the DataGridView
            foreach (Shape shape in shapes)
            {
                dataGridView_graph.Rows.Add(shape.Id, shape.ShapeName, shape.Text, shape.X, shape.Y, shape.Width, shape.Height);
            }
        }
    }
}
