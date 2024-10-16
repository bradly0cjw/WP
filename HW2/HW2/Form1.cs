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
            //dataGridView_graph.Rows.Clear();
            //dataGridView_graph.Columns.Clear();
            //DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            //deleteButtonColumn.Name = "Delete";
            //deleteButtonColumn.HeaderText = "Delete";
            //deleteButtonColumn.Text = "Delete";
            //deleteButtonColumn.UseColumnTextForButtonValue = true;
            //dataGridView_graph.Columns.Add(deleteButtonColumn);

            //dataGridView_graph.Columns.Add("Id", "Id");
            //dataGridView_graph.Columns.Add("ShapeType", "Shape Type");
            //dataGridView_graph.Columns.Add("Text", "Text");
            //dataGridView_graph.Columns.Add("X", "X");
            //dataGridView_graph.Columns.Add("Y", "Y");
            //dataGridView_graph.Columns.Add("Width", "Width");
            //dataGridView_graph.Columns.Add("Height", "Height");

            // Initialize DataGridView columns
            InitializeDataGridView();

            this.model = model;
            // Subscribe to the CellClick event
            dataGridView_graph.CellClick += dataGridView_graph_CellClick;

        }

        private void InitializeDataGridView()
        {
            dataGridView_graph.Rows.Clear();
            //dataGridView_graph.Columns.Clear();

            //DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            //deleteButtonColumn.Name = "Delete";
            //deleteButtonColumn.HeaderText = "Delete";
            //deleteButtonColumn.Text = "Delete";
            //deleteButtonColumn.UseColumnTextForButtonValue = true;
            //dataGridView_graph.Columns.Add(deleteButtonColumn);

            //dataGridView_graph.Columns.Add("Id", "Id");
            //dataGridView_graph.Columns.Add("ShapeType", "Shape Type");
            //dataGridView_graph.Columns.Add("Text", "Text");
            //dataGridView_graph.Columns.Add("X", "X");
            //dataGridView_graph.Columns.Add("Y", "Y");
            //dataGridView_graph.Columns.Add("Width", "Width");
            //dataGridView_graph.Columns.Add("Height", "Height");
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
            List<ShapeWrapper> shapes = model.UpdateShape();

            // Clear existing rows in the DataGridView
            dataGridView_graph.Rows.Clear();

            // Add each shape as a new row in the DataGridView
            foreach (ShapeWrapper shapeWrapper in shapes)
            {
                dataGridView_graph.Rows.Add("Delete", shapeWrapper.Id, shapeWrapper.ShapeType, shapeWrapper.Shape.Text, shapeWrapper.Shape.X, shapeWrapper.Shape.Y, shapeWrapper.Shape.Width, shapeWrapper.Shape.Height);
            }
        }
        private void dataGridView_graph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a delete button
            if (e.ColumnIndex == dataGridView_graph.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // Get the shape ID from the row
                int shapeId = (int)dataGridView_graph.Rows[e.RowIndex].Cells["Id"].Value;

                // Remove the shape from the model
                model.RemoveShape(shapeId);

                // Update the DataGridView
                UpdateGrid();
            }
        }
    }
}
