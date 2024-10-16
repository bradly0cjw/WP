using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private readonly Model _model;

        public Form1(Model model)
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();

            this._model = model; // Assign the model parameter to the _model field
            dataGridView_graph.CellClick += DataGridView_graph_CellClick;
        }

        // Initialize the combobox with the shape names
        private void InitializeComboBox()
        {
            comboBox_shapeName.Items.Add("Start");
            comboBox_shapeName.Items.Add("Terminator");
            comboBox_shapeName.Items.Add("Process");
            comboBox_shapeName.Items.Add("Decision");
        }

        // Initialize the datagridview
        private void InitializeDataGridView()
        {
            dataGridView_graph.Rows.Clear();
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string shapeName = comboBox_shapeName.Text;
                string text = textBox_text.Text;
                int x = int.Parse(textBox_x.Text);
                int y = int.Parse(textBox_y.Text);
                int width = int.Parse(textBox_width.Text);
                int height = int.Parse(textBox_height.Text);

                // Add shape to the model
                _model.AddShape(shapeName, text, x, y, width, height);
                UpdateGrid();
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }

        }

        private void UpdateGrid()
        {
            // Get the shapes from the model
            List<ShapeWrapper> shapes = _model.GetShapes();
            // Clear the grid
            dataGridView_graph.Rows.Clear();

            // Add the shapes to the grid
            foreach (ShapeWrapper shapeWrapper in shapes)
            {
                Shape shape = shapeWrapper.Shape;
                dataGridView_graph.Rows.Add(
                    "Delete",
                    shapeWrapper.Id,
                    shapeWrapper.Text,
                    shape.ShapeName,
                    shape.X,
                    shape.Y,
                    shape.Width,
                    shape.Height
                );
            }
        }

        private void DataGridView_graph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the delete button is clicked
            if (e.ColumnIndex != dataGridView_graph.Columns["Delete"].Index || e.RowIndex < 0)
                return;
            // Get the shape id
            int shapeId = (int)dataGridView_graph.Rows[e.RowIndex].Cells["Id"].Value;
            _model.RemoveShape(shapeId);
            UpdateGrid();
        }
    }
}
